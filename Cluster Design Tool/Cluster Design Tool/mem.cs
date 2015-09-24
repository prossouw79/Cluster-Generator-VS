using System;

namespace ClusterDesignTool
{
	public class mem : component
	{
		private int capacityGB;
		private int frequencyMhz;

		public mem(int capacityGB, int frequencyMhz, String componentName, Double componentCost, Double componentTDP) : base (componentName,componentCost,componentTDP) {
			this.capacityGB = capacityGB;
			this.frequencyMhz = frequencyMhz;
		}

		public int getFrequencyMhz() {
			return frequencyMhz;
		}

		public void setFrequencyMhz(int frequencyMhz) {
			this.frequencyMhz = frequencyMhz;
		}

		public int getCapacityGB() {
			return capacityGB;
		}

		public void setCapacityGB(int capacityGB) {
			this.capacityGB = capacityGB;
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

		public string toString()
		{
			return 		getComponentName () + " - " + getComponentCost () + " - " + getComponentTDP ()
			+ " - " + getFrequencyMhz () + " - " + getCapacityGB ();
		}

	}
}

