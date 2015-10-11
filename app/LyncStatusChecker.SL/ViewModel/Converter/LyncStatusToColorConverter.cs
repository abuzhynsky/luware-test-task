using System;
using System.Globalization;
using System.Windows.Data;
using LyncStatusChecker.SL.Model.Enum;

namespace LyncStatusChecker.SL.ViewModel.Converter
{
    public class LyncStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = value is LyncStatus ? (LyncStatus) value : LyncStatus.None;

            switch (status)
            {
                case LyncStatus.None:
                case LyncStatus.Offline:
                    return Colors.Gray;
                case LyncStatus.Available:
                    return Colors.Green;
                case LyncStatus.Busy:
                case LyncStatus.DoNotDisturb:
                    return Colors.Red;
                case LyncStatus.BeRightBack:
                case LyncStatus.Away:
                    return Colors.Yellow;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}