using System;
using System.Collections.Generic;
namespace ClusterDesignTool
{
	public class rack
	{
		List<node> nodes = new List<node>();
		int numOfNodes;
		node nodeUsed;

		public rack(int numOfNodes, node nodeUsed)
		{
			this.numOfNodes = numOfNodes;
			this.nodeUsed = nodeUsed;

			for(int k = 0; k < this.numOfNodes; k++)
			{
				nodes.Add(nodeUsed);
			}
		}

		public int getNumOfNodes() {
			return numOfNodes;
		}

		public node getNodeUsed() {
			return nodeUsed;
		}

		public Double getRackCost()
		{
			Double total = 0.0;
			foreach(node n in nodes)
				total += n.calculateNodeCost();

			return total;
		}

		public Double getRackTDP() //in watts
		{
			Double total = 0.0;
			foreach(node n in nodes)
				total += n.calculateNodeTDP();

			return total;
		}

        public int getNumberOfCores()
        {
            int i = 0;
            foreach (node n in nodes)
                i += n.getNumberOfCores();

            return i;
        }

        public Double getRAMperCore()
        {
            return getNumberOfCores() / getRackRAM();
        }

		public Double getRackCPUGFLOPS()
		{
			Double total = 0.0;

			foreach(node n in nodes)
				total += n.calculateNodeCPUGFLOPS();

			return total;
		}

		public Double getRackGPUTFLOPS_sp()
		{
			Double total = 0.0;
			foreach(node n in nodes)
				total += n.calculate_node_sp_TFLOPS();

			return total;
		}

		public Double getRackGPUTFLOPS_dp()
		{
			Double total = 0.0;
			foreach(node n in nodes)
				total += n.calculate_node_dp_TFLOPS();

			return total;
		}

		public double getRackRAM()
		{
			Double total = 0.0;
			foreach (node n in nodes)
				total += n.getNodeMemory ();

			return total;
		}
			

		public double getRackVRAM()
		{
			Double total = 0.0;
			foreach (node n in nodes)
				total += n.getNodeVideoMemory ();

			return total;
		}

		public string toString()
		{
			return getNumOfNodes () + " Nodes per Rack ;" +Environment.NewLine+"Node Specifications:" + Environment.NewLine + getNodeUsed ().toString ();
		}
	}
}

