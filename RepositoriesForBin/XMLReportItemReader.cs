using Report.Component;
using Report.Components;
using ReportItemReader.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace ReportItemReader.XML
{

    public class XMLReportItemReader : IReportItemReader
    {
        public event EventHandler<NotificationEventArgs> Notification;
        public virtual void OnNotification(NotificationEventArgs e)
        {
            Notification?.Invoke(this, e);
        }

        private readonly XmlDocument xmlDocument = new XmlDocument();

        public ReportItemReaderState Status { get; set; }

        private string _directory;

        public string Directory
        {
            get { return _directory; }
            private set 
            { 
                _directory = value; 
                if (String.IsNullOrWhiteSpace(value) || !File.Exists(value))
                {
                    this.Status = ReportItemReaderState.Unknown;
                }
                else
                {
                    this.Status = ReportItemReaderState.Intialised;
                }
            }
        }
        
        public void Load(string directoryPath)
        {
            Directory = directoryPath;

            if (this.Status != ReportItemReaderState.Intialised)
            {
                OnNotification(new NotificationEventArgs()
                { 
                  Message = $"The file {directoryPath} cannot be found.", 
                  NotificationType = NotificationType.Exception }
                );
            }

            this.Status = ReportItemReaderState.Loaded;

            xmlDocument.Load(Directory);
        }

        public List<ReportComponentBody> GetAllReportItems()
        {
            List<ReportComponentBody> reportItems = new List<ReportComponentBody>();

            try
            {
                xmlDocument.Load(Directory);
                foreach(XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                {
                    var testReportItem = ParseToReportComponentBody(node);

                    reportItems.Add(testReportItem);
                }

                return reportItems;
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(string.Format("XmlException for test name: {0}", ex.Message));

                throw ex;
            }
        }

        private IReportComponent ReadXmlNode(XmlNode node)
        {
            try
            {
                var nodeName = node.Name;
                var componentType = Enum.TryParse(nodeName, out ReportComponentType type) ? type : ReportComponentType.Default;

                if (componentType == ReportComponentType.Body)
                {
                    return ParseToReportComponentBody(node);
                }

                return ParseToReportComponent(node);
            }
            catch (XmlException ex)
            {
                Debug.WriteLine(string.Format("XmlException for test name: {0}", ex.Message));

                throw ex;
            }
        }

        private static IReportComponent ParseToReportComponent(XmlNode node)
        {
            IReportComponent reportComponent = ReportComponentFactory.GetComponentFromXmlNode(node);

            IReportComponent intailisedReportComponent = PopulateReportComponent.ParseXmlNode(node, ref reportComponent);

            intailisedReportComponent.Settings = ComponentSettingsFactory.GetSetting(intailisedReportComponent);

            return intailisedReportComponent;
        }

        private ReportComponentBody ParseToReportComponentBody(XmlNode node)
        {
            var testReportBody = new ReportComponentBody();

            var reportItemType = node.GetAttributeValue("type");

            testReportBody.ReportItemType = Enum.TryParse(reportItemType, out ReportItemType reportType) ? reportType : ReportItemType.Null;

            foreach (XmlNode childNode in node.ChildNodes)
            {
                var reportItem = ReadXmlNode(childNode);
                testReportBody.ListOfComponents.Add(reportItem);
            }

            return testReportBody;
        }
    }
}
