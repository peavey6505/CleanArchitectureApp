﻿using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Exceptions;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository repository) 
        {
            _leaveTypeRepository = repository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveTypeToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            return Unit.Value;

        }
    }
}
