using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WappExcelNobleza.Services
{
    public class MessageService : IMessageService
    {
        private IJSRuntime js;
        public event EventHandler<YesNoEventArgs> DialogResultYesNo;
        public MessageService(IJSRuntime _js)
        {
            this.js = _js;
        }

        public async Task SuccessMessage(string message, string title)
        {
            await js.InvokeVoidAsync("messageService.showNotifySuccess", message, title);
        }

        public async Task<ObjectResultYesNo<T>> YesNoMessage<T>(string content, string title, T returnedOnYes, T returnedOnNo, string Icon = "")
        {
            return await js.InvokeAsync<ObjectResultYesNo<T>>("messageService.yesNoMessage",
                DotNetObjectReference.Create(this),
                new
                {
                    Title = title,
                    Content = content,
                    Callback = "yesNoCallback",
                    ReturnedObjectOnYes = returnedOnYes,
                    ReturnedObjectOnNo = returnedOnNo,
                    Icon = Icon
                });
        }

        [JSInvokable("yesNoCallback")]
        public void YesNoCallback(object returnedObject)
        {
            DialogResultYesNo?.Invoke(this, new YesNoEventArgs(returnedObject));
        }
    }

    public class ObjectResultYesNo<T>
    {
        public bool Result { get; set; }
        public T ObjectResult { get; set; }
    }

    public class YesNoEventArgs : EventArgs
    {
        public object ReturnedObject { get; private set; }
        public YesNoEventArgs(object returnedObject)
        {
            this.ReturnedObject = returnedObject;
        }
    }
}
