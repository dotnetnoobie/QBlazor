using System.Threading.Tasks;

namespace QBlazor
{
    public interface IWindow
    {
        ICookie Cookie { get; }
        IHistory History { get; }
        ILocation Location { get; }
        INavigator Navigator { get; }
        IScreen Screen { get; }

        Task Alert(string message);
        Task close();
        Task<int> InnerHeight();
        Task<int> InnerWidth();
        Task Open(string url);
    }
}