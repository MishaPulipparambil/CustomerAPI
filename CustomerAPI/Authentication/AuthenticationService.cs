namespace CustomerAPI.Authentication
{
    /// <summary>
    /// Usually use JWT beare token to authenticate. Since the time is very less, just retruning it as True.
    /// </summary>
    public static class AuthenticationService
    {
        
        public static bool IsAuthenticated(HttpRequest request)
        {
            string userId = request.Headers["UserId"]; 
            string token = request.Headers["Token"];

            // Usually userId and token is stored in DB. Token is for one time usage.
            return (userId == "test" && token == "test");
        }
    }
}
