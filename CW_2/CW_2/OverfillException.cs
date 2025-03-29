namespace CW_2;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { } // tutaj : base pełni tą samą rolę co super() w javie 
}

