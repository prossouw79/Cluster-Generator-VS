﻿using System;

namespace ClusterDesignTool
{
	public class cpu : component
	{
		int frequencyMhz;
		int instructionsPerCycle;
		int numOfCores;

		public cpu(int frequencyMhz, int instructionsPerCycle, int numOfCores, String componentName, Double componentCost, Double componentTDP) : base (componentName, componentCost, componentTDP)
		{
			this.frequencyMhz = frequencyMhz;
			this.instructionsPerCycle = instructionsPerCycle;
			this.numOfCores = numOfCores;
		}

		public int getFrequencyMhz() {
			return frequencyMhz;
		}

		public void setFrequencyMhz(int frequencyMhz) {
			this.frequencyMhz = frequencyMhz;
		}

		public int getInstructionsPerCycle() {
			return instructionsPerCycle;
		}

		public void setInstructionsPerCycle(int instructionsPerCycle) {
			this.instructionsPerCycle = instructionsPerCycle;
		}

		public int getNumOfCores() {
			return numOfCores;
		}

		public void setNumOfCores(int numOfCores) {
			this.numOfCores = numOfCores;
		}

		public Double getComponentTDP() {
			return base.getComponentTDP();
		}

		public String getComponentName() {
			return base.getComponentName();
		}

		public Double getComponentCost() {
			return base.getComponentCost();
		}

		public Double calculateGFLOPS()
		{        
			return (getFrequencyMhz()/1000) * this.numOfCores * this.instructionsPerCycle * this.numOfCores;
		}


		public string toString()
		{
			return 		getComponentName () + " - " + getComponentCost() + " - " + getComponentTDP ()
			+ " - " + getFrequencyMhz () + " - " + getNumOfCores () + " - " + getInstructionsPerCycle ();
		}
	}
}