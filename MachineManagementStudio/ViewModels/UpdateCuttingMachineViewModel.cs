using Caliburn.Micro;
using MachineManagementStudio.EventModels;
using MMSLib.Global;
using MMSLib.Models;
using MMSLib.ModelValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MachineManagementStudio.ViewModels
{
    public class UpdateCuttingMachineViewModel : Screen, IHandle<ExistingMachineEventModel>
    {
        private Machine _machineUpdate;
        private BindableCollection<Machine> _machines = new BindableCollection<Machine>(GlobalConfig.Connection.LoadRecords<Machine>("BindingMachineList_IG5-iT"));
        private string _name;
        private IEventAggregator _eventAggregator;

        public UpdateCuttingMachineViewModel(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

      
        public Machine MachineUpdate
        {
            get { return _machineUpdate; }
            set
            {
                _machineUpdate = value;
                NotifyOfPropertyChange(() => MachineUpdate);
            }
        }

        public BindableCollection<Machine> Machines
        {
            get { return _machines; }
            set
            {
                _machines = value;
                NotifyOfPropertyChange(() => Machines);
            }
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Handle(ExistingMachineEventModel message)
        {
            MachineUpdate = message.Machine;
        }

        public void UpdateMachine()
        {
            if (_machineUpdate != null)
            {

                // Validate model
                MachineEntryValidator validator = new MachineEntryValidator();
                var result = validator.Validate(_machineUpdate);

                if (result.IsValid)
                {
                    _eventAggregator.PublishOnUIThread(new UpdateMachineEventModel(_machineUpdate));
                    GlobalConfig.Connection.UpsertRecord<Machine>("BindingMachineList_" + _machineUpdate.Name, _machineUpdate.Id, _machineUpdate);
                    this.TryClose();
                }
                else
                {
                    foreach (var failure in result.Errors)
                    {
                        MessageBox.Show(failure.ErrorMessage);
                    }
                }


             
            }

        }

        public void OnClose(CancelEventArgs eve)
        {
            _eventAggregator.PublishOnUIThread(new UpdateMachineEventModel(_machineUpdate));
        }


    }
}
