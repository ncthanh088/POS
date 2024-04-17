using MediatR;
using POS.Application.Security;
using POS.Application.Exceptions;
using POS.Domain.Entities;
using POS.Domain.Repositories;

namespace POS.Application.Users.Commands.Handlers
{
    public class SignInHandler : IRequestHandler<SignIn>
    {

        private readonly IRepository<User> _userRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenStorage _tokenStorage;

        public SignInHandler(IRepository<User> userRepository,
                             IAuthenticator authenticator,
                             IPasswordManager passwordManager,
                             ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _authenticator = authenticator;
            _passwordManager = passwordManager;
            _tokenStorage = tokenStorage;
        }

        public async Task<Unit> Handle(SignIn request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.Email == request.Email);

            if (user is null)
            {
                throw new InvalidCredentialsException();
            }

            if (!_passwordManager.Validate(request.Password, user.Password))
            {
                throw new InvalidCredentialsException();
            }

            var jwt = _authenticator.CreateToken(user.Id, user.Role);
            _tokenStorage.Set(jwt);

            return Unit.Value;
        }
    }
}
