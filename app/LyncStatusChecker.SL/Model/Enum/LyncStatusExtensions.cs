using System;

namespace LyncStatusChecker.SL.Model.Enum
{
    public static class LyncStatusExtensions
    {
        public static LyncStatus ToLyncStatus(this int state)
        {
            if (state < 3000 || state > 18000)
            {
                return LyncStatus.Offline;
            }

            if (state >= 3000 && state < 6000)
            {
                return LyncStatus.Available;
            }

            if (state >= 6000 && state < 9000)
            {
                return LyncStatus.Busy;
            }

            if (state >= 9000 && state < 12000)
            {
                return LyncStatus.DoNotDisturb;
            }

            if (state >= 12000 && state < 15000)
            {
                return LyncStatus.BeRightBack;
            }

            if (state >= 15000 && state < 18000)
            {
                return LyncStatus.Away;
            }

            throw new ArgumentOutOfRangeException(nameof(state));
        }
    }
}