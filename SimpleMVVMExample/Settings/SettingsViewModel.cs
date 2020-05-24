using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentGenerator
{
    public class SettingsViewModel : ObservableObject, IPageViewModel
    {
		public RelayCommand SaveSettingsCommand { get; private set; }

		public SettingsViewModel()
		{
			SaveSettingsCommand = new RelayCommand(() => ExecutSaveSettingsCommand(), () => true);
		}
        public string Name { get; private set; } = "Settings";

		public string ReportTemplatePath
		{
			get { return Properties.Settings.Default.templateDoc; }
			set 
			{ 
				Properties.Settings.Default.templateDoc = value;
				OnPropertyChanged(nameof(ReportTemplatePath));
			}
		}

		public List<string> DataSourceTypes
		{
			get { return Properties.Settings.Default.dataSourceTypes; }
			private set	{ Properties.Settings.Default.dataSourceTypes = value; }
		}

		public List<string> CurrentDataSourceTypes
		{
			get { return Properties.Settings.Default.dataSourceTypes; }
			private set { Properties.Settings.Default.dataSourceTypes = value; }
		}

		public string DataSourceFilePath
		{
			get { return Properties.Settings.Default.testReportItemList; }
			set { Properties.Settings.Default.testReportItemList = value;
				  OnPropertyChanged("DataSourceFilePath"); }
		}

		private void ExecutSaveSettingsCommand()
		{
			if (DataSourceFilePath != null) { Properties.Settings.Default.Save(); }
		}

	}
}
