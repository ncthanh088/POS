using MediatR;
using POS.Domain.Time;
using POS.Domain.Entities;
using POS.Domain.ValueObjects;
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
            // Validation by strong type.
            var userId = new UserId(request.UserId);
            var email = new Email(request.Email);
            var username = new Username(request.Username);
            var password = new Password(request.Password);
            var fullName = new FullName(request.FullName);
            var role = string.IsNullOrWhiteSpace(request.Role) ? Role.User() : new Role(request.Role);

            if (await _userRepository.FindAsync(x => x.Email == email) != null)
            {
                throw new EmailAlreadyInUseException(email);
            }

            if (await _userRepository.FindAsync(x => x.Username == username) != null)
            {
                throw new UsernameAlreadyInUseException(username);
            }

            var securedPassword = _passwordManager.Secure(password);
            var user = new User(userId,
                                email,
                                username,
                                securedPassword,
                                fullName,
                                role,
                                _clock.Current());

            await _userRepository.AddAsync(user);

            return Unit.Value;
        }
    }
}
