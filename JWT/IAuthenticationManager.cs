namespace Authentification
{
    public interface IAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
