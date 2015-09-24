using System;

namespace ClusterDesignTool
{
	public class gpu : component
	{
		private Double vramGB;
		private Double spTFLOPS;
		private Double dpTFLOPS;

		public gpu(Double vramGB, Double sfpTFLOPS, Double dfpTFLOPS, String componentName, Double componentCost, Double componentTDP) : base(componentName,componentCost,componentTDP)
		{
			this.vramGB = vramGB;
			this.spTFLOPS = sfpTFLOPS;
			this.dpTFLOPS = dfpTFLOPS;
		}

		public Double getDpTFLOPS() {
			return dpTFLOPS;
		}

		public void setDpTFLOPS(Double dpTFLOPS) {
			this.dpTFLOPS = dpTFLOPS;
		}

		public Double getVramGB() {
			return vramGB;
		}

		public void setVramGB(Double vramGB) {
			this.vramGB = vramGB;
		}

		public Double getSpTFLOPS() {
			return spTFLOPS;
		}

		public void setSpTFLOPS(Double spTFLOPS) {
			this.spTFLOPS = spTFLOPS;
		}

		public string toString()
		{
            return  Environment.NewLine + "Model:\t\t\t" + getComponentName() +
                    Environment.NewLine + "Single Precision TFLOPS:\t" + getSpTFLOPS() +
                    Environment.NewLine + "Double Precision TFLOPS:\t " + getDpTFLOPS() +
                     Environment.NewLine +"Video Memory:\t\t"+ getVramGB();
		}
	}
}

