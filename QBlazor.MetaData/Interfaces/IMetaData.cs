using System.Threading.Tasks;

namespace QBlazor
{
    public interface IMetaData
    {
        Task Create(string property, string value);

        Task<bool> Exists(string property);

        Task Remove(string property);

        Task Update(IData data);

        Task Tag(string property, string value);

        Task Favicon(string url);
    }
}