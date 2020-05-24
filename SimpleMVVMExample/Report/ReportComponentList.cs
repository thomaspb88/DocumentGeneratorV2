using System.Collections.Generic;


namespace DocumentGenerator
{
    public class ReportComponentList : ReportComponentBase
    {
        public override ReportComponentType TypeOfComponent { get; set; } = ReportComponentType.List;

        public override ComponentSetting Settings { get; set; } = new ComponentSetting();

        public List<string> Text { get; set; } = new List<string>();
    }

}