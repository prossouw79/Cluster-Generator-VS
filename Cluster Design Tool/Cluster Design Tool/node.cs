using System;
using System.Collections.Generic;
namespace ClusterDesignTool
{
	public class node
	{
		int numOfCPUS;
		int numOfMems;
		int numOfGPUS;

		cpu cpuUsed;
		mem memUsed;
		gpu gpuUsed;

		List<cpu> cpus = new List<cpu>();
		List<gpu> gpus = new List<gpu>();
		List<mem> mems = new List<mem>();


		public node(int numOfCPUS, int numOfMems, int numOfGPUS, cpu cpuUsed, gpu gpuUsed, mem memUsed)
		{
			this.numOfCPUS = numOfCPUS;
			this.numOfMems = numOfMems;
			this.numOfGPUS = numOfGPUS;

			this.cpuUsed = cpuUsed;
			this.memUsed = memUsed;
			this.gpuUsed = gpuUsed;

			for (int k = 0; k < numOfCPUS; k++)
				cpus.Add(cpuUsed);

			for (int k = 0; k < numOfGPUS; k++)
				gpus.Add(gpuUsed);

			for (int k = 0; k < numOfMems; k++)
				mems.Add(memUsed);
		}

		public cpu getCpuUsed()
		{
			return cpuUsed;
		}
		public mem getMemUsed()
		{
			return memUsed;
		}
		public gpu getGpuUsed()
		{
			return gpuUsed;
		}

		public double getNodeMemory()
		{
			return numOfMems * memUsed.getCapacityGB ();
		}

		public double getNodeVideoMemory()
		{
			return numOfGPUS * gpuUsed.getVramGB ();
		}
			

		public Double calculateNodeCost()
		{
			Double total = 0.0;

			foreach (cpu c in cpus) 
				total += c.getComponentCost ();

			foreach (mem m in mems) 
				total += m.getComponentCost ();


			foreach (gpu g in gpus) 
				total += g.getComponentCost ();


			return total;     
		}


		public Double calculateNodeTDP() // in watts
		{
			Double total = 0.0;

			foreach (cpu c in cpus)
				total += c.getComponentTDP();

			foreach (mem m in mems)
				total += m.getComponentTDP();

			foreach (gpu g in gpus)
				total += g.getComponentTDP();

			return total; 
		}

		public Double calculateNodeCPUGFLOPS()
		{      
			Double total = 0.0;
			foreach (cpu c in cpus)
				total += c.calculateGFLOPS();
			return total;    
		}

		public Double calculate_node_sp_TFLOPS()
		{      
			Double total = 0.0;
			foreach (gpu g in gpus)
				total += g.getSpTFLOPS();
			return total; 
		}

		public Double calculate_node_dp_TFLOPS()
		{      
			Double total = 0.0;
			foreach (gpu g in gpus)
				total += g.getDpTFLOPS();
			return total; 
		}

		public string toString()
		{
			return 	numOfCPUS + " X " + cpuUsed.toString () + "\n" +
					numOfMems + " X " + memUsed.toString () + "\n" +
					numOfGPUS + " X " + gpuUsed.toString ();
		}
	}
}

