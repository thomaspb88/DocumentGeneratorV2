﻿namespace DocumentGenerator
{
    public class ReportComponentNull : IReportComponent
    {
        public ReportComponentType TypeOfComponent { get; set; } = ReportComponentType.Default;

        public string Text { get; set; } = "Error - Unable to read this component";
        public ComponentSetting Settings { get; set; }
    }
}
