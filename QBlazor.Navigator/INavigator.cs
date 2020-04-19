using System.Threading.Tasks;

namespace QBlazor
{
    public interface INavigator
    {
        Task<string> UserAgent();
    }
}