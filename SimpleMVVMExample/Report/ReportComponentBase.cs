namespace DocumentGenerator
{
    public class ReportComponentBase : IReportComponent
    {
        public virtual ReportComponentType TypeOfComponent { get; set; } = ReportComponentType.Default;
        public virtual ComponentSetting Settings { get; set; } = new ComponentSetting();
    }
}
