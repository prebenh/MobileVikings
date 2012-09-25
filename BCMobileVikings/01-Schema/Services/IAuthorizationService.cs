using System.Threading.Tasks;

namespace MobileVikings.BackEnd.Schema.Services
{
    /// <summary>
    /// Service to sign in and out.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Sign the specified user in
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<bool> SignIn(string userName, string password);

        /// <summary>
        /// Signs the user out.
        /// </summary>
        void SignOut();
    }
}
