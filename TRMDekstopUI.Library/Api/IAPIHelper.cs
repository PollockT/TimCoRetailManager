using System.Threading.Tasks;
using TRMDekstopUI.Models;

namespace TRMDekstopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}