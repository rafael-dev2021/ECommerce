namespace Domain.Identity;

public class RegistrationResult
{
    public bool IsRegistered { get; private set; }
    public string ErrorMessage { get; private set; } = string.Empty;

    public void SetIsRegistered(bool isRegistered) => IsRegistered = isRegistered;
    public void SetErrorMessage(string  errorMessage) => ErrorMessage = errorMessage;
}