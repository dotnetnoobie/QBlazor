using System;
using System.Threading.Tasks;

namespace QBlazor
{
    public interface ITheme
    {
        bool IsDark { get; set; }

        event EventHandler<bool> Changed;

        Task Initialize();
        void SetTheme();
        void Toggle();
    }
}