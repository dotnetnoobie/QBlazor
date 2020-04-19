using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QBlazor
{
    public class ViewModelPageBase<T> : ComponentBase where T : ViewModelBase
    {
        [Inject]
        public T ViewModel { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AllOtherAttributes { get; set; }

        protected override void OnInitialized()
        {
            ViewModel.PropertyChanged += (o, e) => this.InvokeAsync(() => this.StateHasChanged());
            ViewModel.InvokeAsyncAction += (a) => this.InvokeAsync(a);
            ViewModel.InvokeAsyncFunc += (f) => this.InvokeAsync(f);

            //this.InvokeAsync(() => ViewModel.OnInvokeAsyncAction.Invoke());

            //ViewModel.OnInvokeAsyncAction = 

            //ViewModel.OnInitialized();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            ViewModel.OnAfterRender(firstRender);
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            ViewModel.OnAfterRenderAsync(firstRender);
            return Task.CompletedTask;
        }

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.OnInitializedAsync();
        }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);

            try
            {
                await ViewModel.SetParametersAsync(parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetParametersAsync: " + ex.Message);
            }
        }
    }
}