using MediatR;
using POS.Domain.Time;
using POS.Domain.Entities;
using POS.Application.Security;
using POS.Application.Exceptions;
using POS.Application.Repositories;

namespace POS.Application.Users.Commands.Handlers
{
    public class SignUpHandler : IRequestHandler<SignUp>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IClock _clock;

        public SignUpHandler(IRepository<User> userRepository,
                             IPasswordManager passwordManager,
                             IClock clock)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
            _clock = clock;
        }

        public async Task<Unit> Handle(SignUp request, CancellationToken cancellationToken)
        {
            var role = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role;

            if (await _userRepository.FindAsync(x => x.Email == request.Email) != null)
            {
                throw new EmailAlreadyInUseException(request.Email);
            }

            if (await _userRepository.FindAsync(x => x.Username == request.Username) != null)
            {
                throw new UsernameAlreadyInUseException(request.Username);
            }

            var securedPassword = _passwordManager.Secure(request.Password);
            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                Password = securedPassword,
                FullName = request.FullName,
                Role = role,
                CreatedAt = _clock.Current(),
            };
            await _userRepository.AddAsync(user);

            return Unit.Value;
        }
    }
}
