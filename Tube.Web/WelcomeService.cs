namespace Tube.Web
{
    public class WelcomeService : IWelcomeService
    {
        public string GetMessage()
        {
            return "Hello from IWelcome service";
        }
    }
}