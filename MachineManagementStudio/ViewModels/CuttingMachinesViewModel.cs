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
using System.Windows.Media;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MachineManagementStudio.ViewModels
{
    public class CuttingMachinesViewModel : Conductor<object>, IHandle<UpdateMachineEventModel>
    {
        private IWindowManager _windowManager;
        private BindableCollection<MachineType> _machineTypes = new BindableCollection<MachineType>(GlobalConfig.Connection.LoadRecords<MachineType>("MachineTypes"));
        private MachineType _selectedMachineType;
        private BindableCollection<Machine> _machines = new BindableCollection<Machine>();
        private Machine _selectedMachine;
        private string _machineNumber;
        private Machine _selectedMachineToUpdate = new Machine();
        private IEventAggregator _eventAggregator;


        private UpdateCuttingMachineViewModel _updateCuttingMachineVM;

        /// <summary>
        /// Konstruktur
        /// </summary>
        /// <param name="updateCuttingMachineVM"></param>
        /// <param name="windowManager"></param>
        public CuttingMachinesViewModel(UpdateCuttingMachineViewModel updateCuttingMachineVM, IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _updateCuttingMachineVM = updateCuttingMachineVM;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            MachineType machineType = new MachineType()
            {
                Name = "IG6-iT"
            };

            Machine machine = new Machine
            {
                DateTime = DateTime.Now,
                Name = "IG5-iT",
                MachineNumber = "1 000 000 123"

            };

            GlobalConfig.MQTTData.IotClient.MqttMsgPublishReceived += IotClient_MqttMsgPublishReceived;
            GlobalConfig.MQTTData.SubscribeToTopics();

            //GlobalConfig.Connection.InsertRecord<MachineType>("MachineTypes", machineType);
            //GlobalConfig.Connection.InsertRecord<Machine>("BindingMachineList_IG5-iT", machine);

            //GlobalConfig.Connection.LoadRecords<MachineType>("MachineTypes");

        }

  
        private void IotClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            //MessageBox.Show("Received = " + Encoding.UTF8.GetString(e.Message) + " on topic " + e.Topic);
            MachineNumber = Encoding.UTF8.GetString(e.Message);
        }


        public BindableCollection<MachineType> MachineTypes
        {
            get { return _machineTypes; }
            set { _machineTypes = value; }
        }

        public MachineType SelectedMachineType
        {
            get { return _selectedMachineType; }
            set
            {
                _selectedMachineType = value;
                NotifyOfPropertyChange(() => SelectedMachineType);
                GetMachineListForSelectedType(_selectedMachineType);
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

        public Machine SelectedMachine
        {   
            get { return _selectedMachine; }
            set
            {
                _selectedMachine = value;
                NotifyOfPropertyChange(() => SelectedMachine);
                GetSelectedMachine(_selectedMachine);
                NotifyOfPropertyChange(() => SelectedMachineToUpdate);
            }
          
        }

     

        public string MachineNumber
        {
            get { return _machineNumber; }
            set
            {
                _machineNumber = value;
                NotifyOfPropertyChange(() => MachineNumber);
            }
        }

    

        public Machine SelectedMachineToUpdate
        {
            get { return _selectedMachineToUpdate; }
            set
            {
                _selectedMachineToUpdate = value;
                NotifyOfPropertyChange(() => SelectedMachineToUpdate);
            }

        }



        private void GetSelectedMachine(Machine selectedMachine)
        {
            if (selectedMachine != null)
            {
                var t = selectedMachine.Id;

                MachineNumber = selectedMachine.MachineNumber;
                SelectedMachineToUpdate.MachineNumber = selectedMachine.MachineNumber;

                ////Löschen
                //GlobalConfig.Connection.DeleteRecord<Machine>("BindingMachineList_" + selectedMachine.Name, selectedMachine.Id);
                //var machines = GlobalConfig.Connection.LoadRecords<Machine>("BindingMachineList_" + selectedMachine.Name);
                //Machines = Convert(machines);
            }
           
        }


        private void GetMachineListForSelectedType(MachineType machineType)
        {
            if (machineType != null)
            {
               var machines = GlobalConfig.Connection.LoadRecords<Machine>("BindingMachineList_" + machineType.Name);
                Machines = Convert(machines.Where(m => m.Name == machineType.Name));
            }
            
        }

        public void AddMachineType()
        {
            if (_selectedMachineType != null)
            {
                MessageBox.Show(_selectedMachineType.Name);
                var t = _selectedMachineType;
            }
          
        }

        //private void NotifyOfPropertyChange(Func<object> p)
        //{
        //    throw new NotImplementedException();
        //}


        public void UpdateSelectedMachine()
        {
            if (_selectedMachine != null)
            {
                //var m = _selectedMachine;
                //m.MachineNumber = MachineNumber;

                _selectedMachine.MachineNumber = SelectedMachineToUpdate.MachineNumber;

               
                GlobalConfig.Connection.UpsertRecord<Machine>("BindingMachineList_" + _selectedMachine.Name, _selectedMachine.Id, _selectedMachine);
                var machines = GlobalConfig.Connection.LoadRecords<Machine>("BindingMachineList_" + _selectedMachine.Name);
                Machines = Convert(machines);
            }



        }

      

        public void LoadCuttingMachineUpdateView()
        {
            if (_selectedMachine != null)
            {
                _eventAggregator.PublishOnUIThread(new ExistingMachineEventModel(_selectedMachine));
                var dialog = _windowManager.ShowDialog(_updateCuttingMachineVM);
      
            }
          
            //ActivateItem(_updateCuttingMachineVM);
        }



        public BindableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new BindableCollection<T>(original);
        }

        public void Handle(UpdateMachineEventModel message)
        {
            var machines = GlobalConfig.Connection.LoadRecords<Machine>("BindingMachineList_" + message.Machine.Name);
            Machines = Convert(machines);
        }
    }
}
