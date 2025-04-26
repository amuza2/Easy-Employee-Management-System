using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EEMS.UI.Views.Shared.PageNativation
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : Page;
        void SetFrame(Frame fram);
    }
}
