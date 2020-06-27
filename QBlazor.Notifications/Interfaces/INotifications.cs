using System.Threading.Tasks;

namespace QBlazor
{
    public interface INotifications
    {
        PermissionType Permission { get; set; }

        Task Create(string title, string body);
        Task<PermissionType> RequestPermission();
    }
}