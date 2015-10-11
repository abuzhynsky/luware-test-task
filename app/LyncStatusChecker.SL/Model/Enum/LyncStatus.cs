using System.ComponentModel;

namespace LyncStatusChecker.SL.Model.Enum
{
    public enum LyncStatus
    {
        [Description("Unknown")]
        Unknown,
        [Description("Offline")]
        Offline,
        [Description("Available")]
        Available,
        [Description("Busy")]
        Busy,
        [Description("Do not disturb")]
        DoNotDisturb,
        [Description("Be right back")]
        BeRightBack,
        [Description("Away")]
        Away
    }
}