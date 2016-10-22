using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRecover.Core.Interfaces
{
    public interface IDialogService
    {
        Task Show(string title, string message);

        Task Show(string message);

        Task Dismiss();

        Task ShowToast(string message);
    }
}
