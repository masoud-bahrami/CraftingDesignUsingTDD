using System;
using Xunit;

namespace TestDoubles.Stub
{
    public class DateTimeServiceTests
    {
        [Fact]
        public void TestMorningFormat()
        {
            var sut = DateTimeServiceStub.WhichReturnMorning();

            var result = sut.GetTimeOfTheCurrentDate();

            Assert.Equal("قبل از ظهر", result);
        }

        [Fact]
        public void TestNightFormat()
        {
            var sut = new DateTimeServiceStub(13);

            var result = sut.GetTimeOfTheCurrentDate();

            Assert.Equal("بعد از ظهر", result);
        }
    }
}