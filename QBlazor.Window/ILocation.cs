using System.Threading.Tasks;

namespace QBlazor
{
    public interface ILocation
    {
        Task<string> Assign(string url);
        Task<string> Hostname();
        Task<string> Href();
        Task<string> Pathname();
        Task<string> Protocol();
    }
}