using GalaSoft.MvvmLight.CommandWpf;
using ReportItemReader.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DocumentGenerator
{
    public class ApplicationViewModel : ObservableObject
    {
        #region Fields

        private RelayCommand<IPageViewModel> _changePageCommand;

        private IReportItemReader reader;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        #endregion

        public ApplicationViewModel()
        {
            reader = ReportitemReaderFactory.GetRepository();

            // Add available pages
            PageViewModels.Add(new ReportGeneratorViewModel(reader));
            PageViewModels.Add(new SettingsViewModel());
            PageViewModels.Add(new HomeViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Properties / Commands

        public RelayCommand<IPageViewModel> ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand<IPageViewModel>(
                        p => ChangeViewModel(p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
}
