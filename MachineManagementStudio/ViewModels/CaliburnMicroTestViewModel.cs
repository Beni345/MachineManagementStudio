using Caliburn.Micro;
using MMSLib.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MachineManagementStudio.ViewModels
{
    public class CaliburnMicroTestViewModel : Conductor<object>
    {
        private SolidColorBrush _controlBrush = new SolidColorBrush(Color.FromRgb(100, 220, 200));

      


        /// <summary>
        /// Custom action event bei Mouse enter
        /// </summary>
        public void MouseEnterButton()
        {
            ControlBrush = new SolidColorBrush(Colors.Red);
            MessageBox.Show("Mouse Enter Button!");
        }

        public SolidColorBrush ControlBrush
        {
            get { return _controlBrush; }
            set
            {
                _controlBrush = value;
                NotifyOfPropertyChange(() => ControlBrush);
            }
        }

    

    }
}
