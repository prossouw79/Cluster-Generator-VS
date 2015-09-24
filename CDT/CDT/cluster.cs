using System;
using System.Collections.Generic;
namespace ClusterDesignTool
{
	public class cluster
	{
		List<rack> racks = new List<rack>();
		int numOfRacks;
		rack rackUsed;

		public cluster(int numOfRacks, rack rackUsed) {
			this.numOfRacks = numOfRacks;
			this.rackUsed = rackUsed;

			for (int k = 0; k < numOfRacks; k++) {
				racks.Add (rackUsed);
			}
		}

		public rack getRackUsed()
		{
			return rackUsed;
		}

		public Double getClusterCost()
		{
			Double total = 0.0;
			foreach(rack r in racks)
				total += r.getRackCost();

			return total;
		}

		public Double getClusterTDP() //in watts
		{
			Double total = 0.0;
			foreach(rack r in racks)
				total += r.getRackTDP();

			return total;
		}

		public Double getClusterRAM()
		{
			Double total = 0.0;
			foreach(rack r in racks)
				total += r.getRackRAM();

			return total;
		}

        public int getNumberOfCores()
        {
            int i = 0;
            foreach (rack r in racks)
                i += r.getNumberOfCores();

            return i;
        }

        public Double getRAMperCore()
        {
            return getNumberOfCores() / getClusterRAM();
        }

		public Double getClusterVRAM()
		{
			Double total = 0.0;
			foreach(rack r in racks)
				total += r.getRackVRAM();

			return total;
		}
			

		public Double getClusterCPUGFLOPS()
		{
			Double total = 0.0;
			foreach(rack r in racks)
				total += r.getRackCPUGFLOPS();

			return total;
		}

		public Double getClusterGPUTFLOPS_sp()
		{
			Double total = 0.0;
			foreach(rack r in racks)
				total += r.getRackGPUTFLOPS_sp();

			return total;
		}

		public Double getClusterGPUTFLOPS_dp()
		{
			Double total = 0.0;
			foreach(rack r in racks)
				total += r.getRackGPUTFLOPS_dp();

			return total;
		}

		public Double getPerformance_to_Cost_ratio()//cost efficiency
		{
			return (getClusterCPUGFLOPS() + (getClusterGPUTFLOPS_sp() * 1000) + (getClusterGPUTFLOPS_dp() * 1000))/getClusterCost();
		}

		public Double getPerformance_to_Space_ratio() //space efficiency
		{
			return (getClusterCPUGFLOPS() + (getClusterGPUTFLOPS_sp() * 1000) + (getClusterGPUTFLOPS_dp() * 1000))/numOfRacks;
		}

		public Double getPerformance_to_Power_Usage() //power efficiency
		{
			return (getClusterCPUGFLOPS() + (getClusterGPUTFLOPS_sp() * 1000) + (getClusterGPUTFLOPS_dp() * 1000))/getClusterTDP();
		}

		public string getDetails()
		{
            string msg =                 "===========CLUSTER SOLUTION===========";
            msg += Environment.NewLine + "Cluster size:\t\t" + numOfRacks + " Racks";
            msg += Environment.NewLine + "Rack Details:\t" + rackUsed.toString();;
            msg += Environment.NewLine + "============SPECIFICATIONS============";
            msg += Environment.NewLine + "TOTAL CPU PEAK PERFORMANCE:\t" + getClusterCPUGFLOPS() + "\t GFLOPS";
            msg += Environment.NewLine + "TOTAL GPU SP PEAK PERFORMANCE:\t" + getClusterGPUTFLOPS_sp() + "\t TFLOPS";
            msg += Environment.NewLine + "TOTAL GPU DP PEAK PERFORMANCE:\t" + getClusterGPUTFLOPS_dp() + "\t TFLOPS";
            msg += Environment.NewLine + "TOTAL RAM (GB):\t\t\t" + getClusterRAM() + "\t GB";
            msg += Environment.NewLine + "TOTAL RAM PER CORE (GB):\t\t" + getRAMperCore() + "\t GB";
            msg += Environment.NewLine + "TOTAL VRAM (GB):\t\t\t" + getClusterVRAM() + "\t GB";
            msg += Environment.NewLine + "=============REQUIREMENTS=============";

            double clustertdp = getClusterTDP();
            double racktdp = rackUsed.getRackTDP();

            if (clustertdp > 0 && clustertdp < 1000)//print in W
            {
                msg += Environment.NewLine + "TOTAL POWER DRAW:\t\t" + clustertdp+ "\t W";
                msg += Environment.NewLine + "RACK POWER DRAW:\t\t" + racktdp + "\t W";
            }
            else 
            if(clustertdp > 1000 && clustertdp < 1000000)//print in KW
            {
                msg += Environment.NewLine + "TOTAL POWER DRAW:\t\t" + clustertdp / 1000 + "\t KW";
                msg += Environment.NewLine + "RACK POWER DRAW:\t\t" + racktdp / 1000 + "\t KW";
            }
            else //print in GW
            {
                msg += Environment.NewLine + "TOTAL POWER DRAW:\t\t" + clustertdp / 1000000 + "\t GW";
                msg += Environment.NewLine + "RACK POWER DRAW:\t\t" + racktdp / 1000000 + "\t GW";
            }


            msg += Environment.NewLine + "TOTAL INITIAL COST:\t\t" + getClusterCost() + "\t USD"; 
			return msg;
		}
	}
}

