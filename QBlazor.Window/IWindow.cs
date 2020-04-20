using System.Threading.Tasks;

namespace QBlazor
{
    public interface IWindow
    {
        Task Alert(string message);
        Task Open(string url);

        IHistory History { get; }

        INavigator Navigator { get; }

        ICookie Cookie { get; }

        ILocation Location { get; }
    }
}