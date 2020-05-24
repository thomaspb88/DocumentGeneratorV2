using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentGenerator
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        public HomeViewModel()
        {
        }
        public string Name
        {
            get
            {
                return "Home";
            }
        }
    }
}
