using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClusterDesignTool;
using System.Threading;
using System.IO;
using System.Reflection;

namespace CDT
{
    public partial class frm_CDT : Form
    {
        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        List<cpu> theCPUS = new List<cpu>();
        List<mem> theMems = new List<mem>();
        List<gpu> theGPUS = new List<gpu>();


        ConcurrentBag<rack> allPossibleRacks = new ConcurrentBag<rack>();
        ConcurrentBag<cluster> viableClusters = new ConcurrentBag<cluster>();

        ConcurrentBag<cluster> tempViableClusters = new ConcurrentBag<cluster>();

        List<int> nodesInRack = new List<int>();
        List<int> cpusInNode = new List<int>();
        List<int> memsInNode = new List<int>();
        List<int> gpusInNode = new List<int>();

        char p1, p2, p3;

        Boolean readyToGenerateClusters = false;
        Boolean doneGeneratingCluster = false;

        bool inputChanged = false;

        //performance goals
        double cpu_gflops, gpu_sp_tflops, gpu_dp_gflops, min_ram, min_vram, min_ram_per_core;

        //budget constraints
        double total_budget;
        double monthly_power_budget;

        //power constraints
        double max_cluster_power;
        double max_rack_power;

        //space constraints
        double max_racks;




        //needed info
        double cost_construct;
        double daily_load_hours;
        double weekly_load_days;
        double average_load_percentage;
        double electricity_cost;

        List<string> priorities = new List<string>();
        List<string> prioritiesLeft = new List<string>();

        List<int> enabledIndexes = new List<int>();
        int currentIndex = 0;

        public frm_CDT()
        {
            InitializeComponent();
            enabledIndexes.Add(0);
            TabPage firstTab = tbc.TabPages[0];

            cpusInNode.Add(1); cpusInNode.Add(2); cpusInNode.Add(4);
            memsInNode.Add(2); memsInNode.Add(4); memsInNode.Add(8);
            gpusInNode.Add(0); gpusInNode.Add(1); gpusInNode.Add(2); gpusInNode.Add(4);
            nodesInRack.Add(4); nodesInRack.Add(8); nodesInRack.Add(16); nodesInRack.Add(24);

            txt_welcome.Text = "Welcome to the Cluster Design Tool. This simple tool will help guide the creation of a cluster system that meets your needs, taking into account your available budget, power and space constraints." +
               Environment.NewLine + Environment.NewLine + "---Assumputions---" + Environment.NewLine + Environment.NewLine +
                "->  Racks in cluster are identical" + Environment.NewLine +
                "->  Nodes in rack are identical" + Environment.NewLine +
                "-> Only CPUs, GPUs and Memory components are accounted for." + Environment.NewLine +
                "-> Virtual Cores aren't taken into account for FLOPS calculation." + 
                 Environment.NewLine + Environment.NewLine +
                 "---Instructions---" + Environment.NewLine + Environment.NewLine +
                 "-> Input your needs of the cluster on the second page."+ Environment.NewLine +
                 "-> Input your constraints of the cluster on the third page."+ Environment.NewLine +
                 "-> Input the extra information on the final page."+ Environment.NewLine +
                 "-> Press the <START> button on the final page to start the generation process.";

            initializePriorities();

            Thread init = new Thread(new ThreadStart(this.initializationMethod));
            init.Start();
        }

        private void initializePriorities()
        {
            priorities.Clear();

            priorities.Add("Maximise Cost Efficiency"); priorities.Add("Maximise Power Efficiency"); priorities.Add("Maximise Space Efficiency");
            priorities.Add("Maximise Performance"); priorities.Add("Minimise Initial Cost");
            prioritiesLeft = priorities;
        }

        private void initializationMethod()
        {
            initializeLists();
            generateAllPossibleRacks();
            readyToGenerateClusters = true;
        }

