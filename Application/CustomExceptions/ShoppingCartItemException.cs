namespace Application.CustomExceptions;

public class ShoppingCartItemException : Exception
{

    public ShoppingCartItemException(string message) : base(message) { }

    public ShoppingCartItemException(string message, Exception innerException) : base(message, innerException) { }
}
