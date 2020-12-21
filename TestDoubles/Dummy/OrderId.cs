namespace TestDoubles.Dummy
{
    public class OrderId
    {
        public readonly string Id;

        public OrderId(string id )
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            var other = (OrderId) obj;
            return this.Id == other.Id;
        }
    }
}