using System;

namespace TestDoubles.TestSpecific
{
    public class TimeProvider
    {
        public string TimeOfCurrentDate()
        {
            DateTime now =GetDateTime();

            if (now.Hour < 12)
                return "صبح";
            if (now.Hour < 13)
                return "ظهر";
            if (now.Hour < 18)
                return "عصر";
            return "شب";
        }

        protected virtual DateTime GetDateTime()
        {
            throw new NotImplementedException();
        }
    }
}
