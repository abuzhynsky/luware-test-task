using System.Windows.Media;

namespace LyncStatusChecker.SL.ViewModel.Converter
{
    public static class Colors
    {
        public static Color Gray
        {
            get { return Color.FromArgb(255, 128, 128, 128); }
        }

        public static Color Yellow
        {
            get { return Color.FromArgb(255, 255, 255, 000); }
        }

        public static Color Red
        {
            get { return Color.FromArgb(255, 255, 000, 000); }
        }

        public static Color Green
        {
            get { return Color.FromArgb(255, 000, 255, 000); }
        }
    }
}