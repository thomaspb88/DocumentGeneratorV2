﻿using System;
using System.Xml;

namespace Report.Components
{
    public static class ReportComponentFactory
    {
        public static IReportComponent GetComponentFromXmlNode(XmlNode node)
        {
            string nameOfComponents = String.IsNullOrWhiteSpace(node.Name) ? "Null" : node.Name;
            string component = $"Report.Components.ReportComponent{ nameOfComponents }, Report.Components, Version = 1.0.0.0, Culture = neutral";
            Type componentType = Type.GetType(component);
            object type = Activator.CreateInstance(componentType);
            IReportComponent testreportComponent = type as IReportComponent;
            return testreportComponent;
        }
    }
}
