using Caliburn.Micro;
using MachineManagementStudio.EventModels;
using MMSLib.Global;
using MMSLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MachineManagementStudio.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private IWindowManager _windowManager;
        private CaliburnMicroTestViewModel _caliburnMicroTestVM;
        private CuttingMachinesViewModel _cuttingMachinesVM;
        private IEventAggregator _eventAggregator;


        public ShellViewModel(CuttingMachinesViewModel cuttingMachinesVM,CaliburnMicroTestViewModel caliburnMicroTestVM, IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _caliburnMicroTestVM = caliburnMicroTestVM;
            _cuttingMachinesVM = cuttingMachinesVM;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }


        public void LoadCuttingMachinesView()
        {
            ActivateItem(_cuttingMachinesVM);
        }


        public void LoadCaliburnMicroTestView()
        {
            //manager.ShowPopup(new CaliburnMicroTestViewModel());
            //_windowManager.ShowWindow(_caliburnMicroTestVM);
            _windowManager.ShowDialog(_caliburnMicroTestVM);
            //_windowManager.ShowPopup(new CaliburnMicroPopupViewModel("Test Message!"));
        }

        public void Handle(UpdateMachineEventModel message)
        {
            MessageBox.Show(message.Machine.MachineNumber);
        }
    }
}
