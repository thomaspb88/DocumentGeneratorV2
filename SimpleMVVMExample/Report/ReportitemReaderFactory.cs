using ReportItemReader.Interface;
using System;
using System.Configuration;

namespace DocumentGenerator
{
    public static class ReportitemReaderFactory
    {
        public static IReportItemReader GetRepository()
        {
            string repoType = Properties.Settings.Default.currentDataSourceType;
            Type repositoryType = Type.GetType(repoType);
            object repository = Activator.CreateInstance(repositoryType);
            IReportItemReader reportitemRepository = repository as IReportItemReader;
            return reportitemRepository;
        }
    }
}
