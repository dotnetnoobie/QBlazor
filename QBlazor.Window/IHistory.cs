using System.Threading.Tasks;

namespace QBlazor
{
    public interface IHistory
    {
        Task Back();
        Task Forward();
    }
}