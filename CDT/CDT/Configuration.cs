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
        public List<string> recommendation;

        public Configuration()
        {
            values = new List<string>();
            recommendation = new List<string>();
        }

        public void setValuesAndRecommendation(List<string> listIn,List<string> rec)
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

        public List<string> getRecommendation()
        {
            return recommendation;
        }

    }
}
