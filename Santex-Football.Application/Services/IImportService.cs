using System.Threading.Tasks;

namespace Santex_Football.Application.Services
{
    public interface IImportService
    {
        Task Import(string leagueCode);
    }
}