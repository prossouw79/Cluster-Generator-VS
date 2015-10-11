using System;
using System.Xml.Serialization;
namespace ClusterDesignTool
{
    [Serializable, XmlRoot("CPU"), XmlType("CPU")]
	public class cpu : component
	{
		int frequencyMhz;
		int instructionsPerCycle;
		int numOfCores;
        bool hyperthreaded;

        public cpu() : base("noname",0,0)
        {
            this.frequencyMhz = 0;
            this.instructionsPerCycle = 0;
            this.numOfCores = 0;
            this.hyperthreaded = false;
        }

		public cpu(int frequencyMhz, int instructionsPerCycle, int numOfCores, String componentName, Double componentCost, Double componentTDP, bool ht) : base (componentName, componentCost, componentTDP)
		{
			this.frequencyMhz = frequencyMhz;
			this.instructionsPerCycle = instructionsPerCycle;
			this.numOfCores = numOfCores;
            this.hyperthreaded = ht;
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

        public int getNumOfCores()
        {
                return numOfCores;
        }

		public void setNumOfCores(int numOfCores) {
			this.numOfCores = numOfCores;
		}

		public Double getComponentTDP() {
			return base.getComponentTDP();
		}

        public bool isHyperThreaded()
        {
            return hyperthreaded;
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
            string msg = Environment.NewLine + "Modelname:\t\t" + getComponentName() +
                        Environment.NewLine + "Frequency:\t\t" + getFrequencyMhz() +
                        Environment.NewLine + "Cores:\t\t\t" + getNumOfCores() +
                        Environment.NewLine + "Hyperthreaded:\t\t";
            if (hyperthreaded) msg += "YES - " + getNumOfCores() * 2 + " Threads" ;
            else if(getComponentName().Contains("AMD")) msg += "NA";
            else msg += "NO";


            return msg;
		}
	}
}