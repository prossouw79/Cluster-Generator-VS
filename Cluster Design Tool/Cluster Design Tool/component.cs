using System;

namespace ClusterDesignTool
{
	public class component
	{ 
		private String componentName;
		private Double componentCost;
		private Double componentTDP;

		public component(String componentName, Double componentCost, Double componentTDP) {
			this.componentName = componentName;
			this.componentCost = componentCost;
			this.componentTDP = componentTDP;
		}

		public Double getComponentTDP() {
			return componentTDP;
		}

		public void setComponentTDP(Double componentTDP) {
			this.componentTDP = componentTDP;
		}

		public String getComponentName() {
			return componentName;
		}

		public void setComponentName(String componentName) {
			this.componentName = componentName;
		}

		public Double getComponentCost() {
			return componentCost;
		}

		public void setComponentCost(Double componentCost) {
			this.componentCost = componentCost;
		}
	}
}

