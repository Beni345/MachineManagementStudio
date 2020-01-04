using Caliburn.Micro;
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
    public class CuttingMachinesViewModel : Screen
    {
        public CuttingMachinesViewModel()
        {
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



            //GlobalConfig.Connection.InsertRecord<MachineType>("MachineTypes", machineType);
            GlobalConfig.Connection.InsertRecord<Machine>("BindingMachineList_IG5-iT", machine);

            //GlobalConfig.Connection.LoadRecords<MachineType>("MachineTypes");

        }


        private BindableCollection<MachineType> _machineTypes = new BindableCollection<MachineType>(GlobalConfig.Connection.LoadRecords<MachineType>("MachineTypes"));
        private MachineType _selectedMachineType;
        private BindableCollection<Machine> _machines = new BindableCollection<Machine>();

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

        private Machine _selectedMachine;

        public Machine SelectedMachine
        {   
            get { return _selectedMachine; }
            set
            {
                _selectedMachine = value;
                NotifyOfPropertyChange(() => SelectedMachine);
                GetSelectedMachine(_selectedMachine);
            }
          
    }

        private void GetSelectedMachine(Machine selectedMachine)
        {
            if (selectedMachine != null)
            {
                var t = selectedMachine.Id;

                //Löschen
                GlobalConfig.Connection.DeleteRecord<Machine>("BindingMachineList_" + selectedMachine.Name, selectedMachine.Id);
                var machines = GlobalConfig.Connection.LoadRecords<Machine>("BindingMachineList_" + selectedMachine.Name);
                Machines = Convert(machines);
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


        public BindableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new BindableCollection<T>(original);
        }


    }
}
