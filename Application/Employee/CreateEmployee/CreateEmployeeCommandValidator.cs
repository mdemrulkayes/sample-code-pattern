using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Employee.CreateEmployee
{
    public class CreateEmployeeCommandValidator: AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).NotEmpty();
        }
    }
}