        private void generateAllPossibleRacks()
        {
            try
            {
                Parallel.ForEach(nodesInRack, s =>
                {
                    foreach (int numc in cpusInNode) foreach (int numm in memsInNode) foreach (int numg in gpusInNode)
                                foreach (cpu cp in theCPUS) foreach (mem me in theMems) foreach (gpu gp in theGPUS)
                                        {
                                            rack tmpRack = new rack(s, new node(numc, numm, numg, cp, gp, me));
                                            allPossibleRacks.Add(tmpRack);
                                        }
                });

                txt_log.BeginInvoke((Action)(() =>
                {
                    txt_log.AppendText(Environment.NewLine + Environment.NewLine + "Possible Rack Configurations:\t" + allPossibleRacks.Count);
                    txt_log.AppendText(Environment.NewLine + Environment.NewLine + getBestComponents());
                }));
                readyToGenerateClusters = true;


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private string getBestComponents()
        {
            string msg = "-----------Best Performing Components:-----------" + Environment.NewLine;
            double fastestCPUd = 0; cpu fastestcpu = new cpu();
            double fastestGPUd = 0; gpu fastestgpu = new gpu();
            double fastestMemoryd = 0; mem fastestmem = new mem();

            foreach (cpu c in theCPUS)
            {
                if (c.calculateGFLOPS() > fastestCPUd)
                {
                    fastestCPUd = c.calculateGFLOPS();
                    fastestcpu = c;
                }
            }

            foreach (gpu g in theGPUS)
            {
                if (g.getDpTFLOPS() > fastestGPUd)
                {
                    fastestGPUd = g.getDpTFLOPS();
                    fastestgpu = g;
                }
            }

            foreach (mem m in theMems)
            {
                double measure = m.getCapacityGB() * m.getFrequencyMhz();

                if (measure > fastestMemoryd)
                {
                    fastestMemoryd = measure;
                    fastestmem = m;
                }
            }

            msg += Environment.NewLine + "CPU:\t" + fastestcpu.toString()+ Environment.NewLine;
            msg += Environment.NewLine + "GPU:\t" + fastestgpu.toString() + Environment.NewLine;
            msg += Environment.NewLine + "MEM:\t" + fastestmem.toString() + Environment.NewLine;


            msg += Environment.NewLine + "-----------Most Cost Effective Components:-----------" + Environment.NewLine;


            double costEffectiveCPUd = 0; cpu costEffectivecpu = new cpu();
            double costEffectiveGPUd = 0; gpu costEffectivegpu = new gpu();
            double costEffectiveMemoryd = 0; mem costEffectivemem = new mem();

            foreach (cpu c in theCPUS)
            {
                double measure = c.calculateGFLOPS()/c.getComponentCost();

                if (measure > costEffectiveCPUd)
                {
                    costEffectiveCPUd = measure;
                    costEffectivecpu = c;
                }
            }

            foreach (gpu g in theGPUS)
            {
                double measure = g.getSpTFLOPS()/ g.getComponentCost();

                if (measure > costEffectiveGPUd)
                {
                    costEffectiveGPUd = measure;
                    costEffectivegpu = g;
                }
            }

            foreach (mem m in theMems)
            {
                double measure = (m.getCapacityGB() * m.getFrequencyMhz())/m.getComponentCost();

                if (measure > costEffectiveMemoryd)
                {
                    costEffectiveMemoryd = measure;
                    costEffectivemem = m;
                }
            }

            msg += Environment.NewLine + "CPU:\t" + costEffectivecpu.toString() + Environment.NewLine;
            msg += Environment.NewLine + "GPU:\t" + costEffectivegpu.toString() + Environment.NewLine;
            msg += Environment.NewLine + "MEM:\t" + costEffectivemem.toString() + Environment.NewLine;


            msg += Environment.NewLine + "-----------Most Power Efficient Components:-----------" + Environment.NewLine;


            double powerEfficientCPUd = 0; cpu powerEfficientcpu = new cpu();
            double powerEfficientGPUd = 0; gpu powerEfficientgpu = new gpu();
            double powerEfficientMemoryd = 0; mem powerEfficientmem = new mem();

            foreach (cpu c in theCPUS)
            {
                double measure = c.calculateGFLOPS() / c.getComponentTDP();

                if (measure > powerEfficientCPUd)
                {
                    powerEfficientCPUd = measure;
                    powerEfficientcpu = c;
                }
            }

            foreach (gpu g in theGPUS)
            {
                double measure = g.getSpTFLOPS() / g.getComponentTDP();

                if (measure > powerEfficientGPUd)
                {
                    powerEfficientGPUd = measure;
                    powerEfficientgpu = g;
                }
            }

            foreach (mem m in theMems)
            {
                double measure = (m.getCapacityGB() * m.getFrequencyMhz()) / m.getComponentTDP();

                if (measure > powerEfficientMemoryd)
                {
                    powerEfficientMemoryd = measure;
                    powerEfficientmem = m;
                }
            }

            msg += Environment.NewLine + "CPU:\t" + powerEfficientcpu.toString() + Environment.NewLine;
            msg += Environment.NewLine + "GPU:\t" + powerEfficientgpu.toString() + Environment.NewLine;
            msg += Environment.NewLine + "MEM:\t" + powerEfficientmem.toString() + Environment.NewLine;


            return msg;
        }

        private double calculateMonthlyCost(cluster clust)
        {
            int monthHours = 4 * (int)weekly_load_days * (int)daily_load_hours;
            double costPerHour = electricity_cost * (clust.getClusterTDP() / 1000);

            

            return costPerHour * monthHours * (average_load_percentage / 100);
        }

        private double getInverseTarget(double value, double percent)
        {
            return (percent / 100) * value;
        }

        private double calculateInitialClusterCost(cluster clust)
        {
            double constructionCost = clust.getClusterCost() * (1 + (cost_construct / 100));

            return clust.getClusterCost() + constructionCost;

        }

        private void generateViableClusters()
        {
            cluster bestCluster;
            doneGeneratingCluster = false;
            readyToGenerateClusters = false;
            int zeroResultCount = 0;
            bool ended = false;

            int step = (int)(prg_1.Maximum / (int)max_racks) - 1;

            int clustersSoFar = 0;
            long start = CurrentTimeSeconds();

            for (int k = (int)max_racks; k >= 1; k--)
            {
                    Parallel.ForEach(allPossibleRacks, currentRack =>
                    {

                        cluster tmpCluster = new cluster(k, currentRack);

                        if (
                            //performance needs
                            cpu_gflops >= tmpCluster.getClusterCPUGFLOPS() ||
                            gpu_sp_tflops >= tmpCluster.getClusterGPUTFLOPS_sp() ||
                            gpu_dp_gflops >= tmpCluster.getClusterGPUTFLOPS_dp() ||
                            min_ram >= tmpCluster.getClusterRAM() ||
                            min_vram >= tmpCluster.getClusterVRAM() ||

                            //budget constraint
                            monthly_power_budget <= calculateMonthlyCost(tmpCluster) ||
                            total_budget <= calculateInitialClusterCost(tmpCluster) ||

                            //power constraints
                            max_cluster_power <= tmpCluster.getClusterTDP() ||
                            max_rack_power <= tmpCluster.getRackUsed().getRackTDP() ||

                            // memory per Core rule
                            tmpCluster.getRAMperCore() < min_ram_per_core)
                        {
                            //exclude cluster
                        }
                        else //include cluster
                            viableClusters.Add(tmpCluster);


                    });
                
                    prg_1.Value = Math.Abs(prg_1.Maximum - (k * step));
                    int clustersOfThisSize = viableClusters.Count - clustersSoFar;

                    txt_log.AppendText(Environment.NewLine + "Viable Clusters of size " + k + ":\t" + clustersOfThisSize);
                    clustersSoFar = viableClusters.Count;
                }
                prg_1.Value = prg_1.Maximum;
                if (viableClusters.Count == 1)
                {
                    bestCluster = viableClusters.ElementAt(0);
                    txt_log.Text = bestCluster.getDetails() + Environment.NewLine + "TOTAL MONTHLY COST:\t\t" + string.Format("{0:0.00}", calculateMonthlyCost(bestCluster)) + "\t USD";
                }
                else if (viableClusters.Count > 1)
                {
                    setPriorities();

                    int beforeFilter1 = 0;
                    int beforeFilter2 = 0;
                    int beforeFilter3 = 0;

                    ConcurrentBag<cluster> tmpList = viableClusters;


                    int cnt = 0;

                    bool cont = true;
                    while (cont)
                    {
                        //filter 1st priority
                        int tmp1 = tmpList.Count;
                        tmpList = binaryFilter(tmpList, p1); txt_log.AppendText(Environment.NewLine + "Finding optimal solution step " + ++cnt + " : " + +tmpList.Count);
                        if (tmpList.Count > 1) { cont = false; }

                        beforeFilter1 += Math.Abs(tmpList.Count - tmp1);
                        tmp1 = tmpList.Count;

                        tmpList = binaryFilter(tmpList, p1); txt_log.AppendText(Environment.NewLine + "Finding optimal solution step " + ++cnt + " : " + +tmpList.Count);
                        if (tmpList.Count > 1) { cont = false; }

                        beforeFilter1 += Math.Abs(tmpList.Count - tmp1);
                        tmp1 = tmpList.Count;

                        tmpList = binaryFilter(tmpList, p1); txt_log.AppendText(Environment.NewLine + "Finding optimal solution step " + ++cnt + " : " + +tmpList.Count);
                        if (tmpList.Count > 1) { cont = false;};

                        beforeFilter1 += Math.Abs(tmpList.Count - tmp1);
                        tmp1 = tmpList.Count;

                        //filter 2st priority

                        int tmp2 = tmpList.Count;
                        tmpList = binaryFilter(tmpList, p2); txt_log.AppendText(Environment.NewLine + "Finding optimal solution step " + ++cnt + " : " + +tmpList.Count);
                        if (tmpList.Count > 1) { cont = false;}

                        beforeFilter2 += Math.Abs(tmpList.Count - tmp2);
                        tmp2 = tmpList.Count;
                        

                        tmpList = binaryFilter(tmpList, p2); txt_log.AppendText(Environment.NewLine + "Finding optimal solution step " + ++cnt + " : " + +tmpList.Count);
                        if (tmpList.Count > 1) { cont = false; }

                        beforeFilter2 += Math.Abs(tmpList.Count - tmp2);
                        tmp2 = tmpList.Count;

                        //filter 3st priority

                        int tmp3 = tmpList.Count;
                        tmpList = binaryFilter(tmpList, p3); txt_log.AppendText(Environment.NewLine + "Finding optimal solution step " + ++cnt + " : " + +tmpList.Count);
                        if (tmpList.Count > 1) { cont = false; }

                        beforeFilter3 += Math.Abs(tmpList.Count - tmp3);
                        tmp3 = tmpList.Count;

                        while((beforeFilter1 + beforeFilter2 + beforeFilter3 + 1) < viableClusters.Count){if (beforeFilter2 > beforeFilter3) beforeFilter3++;else beforeFilter2++;
                        }
                    }

                    bestCluster = tmpList.ElementAt(0);
                    txt_log.Text = bestCluster.getDetails() + Environment.NewLine + "TOTAL MONTHLY COST:\t\t" + string.Format("{0:0.00}", calculateMonthlyCost(bestCluster)) + "\t USD";
                    txt_log.Text += Environment.NewLine + Environment.NewLine + "Priorities:" +
                                                                         Environment.NewLine + "1st:\t" + getPriorityString(p1) + "\tFiltered out\t" + beforeFilter1 + "/"+ viableClusters.Count +
                                                                         Environment.NewLine + "2nd:\t" + getPriorityString(p2) + "\tFiltered out\t" + beforeFilter2 + "/" + viableClusters.Count +
                                                                         Environment.NewLine + "3rd:\t" + getPriorityString(p3) + "\tFiltered out\t" + beforeFilter3 + "/" + viableClusters.Count;

                }
                else
                {
                    txt_log.AppendText(Environment.NewLine + Environment.NewLine + "No cluster configurations satisfy needs within constraints. Adjust either and try again.");
                }
                readyToGenerateClusters = true;

                if (ended)
                {
                    txt_log.Clear();
                    txt_log.AppendText(Environment.NewLine + Environment.NewLine + "No viable clusters were found within 3 size configurations in a row, so the generation process was halted. Adjust needs/constraints.");
                
                }

            
        }

        private ConcurrentBag<cluster> binaryFilter(ConcurrentBag<cluster> listIn, char mode)
        {
            ConcurrentBag<cluster> returnList = new ConcurrentBag<cluster>();
            int amount;

            if (listIn.Count % 2 == 0) // even
                amount = (int)listIn.Count / 2;
            else //odd
                amount = (int)(listIn.Count + 1) / 2;

            switch (mode)
            {
                case 'C':
                    { //cost efficiency
                        List<cluster> sortedList = listIn.AsParallel().OrderBy(o => o.getPerformance_to_Cost_ratio()).ToList<cluster>();

                        Parallel.ForEach(sortedList, c =>
                        {
                            if (returnList.Count < amount)
                                returnList.Add(c);
                        });

                        break;
                    }

                case 'S':
                    { // space efficiency
                        List<cluster> sortedList = listIn.AsParallel().OrderBy(o => o.getPerformance_to_Space_ratio()).ToList<cluster>();

                        Parallel.ForEach(sortedList, c =>
                        {
                            if (returnList.Count < amount)
                                returnList.Add(c);
                        });
                        break;
                    }
                case 'P':
                    { //power efficiency
                        List<cluster> sortedList = listIn.AsParallel().OrderBy(o => o.getPerformance_to_Power_Usage()).ToList<cluster>();

                        Parallel.ForEach(sortedList, c =>
                        {
                            if (returnList.Count < amount)
                                returnList.Add(c);
                        });
                        break;
                    }
                case 'M':
                    { //max power
                        List<cluster> sortedList = listIn.AsParallel().OrderBy(o => o.getTotal_Performance()).ToList<cluster>();

                        Parallel.ForEach(sortedList, c =>
                        {
                            if (returnList.Count < amount)
                                returnList.Add(c);
                        });
                        break;
                    }

                case 'Q':
                    { //max power
                        List<cluster> sortedList = listIn.AsParallel().OrderByDescending(o => o.getClusterCost()).ToList<cluster>();

                        Parallel.ForEach(sortedList, c =>
                        {
                            if (returnList.Count < amount)
                                returnList.Add(c);
                        });
                        break;
                    }
            }

            return returnList;
        }

        private Boolean testInput()
        {
            //-----goals-----
            cpu_gflops = -1.0;
            gpu_sp_tflops = -1.0;
            gpu_dp_gflops = -1.0;
            min_ram = -1.0;
            min_vram = -1.0;
            min_ram_per_core = -1.0;

            monthly_power_budget = -1.0;
            total_budget = -1.0;

            //power constraints
            max_cluster_power = -1.0;
            max_rack_power = -1.0;


            //cost constraints


            cost_construct = -1.0;

            //space constraints
            max_racks = -1.0;


            cost_construct = -1.0;
            daily_load_hours = -1.0;
            weekly_load_days = -1.0;
            average_load_percentage = -1.0;
            electricity_cost = -1.0;

            try
            {
                //performance goals
                cpu_gflops = double.Parse(txt_min_cpu_gflops.Text);
                gpu_sp_tflops = double.Parse(txt_min_gpu_tflops_sp.Text);
                gpu_dp_gflops = double.Parse(txt_min_gpu_tflops_dp.Text);
                min_ram = double.Parse(txt_min_ram.Text);
                min_vram = double.Parse(txt_min_vram.Text);
                min_ram_per_core = double.Parse(txt_ram_per_core.Text);

                //budget
                total_budget = double.Parse(txt_total_budget.Text);
                monthly_power_budget = double.Parse(txt_monthly_power_budget.Text);

                //power
                max_cluster_power = double.Parse(txt_max_power_delivery.Text);
                max_rack_power = double.Parse(txt_max_rack_power.Text);

                //space 
                max_racks = double.Parse(txt_max_racks.Text);

                //needed info
                cost_construct = double.Parse(txt_construction_cost.Text);
                electricity_cost = double.Parse(txt_electricity_cost.Text);
                daily_load_hours = double.Parse(txt_daily_load_hours.Text);
                weekly_load_days = double.Parse(txt_weekly_load_days.Text);
                average_load_percentage = double.Parse(cmb_average_load_percent.Text);

                return true;
            }
            catch (Exception fe)
            {
                txt_log.Text = "\nPlease check all input values for validity and type and try again.";

                string msg = "Errors in input: \n";


                //1st page
                if (cpu_gflops == -1.0)
                    msg += "\n\n *  'Minimum CPU GFLOPS' Perf. Constraint";

                if (gpu_sp_tflops == -1.0)
                    msg += "\n\n *  'Minimum GPU TFLOPS SP' Perf. Constraint";

                if (gpu_dp_gflops == -1.0)
                    msg += "\n\n *  'Minimum GPU TFLOPS DP'Perf. Constraint";

                if (min_ram == -1.0)
                    msg += "\n\n *  'Minimum RAM' Perf. Constraint";

                if (min_vram == -1.0)
                    msg += "\n\n *  'Minimum VRAM' Perf. Constraint";


                //2nd page

                if (total_budget == -1.0)
                    msg += "\n\n *  'Total Budget' Constraint";

                if (monthly_power_budget == -1.0)
                    msg += "\n\n *  'Monthly Power Budget' Constraint";

                if (max_cluster_power == -1.0)
                    msg += "\n\n *  'Maximum Cluster Power' Constraint";

                if (max_rack_power == -1.0)
                    msg += "\n\n *  'Maximum Rack Power' Constraint";

                if (max_racks == -1.0)
                    msg += "\n\n *  'Maximum # of Racks' Constraint";


                //3rd page

                if (cost_construct == -1.0)
                    msg += "\n\n *  'Construction Cost' Information";

                if (daily_load_hours == -1.0)
                    msg += "\n\n *  'Daily Load Hours' Information";

                if (weekly_load_days == -1.0)
                    msg += "\n\n *  'Weekly Load Days' Information";

                if (weekly_load_days == -1.0)
                    msg += "\n\n *  'Weekly Load Days' Information";

                if (average_load_percentage == -1.0)
                    msg += "\n\n *  'Average Load Percentage' Information";

                if (electricity_cost == -1.0)
                    msg += "\n\n *  'Electricity Cost' Information";

                MessageBox.Show(msg);

                return false;
            }
        }

        public void initializeLists()
        {
            string cpuLines, memLines, gpuLines;

            try
            {

                cpuLines = Properties.Resources.cpus;
                memLines = Properties.Resources.mems;
                gpuLines = Properties.Resources.gpus;

                string[] lines;
                //cpus

                lines = cpuLines.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string s in lines)
                {
                    if (!s.StartsWith("#"))
                    {
                        string[] partsC = s.Split(':');

                        String componentName = partsC[0];
                        double componentCost = double.Parse(partsC[1]);
                        double componentTDP = double.Parse(partsC[2]);
                        int frequencyMhz = int.Parse(partsC[3]);
                        int instructionsPerCycle = int.Parse(partsC[4]);
                        int numOfCores = int.Parse(partsC[5]);
                        string hyperthreaded = partsC[6];

                        bool ht = false;
                        if (hyperthreaded == "Y")
                            ht = true;   

                        cpu tmp = new cpu(frequencyMhz, instructionsPerCycle, numOfCores, componentName, componentCost, componentTDP,ht);
                        theCPUS.Add(tmp);
                    }

                }
                //mems
                lines = memLines.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string s in lines)
                {
                    if (!s.StartsWith("#"))
                    {
                        //#componentName:componentCost:componentTDP:capacityGB:frequencyMhz
                        string[] partsM = s.Split(':');

                        String componentName = partsM[0];
                        double componentCost = double.Parse(partsM[1]);
                        double componentTDP = double.Parse(partsM[2]);
                        int capacityGB = int.Parse(partsM[3]);
                        int frequencyMhz = int.Parse(partsM[4]);

                        mem tmp = new mem(capacityGB, frequencyMhz, componentName, componentCost, componentTDP);
                        theMems.Add(tmp);
                    }
                }
                //gpus

                lines = gpuLines.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (string s in lines)
                {
                    if (!s.StartsWith("#"))
                    {
                        //#componentName:componentCost:componentTDP:vramGB,sfpTFLOPS,dfpTFLOPS
                        //gpu1:117,65:200,00:2,00:2,00:1,18
                        string[] partsG = s.Split(':');

                        String componentName = partsG[0];
                        double componentCost = double.Parse(partsG[1]);
                        double componentTDP = double.Parse(partsG[2]);
                        Double vramGB = double.Parse(partsG[3]);
                        Double sfpTFLOPS = double.Parse(partsG[4]);
                        Double dfpTFLOPS = double.Parse(partsG[5]);

                        gpu tmp = new gpu(vramGB, sfpTFLOPS, dfpTFLOPS, componentName, componentCost, componentTDP);
                        theGPUS.Add(tmp);
                    }
                }


                txt_log.BeginInvoke((Action)(() =>
                                    {
                                        txt_log.AppendText("Done initializing lists: " + Environment.NewLine + Environment.NewLine + "Processors:\t\t" + theCPUS.Count + Environment.NewLine + "Graphics Processors:\t" + theGPUS.Count + Environment.NewLine + "Memory Sticks:\t\t" + theMems.Count);
                                    }));

            }
            catch (Exception ex)
            {
                txt_log.BeginInvoke((Action)(() =>
                       {
                           txt_log.Text = "ERROR LOADING INPUT DATA!";
                       }));
                Console.WriteLine("\nError loading data files.\n\n" + ex.Message);
            }
        }


