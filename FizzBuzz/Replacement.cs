namespace FizzBuzz
{
    public struct Replacement
    {
        public Replacement(int divisibleBy, string replaceWith) : this()
        {
            DivisibleBy = divisibleBy;
            ReplaceWith = replaceWith;
        }

        public int DivisibleBy { get; private set; }
        public string ReplaceWith { get; private set; }
    }
}