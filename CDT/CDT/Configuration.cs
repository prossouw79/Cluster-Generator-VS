using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ClusterDesignTool;

namespace CDT
{
    [Serializable, XmlRoot("Configuration"), XmlType("Configuration")]
    public class Configuration
    {
        [XmlArray("ClusterFile")]
        public List<string> values;
        public string recommendation;

        public Configuration()
        {
            values = new List<string>();
            recommendation = "";
        }

        public void setValuesAndRecommendation(List<string> listIn,string rec)
        {
            values = listIn;
            recommendation = rec;
        }

        public void setValues(List<string> listIn)
        {
            values = listIn;
        }

        public List<string> getValues()
        {
            return values;
        }

        public string getRecommendation()
        {
            return recommendation;
        }

    }
}
