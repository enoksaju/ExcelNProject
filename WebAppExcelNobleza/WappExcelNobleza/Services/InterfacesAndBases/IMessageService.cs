using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WappExcelNobleza.Services.MessageService;

namespace WappExcelNobleza.Services
{
    public interface IMessageService
    {
        Task SuccessMessage(string message, string title);
        Task<ObjectResultYesNo<T>> YesNoMessage<T>(string content, string title, T returnedOnYes, T returnedOnNo, string dialogClass = "");
    }
}
