namespace Domain.Identity;

public class AuthenticationResult
{
    public bool IsAuthenticated { get; private set; }   
    public string ErrorMessage { get; private set; } = string.Empty;
    
    public void SetIsAuthenticated(bool isAuthenticated) => IsAuthenticated = isAuthenticated;
    public void SetErrorMessage(string  errorMessage) => ErrorMessage = errorMessage;
}