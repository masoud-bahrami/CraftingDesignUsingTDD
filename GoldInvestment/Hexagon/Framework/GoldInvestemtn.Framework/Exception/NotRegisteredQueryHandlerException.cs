using System;

namespace GoldInvestment.ApplicationService
{
    public class NotRegisteredQueryHandlerException<T> : Exception
    where  T :IQuery
    {
    }
}