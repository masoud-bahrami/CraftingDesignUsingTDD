using System;

namespace TestDoubles.Stub
{
    public class DateTimeService
    {
        internal string GetTimeOfTheCurrentDate()
        {
            var hour = CurrentDateHour();

            return hour < 12
                ? "قبل از ظهر"
                : hour < 13
                    ? "ظهر" : "بعد از ظهر";
        }

        protected virtual int CurrentDateHour()
        {
            return System.DateTime.Now.Hour;
        }
    }

    public class DateTimeServiceStub : DateTimeService
    {
        private readonly int _hour;

        public DateTimeServiceStub(int hour) => _hour = hour;

        public static DateTimeServiceStub WhichReturnMorning()=>new DateTimeServiceStub(10);

        protected override int CurrentDateHour() => _hour;
    }
}
