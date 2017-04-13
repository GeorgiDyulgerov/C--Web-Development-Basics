using System.Linq;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;
using SoftUniStore.Models;

namespace SoftUniStore.Utilities
{
    public class AuthenticationManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            return Data.Data.Context.Logins.Any(login => login.SessionId == sessionId && login.IsActive);
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Data.Data.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive)?.User;      
            return user;
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            Login currentLogin = Data.Data.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            currentLogin.IsActive = false;
            Data.Data.Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }

    }
}
