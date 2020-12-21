namespace TestDoubles.Fake
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}