using Ordering.APPLICATION.Models;
using System.Threading.Tasks;

namespace Ordering.APPLICATION.Contrats.Infrastructure
{
    public interface IEmailService
    {
        Task<string> SendEmail(Email email);
    }
}
