using Azure.Identity;

namespace TeamBlackHats.Services
{
    /// <summary>
    /// Class that represents the user that is currently logged in. 
    /// 
    /// Class is static to let ALL pages access the current state of the user.
    /// 
    /// When user leaves site, user is no longer authenticated.
    /// </summary>
    public static class AuthState
    {
        private static string username = "anonymous";
        private static bool authenticated = false;
        public static string Username { get => username; } 
        public static bool Authenticated { get => authenticated; } 

        public static void SetAuthenticatedUser(string authenticatedUsername)
        {
            username = authenticatedUsername;
            authenticated = true;
        }

        public static void LogoutUser()
        {
            authenticated = false;
        }
    }
}
