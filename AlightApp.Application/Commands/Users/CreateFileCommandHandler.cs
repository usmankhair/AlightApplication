using AlightApp.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AlightApp.Application.Commands.Users
{
    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, bool>
    {
        private readonly IUserAdapter _userAdapter;

        public CreateFileCommandHandler(IUserAdapter userAdapter)
        {
            _userAdapter = userAdapter;
        }

        public async Task<bool> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            return await _userAdapter.CreateFile(request.Users, cancellationToken);
        }
    }
}
