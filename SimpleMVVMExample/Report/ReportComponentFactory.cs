using System;
using System.Xml;
using XmlNodeExtensionsMethods;

namespace DocumentGenerator
{
    public static class ReportComponentFactory
    {
        public static IReportComponent GetComponentFromXmlNode(XmlNode node)
        {

            string nameOfComponents = String.IsNullOrWhiteSpace(node.Name) ? "Null" : node.Name;
            string component = $"DocumentGenerator.ReportComponent{ nameOfComponents }, DocumentGenerator, Version = 1.0.0.0, Culture = neutral";
            Type componentType = Type.GetType(component);
            object type = Activator.CreateInstance(componentType);
            IReportComponent reportComponent = type as IReportComponent;


            var Attribute = node.HasAttributes() ? node.Attributes["type"].Value : node.Name;

            reportComponent.TypeOfComponent = Enum.TryParse(Attribute, out ReportComponentType typeComp) ? typeComp : ReportComponentType.Default;
            
            return reportComponent;
        }
    }
}
