using System.Collections.Generic;
using LyncStatusChecker.SL.Model;
using LyncStatusChecker.SL.Model.Enum;
using Xunit;

namespace LyncStatusChecker.SL.Tests
{
    public class LyncStatusConversionTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void ShouldConvertIntToLyncStatusSuccessfully(int valueToConvert, LyncStatus expectedResult)
        {
            var result = valueToConvert.ToLyncStatus();
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[]
                {
                    2999,
                    LyncStatus.Offline
                };
                yield return new object[]
                {
                    18001,
                    LyncStatus.Offline
                };
                yield return new object[]
                {
                    3100,
                    LyncStatus.Available
                };
                yield return new object[]
                {
                    6100,
                    LyncStatus.Busy
                };
                yield return new object[]
                {
                    9500,
                    LyncStatus.DoNotDisturb
                };
                yield return new object[]
                {
                    13000,
                    LyncStatus.BeRightBack
                };
                yield return new object[]
                {
                    16000,
                    LyncStatus.Away
                };
            }
        }
    }
}