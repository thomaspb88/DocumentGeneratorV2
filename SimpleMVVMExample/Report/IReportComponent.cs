namespace DocumentGenerator
{
    public interface IReportComponent
    {
        ReportComponentType TypeOfComponent { get; set; }

        ComponentSetting Settings { get; set; }
    }
}