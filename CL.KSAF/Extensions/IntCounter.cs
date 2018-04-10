namespace CL.KSAF.Extensions
{
    public struct IntCounter
    {
        public int Val;

        public IntCounter(int v)
        {
            Val = v;
        }

        public int Inc() =>
            Val = Val + 1;
    }
}