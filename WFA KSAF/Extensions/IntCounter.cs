namespace WFA.KSAF.Extensions
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
        
        public int ToInt() =>
            Val;
    }
}
