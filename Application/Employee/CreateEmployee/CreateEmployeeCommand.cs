using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Enums;
using MediatR;

namespace Application.Employee.CreateEmployee
{
    public class CreateEmployeeCommand: IRequest<int>
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public DateTime? JoiningDate { get; set; }
        public List<EmployeeEducationDto> EmployeeEducations { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateEmployeeCommandHandler(IMapper mapper, IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = _mapper.Map<CreateEmployeeCommand, Domain.Models.Employee>(request);
            emp.EmployeeId = Guid.NewGuid();
            await _applicationDbContext.Employees.AddAsync(emp, cancellationToken);

            return await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
