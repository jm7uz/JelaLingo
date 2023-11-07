namespace JelaLingo.Service.Exceptions;

public class JelalingoException : Exception
{
    public int StatusCode { get; set; }
    public JelalingoException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}
