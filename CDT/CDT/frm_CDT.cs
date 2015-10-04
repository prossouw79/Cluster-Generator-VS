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

        List<int> nodesInRack = new List<int>();
        List<int> cpusInNode = new List<int>();
        List<int> memsInNode = new List<int>();
        List<int> gpusInNode = new List<int>();

        int viableClusterCount = 0;

        char p1, p2, p3;

        Boolean readyToGenerateClusters = false;
        Boolean doneGeneratingCluster = false;

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

            cpusInNode.Add(1); cpusInNode.Add(2); cpusInNode.Add(3); cpusInNode.Add(4);
            memsInNode.Add(2); memsInNode.Add(4); memsInNode.Add(8);
            gpusInNode.Add(0); gpusInNode.Add(1); gpusInNode.Add(2); gpusInNode.Add(4);
            nodesInRack.Add(4); nodesInRack.Add(8); nodesInRack.Add(16); nodesInRack.Add(24);

            priorities.Add("Maximise Cost Efficiency"); priorities.Add("Maximise Power Efficiency"); priorities.Add("Maximise Space Efficiency");
            prioritiesLeft = priorities;

            Thread init = new Thread(new ThreadStart(this.initializationMethod));
            init.Start();
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

            for (int k = (int)max_racks; k >= 1; k--)
            {
                if (zeroResultCount < 3)
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
                }
                else
                {
                    ended = true;
                }
                    prg_1.Value = Math.Abs(prg_1.Maximum - (k * step));
                    int clustersOfThisSize = viableClusters.Count - clustersSoFar;

                    if (clustersOfThisSize == 0)
                        zeroResultCount++;
                    else
                        zeroResultCount = 0;

                    txt_log.AppendText(Environment.NewLine + "Viable Clusters of size " + k + ":\t" + clustersOfThisSize);
                    clustersSoFar = viableClusters.Count;
                }
                prg_1.Value = prg_1.Maximum;
                if (viableClusters.Count == 1)
                {
                    bestCluster = viableClusters.ElementAt(0);
                }
                else if (viableClusters.Count > 1)
                {
                    txt_log.AppendText(Environment.NewLine + "Multiple(" + viableClusters.Count + ") viable solutions have been found, to get the best one for your needs we need to identify your priorities." +
                                    "Select your primary and secondary priorities from the lists that follow. Press OK to Continue.");
                    setPriorities();

                    ConcurrentBag<cluster> tmpList = binaryFilter(viableClusters, p1);

                    int cnt = 0;
                    while (tmpList.Count > 1)
                    {
                        tmpList = binaryFilter(tmpList, p1); txt_log.AppendText(Environment.NewLine + "Step " + ++cnt + " : " + +tmpList.Count);
                        tmpList = binaryFilter(tmpList, p1); txt_log.AppendText(Environment.NewLine + "Step " + ++cnt + " : " + +tmpList.Count);
                        tmpList = binaryFilter(tmpList, p1); txt_log.AppendText(Environment.NewLine + "Step " + ++cnt + " : " + +tmpList.Count);

                        tmpList = binaryFilter(tmpList, p2); txt_log.AppendText(Environment.NewLine + "Step " + ++cnt + " : " + +tmpList.Count);
                        tmpList = binaryFilter(tmpList, p2); txt_log.AppendText(Environment.NewLine + "Step " + ++cnt + " : " + +tmpList.Count);

                        tmpList = binaryFilter(tmpList, p3); txt_log.AppendText(Environment.NewLine + "Step " + ++cnt + " : " + +tmpList.Count);
                    }

                    bestCluster = tmpList.ElementAt(0);
                    txt_log.Text = bestCluster.getDetails();

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

                        cpu tmp = new cpu(frequencyMhz, instructionsPerCycle, numOfCores, componentName, componentCost, componentTDP);
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

               /* string msg = "";

                foreach (cpu c in theCPUS)
                    msg += c.toString();
                foreach (gpu g in theGPUS)
                    msg += g.toString();
                foreach (mem m in theMems)
                    msg += m.toString();

                MessageBox.Show(msg);*/

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
                    txt_log.AppendText(Environment.NewLine + Environment.NewLine + System.DateTime.Now.ToLongTimeString() + " -> Generation Started: ");
                    long start = CurrentTimeSeconds();

                    generateViableClusters();
                    long secondsTaken = CurrentTimeSeconds() - start;
                    if (viableClusters.Count > 0)
                        txt_log.AppendText(Environment.NewLine + "Generation took: " + secondsTaken + " seconds.");


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
            string p1, p2, p3;
            p1 = p2 = p3 = "unsassigned";

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

            p3 = prioritiesLeft.ElementAt(0);

            switch (p1)
            {
                case "Maximise Cost Efficiency": { this.p1 = 'C'; break; }
                case "Maximise Power Efficiency": { this.p1 = 'P'; break; }
                case "Maximise Space Efficiency": { this.p1 = 'S'; break; }
            }
            switch (p2)
            {
                case "Maximise Cost Efficiency": { this.p2 = 'C'; break; }
                case "Maximise Power Efficiency": { this.p2 = 'P'; break; }
                case "Maximise Space Efficiency": { this.p2 = 'S'; break; }
            }
            switch (p3)
            {
                case "Maximise Cost Efficiency": { this.p3 = 'C'; break; }
                case "Maximise Power Efficiency": { this.p3 = 'P'; break; }
                case "Maximise Space Efficiency": { this.p3 = 'S'; break; }
            }
        }

        private void btn_reset_Click_1(object sender, EventArgs e)
        {

        }

    }
}
