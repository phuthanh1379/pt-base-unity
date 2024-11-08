namespace GameLogic.Authentication
{
    public interface IAuthenticator
    {
        bool IsAuthenticate { get; }
        void ClearToken();
        void SetToken(string token);
        void Authenticate(IRequest request);
    }
}