        private void btn_toNeeds_Click(object sender, EventArgs e)
        {
            enabledIndexes.Add(1);
            tbc.SelectedIndex = 1;
        }

        private void btn_toConstraints_Click(object sender, EventArgs e)
        {
            try
            {
                enabledIndexes.Add(2);
                tbc.SelectedIndex = 2;
            }
            catch (Exception)
            {

            }
        }

        private void btn_toExtraInfo_Click(object sender, EventArgs e)
        {
            enabledIndexes.Add(3);
            tbc.SelectedIndex = 3;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            enabledIndexes.Clear();
            enabledIndexes.Add(0);
            tbc.SelectedIndex = 0;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (readyToGenerateClusters)
            {
                if (testInput())
                {
                    txt_log.Clear();
                    txt_log.Update();

                        txt_log.AppendText(Environment.NewLine + Environment.NewLine + System.DateTime.Now.ToLongTimeString() + " -> Generation Started: ");
                        long start = CurrentTimeSeconds();

                        generateViableClusters();
                        long secondsTaken = CurrentTimeSeconds() - start;

                        if (viableClusters.Count > 0)
                            txt_log.AppendText(Environment.NewLine + "Generation took: ~ " + secondsTaken + " seconds.");
                        inputChanged = false;

                    viableClusters = new ConcurrentBag<cluster>();//clear list
                }
            }
            else
            {
                txt_log.AppendText(Environment.NewLine + "Not Ready Yet, Please Wait!");
            }
        }
        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }

