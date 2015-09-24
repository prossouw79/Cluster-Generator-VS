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

			return "Fix this method";
		}
	}
}

