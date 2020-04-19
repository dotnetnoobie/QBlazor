using System.Threading.Tasks;

namespace QBlazor
{
    public interface IWindow
    {
        Task Alert(string message);
        Task Open(string url);
    }
}