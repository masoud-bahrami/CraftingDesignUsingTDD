namespace TDD.Samples.Doubles
{
    internal interface IHiLoService
    {
        int GenerateNeKey();
    }

    internal class HiloService : IHiLoService
    {
        private static int _nextId = 0;
        public int GenerateNeKey()
        {
            return ++_nextId;
        }
    }
}