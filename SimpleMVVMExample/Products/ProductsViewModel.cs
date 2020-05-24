using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace DocumentGenerator
{
    public class ProductsViewModel : ObservableObject, IPageViewModel
    {
        #region Fields

        private int _productId;
        private ProductModel _currentProduct;
        private ICommand _getProductCommand;
        private ICommand _saveProductCommand;

        #endregion

        #region Properties/Commands

        public string Name
        {
            get { return "Products"; }
        }

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (value != _productId)
                {
                    _productId = value;
                    OnPropertyChanged("ProductId");
                }
            }
        }

        public ProductModel CurrentProduct
        {
            get { return _currentProduct; }
            set
            {
                if (value != _currentProduct)
                {
                    _currentProduct = value;
                    OnPropertyChanged("CurrentProduct");
                }
            }
        }

        public ICommand GetProductCommand
        {
            get
            {
                if (_getProductCommand == null)
                {
                    _getProductCommand = new RelayCommand(
                        () => GetProduct(),
                        () => ProductId > 0
                    );
                }
                return _getProductCommand;
            }
        }

        public ICommand SaveProductCommand
        {
            get
            {
                if (_saveProductCommand == null)
                {
                    _saveProductCommand = new RelayCommand(
                        () => SaveProduct(),
                        () => (CurrentProduct != null)
                    );
                }
                return _saveProductCommand;
            }
        }

        #endregion

        #region Methods

        private void GetProduct()
        {
            // Usually you'd get your Product from your datastore,
            // but for now we'll just return a new object
            ProductModel p = new ProductModel
            {
                ProductId = ProductId,
                ProductName = "Test Product",
                UnitPrice = 10
            };
            CurrentProduct = p;
        }

        private void SaveProduct()
        {
            // You would implement your Product save here
        }

        #endregion
    }
}
