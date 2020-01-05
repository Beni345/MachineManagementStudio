using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MachineManagementStudio.ViewModels
{
    public class CaliburnMicroPopupViewModel : PropertyChangedBase, IViewAware
    {
        public event EventHandler<ViewAttachedEventArgs> ViewAttached = delegate { };
        private Popup _popup;
        private string _label;

        public CaliburnMicroPopupViewModel(String label)
        {
            Label = label;
        }



        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                NotifyOfPropertyChange(() => Label);
            }
        }





        public void AttachView(object view, object context = null)
        {
            var viewPopup = view as Popup;
            if (viewPopup != null)
            {
                _popup = viewPopup;
                _popup.StaysOpen = false;
            }

            ViewAttached(this, new ViewAttachedEventArgs() { Context = context, View = _popup });
        }

        public object GetView(object context = null)
        {
            return _popup;
        }
    }
}
