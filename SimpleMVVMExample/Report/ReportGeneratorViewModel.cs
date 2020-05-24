using GalaSoft.MvvmLight.Command;
using Report.Components;
using ReportItemReader.Interface;
using System.Collections.ObjectModel;

namespace DocumentGenerator
{
    public class ReportGeneratorViewModel : ObservableObject, IPageViewModel

    {
        //IReportItemReader repo = ReportItemReaderFactory.GetRepository();
        protected IReportItemReader DataReader;

        #region Property - Test List for Combobox

        public ObservableCollection<ReportComponentBody> TestList
        {
            get 
            {
                if (DataReader.Status == ReportItemReaderState.Loaded)
                {
                    return new ObservableCollection<ReportComponentBody>(DataReader.GetAllReportItems());
                }
                else
                {
                    return new ObservableCollection<ReportComponentBody>()
                    {
                       new ReportComponentBody(){ Title = "Error - Something went wrong" }
                    };
                }
            }

            private set { }
        }

        #endregion

        #region Property - Chosen Test List
        private ObservableCollection<ReportComponentBody> _chosenTests;

        public ObservableCollection<ReportComponentBody> ChosenTests
        {
            get 
            {
                return _chosenTests;
            }
            set
            {
                _chosenTests = value;
            }
        }
        #endregion

        #region Property - Selected Test on Combobox
        private ReportComponentBody _selectedTest;

        public ReportComponentBody SelectedTest
        {
            get { return _selectedTest; }
            set 
            { 
                _selectedTest = value;
                RaisePropertyChanged("SelectedTest");
            }
        }
        #endregion

        #region Property - Selected Test on ListBox
        private ReportComponentBody _selectedListItem;

        public ReportComponentBody SelectedListItem
        {
            get { return _selectedListItem; }
            set
            {
                _selectedListItem = value;
                RaisePropertyChanged("SelectedListItem");
            }
        }

        #endregion

        #region Property - Customer

        private string _customer;

        public string Customer
        {
            get { return _customer; }
            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    RaisePropertyChanged("Customer");
                }
            }
        }

        #endregion

        #region Property - Project

        private string _project;

        public string Project
        {
            get { return _project; }
            set 
            { 
                _project = value;
                RaisePropertyChanged("Project");
            }
        }

        #endregion

        #region Property - Address
        private string _address;

        public string Address
        {
            get { return _address; }
            set 
            { 
                _address = value;
                RaisePropertyChanged("Address");
            }
        }
        #endregion

        #region Property - Report Title
        private string _reportTitle;

        public string ReportTitle
        {
            get { return _reportTitle; }
            set 
            { 
                _reportTitle = value;
                RaisePropertyChanged("ReportTitle");
            }
        }
        #endregion

        public string FileDirectoryPath
        {
            get { return Properties.Settings.Default.testReportItemList; }
            set { Properties.Settings.Default.testReportItemList = value; }
        }

        #region Constructor - ReportGeneratorViewModel

        public ReportGeneratorViewModel(IReportItemReader reader)
        {
            DataReader = reader;
            DataReader.Load(FileDirectoryPath);

            _chosenTests = new ObservableCollection<ReportComponentBody>();
            AddToListCommand = new RelayCommand(() => ExecuteAddTestsToListCommand(), () => CanExecuteAddToListCommand());
            RemoveTestCommand = new RelayCommand(() => ExecuteRemoveFromListCommand(), () => CanExecuteRemoveFromListCommand());
            CreateReportCommand = new RelayCommand(() => ExecuteCreateReportCommand(), () => CanExecuteCreateReportCommand());
        }
        #endregion

        public RelayCommand AddToListCommand { get; private set; }
        public RelayCommand RemoveTestCommand { get; private set; }
        public RelayCommand CreateReportCommand { get; private set; }

        public string Name => "Report";

        #region RelayCommand : AddToListCommand -  Execute and CanExecute
        private void ExecuteAddTestsToListCommand()
        {
            if (!_chosenTests.Contains(SelectedTest))
            { this._chosenTests.Add(SelectedTest); }
        }

        private bool CanExecuteAddToListCommand()
        {
            if(SelectedTest != null)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region RelayCommand : RemoveTestsCommand -  Execute and CanExecute
        private void ExecuteRemoveFromListCommand()
        {
            if (_chosenTests.Contains(SelectedListItem))
            { this._chosenTests.Remove(SelectedListItem); }
        }

        private bool CanExecuteRemoveFromListCommand()
        {
            if (SelectedTest != null)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region RelayCommand : CreateReportCommand -  Execute and CanExecute
        private void ExecuteCreateReportCommand()
        {
            if (DataReader.Status != ReportItemReaderState.Unknown && ChosenTests.Count != 0)
            {
                TestReport testReport = new TestReport(); ;
                testReport.OpenDocument(Properties.Settings.Default.templateDoc)
;               testReport.LoadReportItems(ChosenTests);
                testReport.WriteReport();
                testReport.ReplaceWord("<<Customer>>", Customer);
                testReport.ReplaceWord("<<Address>>", Address.Replace("\n", ""));
                testReport.ReplaceWord("<<Project>>", Project);
                testReport.ReplaceWord("<<Title>>", ReportTitle);
            }
        }

        private bool CanExecuteCreateReportCommand()
        {
            return TestList.Count != 0 
                && DataReader.Status != ReportItemReaderState.Unknown;
        }
        #endregion
    }
}
