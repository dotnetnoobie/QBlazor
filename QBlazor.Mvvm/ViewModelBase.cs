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





//public Action<Action> OnInvokeAsyncAction;
//public Func<Task> OnInvokeAsyncFunc;

//public Task InvokeAsync(Action workItem)
//{
//    OnInvokeAsyncAction.Invoke(workItem);
//    return Task.CompletedTask;
//}

//public Task InvokeAsync(Func<Task> workItem)
//{
//    OnInvokeAsyncFunc = workItem;

//    return OnInvokeAsyncFunc.Invoke();
//}


//public event EventHandler InvokeAsync;






//public virtual Task InvokeAsync(Action workItem) => Task.CompletedTask;

//public virtual Task InvokeAsync(Func<Task> workItem) => Task.CompletedTask;

// public Task InvokeAsync(Action workItem) => Task.CompletedTask;

// public Task InvokeAsync(Func<Task> workItem) => Task.CompletedTask;




//public readonly ILocalStorage LocalStorage;
//public readonly NavigationManager NavigationManager;
//public readonly IConfiguration Configuration;
//public readonly IJSRuntime JSRuntime;

//public ViewModelBase(ILocalStorage localStorage = null, NavigationManager navigationManager = null, IConfiguration configuration = null, IJSRuntime jSRuntime = null)
//{
//    this.LocalStorage = localStorage;
//    this.NavigationManager = navigationManager;
//    this.Configuration = configuration;
//    this.JSRuntime = jSRuntime;
//}



//public async Task<T> Load<T>(Expression<Func<T>> expression)
//{
//    var name = ((MemberExpression)expression.Body).Member.Name;

//    var key = this.GetType().FullName + "." + name;
//    return await this.LocalStorage.Get<T>(key);
//}

//public async Task Save<T>(Expression<Func<T>> expression)
//{
//    var name = ((MemberExpression)expression.Body).Member.Name;
//    var value = expression.Compile()();

//    var key = this.GetType().FullName + "." + name;
//    await this.LocalStorage.Set<T>(key, value);

//    this.IsChanged = false;
//}





