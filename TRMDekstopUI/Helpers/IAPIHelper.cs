using System.Threading.Tasks;
using TRMDekstopUI.Models;

namespace TRMDekstopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
    }
}