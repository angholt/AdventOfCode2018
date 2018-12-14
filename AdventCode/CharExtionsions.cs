namespace AdventCode
{
    public static class CharExtionsions
    {
        public static char InvertCase(this char c)
        {
            if (char.IsLower(c))
            {
                return char.ToUpper(c);
            }
            else if(char.IsUpper(c))
            {
                return char.ToLower(c);
            }
            else
            {
                return c;
            }
        }
    }
}
