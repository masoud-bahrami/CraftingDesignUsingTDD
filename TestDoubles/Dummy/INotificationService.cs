namespace TestDoubles.Dummy
{
    public interface INotificationService
    {
        void SendSmsToCustomer(string mobileNumber, string message);
    }
}