////
//// Summary:
////     Sets parameters supplied by the component's parent in the render tree.
////
//// Parameters:
////   parameters:
////     The parameters.
////
//// Returns:
////     A System.Threading.Tasks.Task that completes when the component has finished
////     updating and rendering itself.
////
//// Remarks:
////     The Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)
////     method should be passed the entire set of parameter values each time Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)
////     is called. It not required that the caller supply a parameter value for all parameters
////     that are logically understood by the component.
////     The default implementation of Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync(Microsoft.AspNetCore.Components.ParameterView)
////     will set the value of each property decorated with Microsoft.AspNetCore.Components.ParameterAttribute
////     or Microsoft.AspNetCore.Components.CascadingParameterAttribute that has a corresponding
////     value in the Microsoft.AspNetCore.Components.ParameterView. Parameters that do
////     not have a corresponding value will be unchanged.
//public virtual Task SetParametersAsync(ParameterView parameters);
////
//// Summary:
////     Renders the component to the supplied Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.
////
//// Parameters:
////   builder:
////     A Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder that will receive
////     the render output.
//protected virtual void BuildRenderTree(RenderTreeBuilder builder);
////
//// Summary:
////     Executes the supplied work item on the associated renderer's synchronization
////     context.
////
//// Parameters:
////   workItem:
////     The work item to execute.
//protected Task InvokeAsync(Action workItem);
////
//// Summary:
////     Executes the supplied work item on the associated renderer's synchronization
////     context.
////
//// Parameters:
////   workItem:
////     The work item to execute.
//protected Task InvokeAsync(Func<Task> workItem);
////
//// Summary:
////     Method invoked after each time the component has been rendered.
////
//// Parameters:
////   firstRender:
////     Set to true if this is the first time Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
////     has been invoked on this component instance; otherwise false.
////
//// Remarks:
////     The Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
////     and Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)
////     lifecycle methods are useful for performing interop, or interacting with values
////     recieved from @ref. Use the firstRender parameter to ensure that initialization
////     work is only performed once.
//protected virtual void OnAfterRender(bool firstRender);
////
//// Summary:
////     Method invoked after each time the component has been rendered. Note that the
////     component does not automatically re-render after the completion of any returned
////     System.Threading.Tasks.Task, because that would cause an infinite render loop.
////
//// Parameters:
////   firstRender:
////     Set to true if this is the first time Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
////     has been invoked on this component instance; otherwise false.
////
//// Returns:
////     A System.Threading.Tasks.Task representing any asynchronous operation.
////
//// Remarks:
////     The Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
////     and Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)
////     lifecycle methods are useful for performing interop, or interacting with values
////     recieved from @ref. Use the firstRender parameter to ensure that initialization
////     work is only performed once.
//protected virtual Task OnAfterRenderAsync(bool firstRender);
////
//// Summary:
////     Method invoked when the component is ready to start, having received its initial
////     parameters from its parent in the render tree.
//protected virtual void OnInitialized();
////
//// Summary:
////     Method invoked when the component is ready to start, having received its initial
////     parameters from its parent in the render tree. Override this method if you will
////     perform an asynchronous operation and want the component to refresh when that
////     operation is completed.
////
//// Returns:
////     A System.Threading.Tasks.Task representing any asynchronous operation.
//protected virtual Task OnInitializedAsync();
////
//// Summary:
////     Method invoked when the component has received parameters from its parent in
////     the render tree, and the incoming values have been assigned to properties.
//protected virtual void OnParametersSet();
////
//// Summary:
////     Method invoked when the component has received parameters from its parent in
////     the render tree, and the incoming values have been assigned to properties.
////
//// Returns:
////     A System.Threading.Tasks.Task representing any asynchronous operation.
//protected virtual Task OnParametersSetAsync();
////
//// Summary:
////     Returns a flag to indicate whether the component should render.
//protected virtual bool ShouldRender();
////
//// Summary:
////     Notifies the component that its state has changed. When applicable, this will
////     cause the component to be re-rendered.
//protected void StateHasChanged();


















//public ViewModelBase() { }

//public ViewModelBase(ILocalStorage localStorage) => this.LocalStorage = localStorage;

//public ViewModelBase(NavigationManager navigationManager) => this.NavigationManager = navigationManager;

//public ViewModelBase(IConfiguration configuration) => this.Configuration = configuration;

//public ViewModelBase(IJSRuntime jSRuntime) => this.JSRuntime = jSRuntime;

//public ViewModelBase(ILocalStorage localStorage, NavigationManager navigationManager)
//{
//    this.LocalStorage = localStorage;
//    this.NavigationManager = navigationManager;
//}

//public ViewModelBase(ILocalStorage localStorage, IConfiguration configuration)
//{
//    this.LocalStorage = localStorage;
//    this.Configuration = configuration;
//}

//public ViewModelBase(ILocalStorage localStorage, IJSRuntime jSRuntime)
//{
//    this.LocalStorage = localStorage;
//    this.JSRuntime = jSRuntime;
//}

//public ViewModelBase(NavigationManager navigationManager, IConfiguration configuration)
//{
//    this.NavigationManager = navigationManager;
//    this.Configuration = configuration;
//}

//public ViewModelBase(NavigationManager navigationManager, IJSRuntime jSRuntime)
//{
//    this.NavigationManager = navigationManager;
//    this.JSRuntime = jSRuntime;
//}

//public ViewModelBase(IConfiguration configuration, IJSRuntime jSRuntime)
//{
//    this.Configuration = configuration;
//    this.JSRuntime = jSRuntime;
//}

//public ViewModelBase(ILocalStorage localStorage, NavigationManager navigationManager, IConfiguration configuration)
//{
//    this.LocalStorage = localStorage;
//    this.NavigationManager = navigationManager;
//    this.Configuration = configuration;
//}

//public ViewModelBase(ILocalStorage localStorage, NavigationManager navigationManager, IConfiguration configuration)
//{
//    this.LocalStorage = localStorage;
//    this.NavigationManager = navigationManager;
//    this.Configuration = configuration;
//}