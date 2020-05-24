using Report.Components;
using System;
using System.Globalization;
using System.Windows.Data;

namespace DocumentGenerator
{
    [ValueConversion(typeof(ReportItemType),typeof(string))]
    public class TestReportItemTypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            var itemType = (ReportItemType)value;

            switch (itemType)
            {
                case ReportItemType.ProductStandard:
                    return "/Images/Icon_ProductStandard.png";
                case ReportItemType.TestStandard:
                    return "/Images/Icon_TestStandard.png";
                default:
                    return "/Images/Icon_QuestionMark.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
