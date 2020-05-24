using System.Collections.Generic;

namespace DocumentGenerator
{
    public class ReportComponentTable : ReportComponentBase
    {
        public List<string> Titles { get; set; } = new List<string>();

        public int ColumnCount 
        { 
            get 
            {
                return Titles.Count;
            }
            private set 
            { 
            } 
        }

    }
}