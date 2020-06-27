using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace QBlazor
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public int MyProperty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs args) => PropertyChanged?.Invoke(this, args);

        public bool IsChanged { get; set; }

        public virtual void StateHasChanged() => PropertyChanged?.Invoke(this, null);

        public virtual Task Initialize() => Task.CompletedTask;

        public virtual void OnAfterRender(bool firstRender) { }

        public virtual void OnAfterRenderAsync(bool firstRender) { }

        public virtual void OnInitialized() { }

        public virtual Task OnInitializedAsync() => Task.CompletedTask;

        public virtual Task SetParametersAsync(ParameterView parameters) => Task.CompletedTask;

        public Action<Action> InvokeAsyncAction { get; set; }

        public Action<Func<Task>> InvokeAsyncFunc { get; set; }
    }
}