        public static long CurrentTimeSeconds()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalSeconds;
        }
       
        
        private void setPriorities()
        {
            initializePriorities();

            string p1, p2, p3;
            p1 = p2 = p3 = "unassigned";

            while (p1 == "unassigned" || p2 == "unassigned" || p3 == "unassigned")
            {
                MessageBox.Show( "Multiple (" + viableClusters.Count + ") viable solutions have been found. In order to get the best one for your needs we need to identify your priorities." + Environment.NewLine + Environment.NewLine+
               "At the prompts that follow, please select the priorities in order of importance. You MUST select 3 priorities. Press OK to Continue.", "Instructions", MessageBoxButtons.OK);

                prioritiesLeft = priorities;

                InputBox.SetLanguage(InputBox.Language.English);
                DialogResult res1 = InputBox.ShowDialog("Please select primary goal", "Select Goal:",
                    InputBox.Icon.Question, //Set icon type (default info)
                    InputBox.Buttons.OkCancel, //Set buttons (default ok)
                    InputBox.Type.ComboBox, //Set type (default nothing)
                    prioritiesLeft.ToArray(), //String field as ComboBox items (default null)
                    false, //Set visible in taskbar (default false)
                    new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular)); //Set font (default by system)

                //Check InputBox result
                if (res1 == System.Windows.Forms.DialogResult.OK || res1 == System.Windows.Forms.DialogResult.Yes)
                {
                    p1 = InputBox.ResultValue; //Get returned value
                    prioritiesLeft.Remove(p1);
                }

                //Save the DialogResult as res
                DialogResult res2 = InputBox.ShowDialog("Please select secondary goal", "Select Goal:",
                    InputBox.Icon.Question, //Set icon type (default info)
                    InputBox.Buttons.OkCancel, //Set buttons (default ok)
                    InputBox.Type.ComboBox, //Set type (default nothing)
                    prioritiesLeft.ToArray(), //String field as ComboBox items (default null)
                    false, //Set visible in taskbar (default false)
                    new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular)); //Set font (default by system)

                //Check InputBox result
                if (res2 == System.Windows.Forms.DialogResult.OK || res2 == System.Windows.Forms.DialogResult.Yes)
                {
                    p2 = InputBox.ResultValue; //Get returned value
                    prioritiesLeft.Remove(p2);
                }


                InputBox.SetLanguage(InputBox.Language.English);
                DialogResult res3 = InputBox.ShowDialog("Please third primary goal", "Select Goal:",
                    InputBox.Icon.Question, //Set icon type (default info)
                    InputBox.Buttons.OkCancel, //Set buttons (default ok)
                    InputBox.Type.ComboBox, //Set type (default nothing)
                    prioritiesLeft.ToArray(), //String field as ComboBox items (default null)
                    false, //Set visible in taskbar (default false)
                    new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular)); //Set font (default by system)

                //Check InputBox result
                if (res1 == System.Windows.Forms.DialogResult.OK || res1 == System.Windows.Forms.DialogResult.Yes)
                {
                    p3 = InputBox.ResultValue; //Get returned value
                    prioritiesLeft.Remove(p3);
                }


                switch (p1)
                {

                    case "Maximise Cost Efficiency": { this.p1 = 'C'; break; }
                    case "Maximise Power Efficiency": { this.p1 = 'P'; break; }
                    case "Maximise Space Efficiency": { this.p1 = 'S'; break; }
                    case "Maximise Performance": { this.p1 = 'M'; break; }
                    case "Minimise Initial Cost": { this.p1 = 'Q'; break; }

                }
                switch (p2)
                {
                    case "Maximise Cost Efficiency": { this.p2 = 'C'; break; }
                    case "Maximise Power Efficiency": { this.p2 = 'P'; break; }
                    case "Maximise Space Efficiency": { this.p2 = 'S'; break; }
                    case "Maximise Performance": { this.p2 = 'M'; break; }
                    case "Minimise Initial Cost": { this.p2 = 'Q'; break; }
                }
                switch (p3)
                {
                    case "Maximise Cost Efficiency": { this.p3 = 'C'; break; }
                    case "Maximise Power Efficiency": { this.p3 = 'P'; break; }
                    case "Maximise Space Efficiency": { this.p3 = 'S'; break; }
                    case "Maximise Performance": { this.p3 = 'M'; break; }
                    case "Minimise Initial Cost": { this.p3 = 'Q'; break; }
                }
            }
        }

        private string getPriorityString(char mode)
        {
            string msg = "";
            switch(mode) 
            {
                case 'C': { msg = "Maximise Cost Efficiency"; break;}
                case 'P': { msg = "Maximise Power Efficiency"; break; }
                case 'S': { msg = "Maximise Space Efficiency"; break; }
                case 'M': { msg = "Maximise Performance"; break; }
                case 'Q': { msg = "Minimise Initial Cost"; break; }

            }

            return msg;
        }

        private char getPriorityChar(string mode)
        {
            char msg = ' ';
            switch (mode)
            {
                case "Maximise Cost Efficiency": { msg = 'C'; break; }
                case "Maximise Power Efficiency": { msg = 'P'; break; }
                case "Maximise Space Efficiency": { msg = 'S'; break; }
                case "Maximise Performance": { msg = 'M'; break; }
                case "Minimise Initial Cost": { msg = 'Q'; break; }
            }
            return msg;
        }

        private void btn_reset_Click_1(object sender, EventArgs e)
        {
            txt_min_cpu_gflops.Clear();
            txt_min_gpu_tflops_sp.Clear();
            txt_min_gpu_tflops_dp.Clear();
            txt_min_ram.Clear();
            txt_min_vram.Clear();
            txt_ram_per_core.Clear();

            txt_total_budget.Clear();
            txt_monthly_power_budget.Clear();
            txt_max_power_delivery.Clear();
            txt_max_rack_power.Clear();
            txt_max_racks.Clear();

            txt_construction_cost.Clear();
            txt_daily_load_hours.Clear();
            txt_weekly_load_days.Clear();
            cmb_average_load_percent.SelectedIndex = -1;
            txt_electricity_cost.Clear();

            txt_log.Clear();
            txt_log.AppendText("Input Fields Cleared");
        }

        private void noResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_min_cpu_gflops.Text = "1024";
            txt_min_gpu_tflops_sp.Text = "128";
            txt_min_gpu_tflops_dp.Text = "64";
            txt_min_ram.Text = "512";
            txt_min_vram.Text = "256";
            txt_ram_per_core.Text = "4";

            txt_total_budget.Text = "100000";
            txt_monthly_power_budget.Text = "2000";
            txt_max_power_delivery.Text = "10000";
            txt_max_rack_power.Text = "2000";
            txt_max_racks.Text = "5";

            txt_construction_cost.Text = "10";
            txt_daily_load_hours.Text = "24";
            txt_weekly_load_days.Text = "6";
            cmb_average_load_percent.SelectedIndex = 0;
            txt_electricity_cost.Text = "0.5";
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_min_cpu_gflops.Text = "700000";
            txt_min_gpu_tflops_sp.Text = "400";
            txt_min_gpu_tflops_dp.Text = "150";
            txt_min_ram.Text = "512";
            txt_min_vram.Text = "512";
            txt_ram_per_core.Text = "4";

            txt_total_budget.Text = "500000";
            txt_monthly_power_budget.Text = "4000";
            txt_max_power_delivery.Text = "70000";
            txt_max_rack_power.Text = "10000";
            txt_max_racks.Text = "5";

            txt_construction_cost.Text = "10";
            txt_daily_load_hours.Text = "18";
            txt_weekly_load_days.Text = "5";
            cmb_average_load_percent.SelectedIndex = 3;
            txt_electricity_cost.Text = "0.2";
        }

        private void lotsOfResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txt_min_cpu_gflops.Text = "500000";
            txt_min_gpu_tflops_sp.Text = "300";
            txt_min_gpu_tflops_dp.Text = "100";
            txt_min_ram.Text = "1024";
            txt_min_vram.Text = "512";
            txt_ram_per_core.Text = "2";

            txt_total_budget.Text = "800000";
            txt_monthly_power_budget.Text = "5000";
            txt_max_power_delivery.Text = "80000";
            txt_max_rack_power.Text = "10000";
            txt_max_racks.Text = "10";

            txt_construction_cost.Text = "10";
            txt_daily_load_hours.Text = "18";
            txt_weekly_load_days.Text = "6";
            cmb_average_load_percent.SelectedIndex = 2;
            txt_electricity_cost.Text = "0.2";
        }

    }
}
