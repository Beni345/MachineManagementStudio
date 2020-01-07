using FluentValidation;
using MMSLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSLib.ModelValidators
{
    public class MachineEntryValidator : AbstractValidator<Machine>
    {
        public MachineEntryValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Maschinen {PropertyName} ist leer")
                .Must(BeAValidName).WithMessage("Maschinen Name besteht nicht nur aus Buchstaben");
        }


        protected bool BeAValidName(string name)
        {
            //name = name.Replace(" ", "");
            //name = name.Replace("-", "");
            //return name.All(Char.IsLetter);

            return true;
        }


    }
}
