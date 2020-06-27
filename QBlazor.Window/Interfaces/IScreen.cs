using System.Threading.Tasks;

namespace QBlazor
{
    public interface IScreen
    {
        Task<int> AvailHeight();
        Task<int> AvailWidth();
        Task<int> ColorDepth();
        Task<int> Height();
        Task<int> PixelDepth();
        Task<int> Width();
    }
}