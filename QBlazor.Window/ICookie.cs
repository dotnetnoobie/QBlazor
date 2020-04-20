using System.Threading.Tasks;

namespace QBlazor
{
    public interface ICookie
    {
        Task<string> Get(string name);

        Task Set(string name, string value, int exdays);
    }
}