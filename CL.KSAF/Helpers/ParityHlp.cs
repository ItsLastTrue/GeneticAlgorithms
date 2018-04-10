namespace CL.KSAF.Helpers
{
    public static class ParityHlp
    {
        public static int ToEven(int number) =>
            number % 2 == 0 ? number : number + 1;
    }
}