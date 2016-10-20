using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCRecover.Core.Interfaces
{
    public interface IProgressDialogService
    {
        Task Show(string title, string message);

        Task Show(string message);

        Task Dismiss();
    }
}
