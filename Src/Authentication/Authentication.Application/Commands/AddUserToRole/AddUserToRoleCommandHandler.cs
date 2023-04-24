using Authentication.Application.CommandInterfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Authentication.Domain.Entities.ApplicationUser.Errors;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Commands.AddUserToRole;
public class AddUserToRoleCommandHandler : IHandler<AddUserToRoleCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AddUserToRoleCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Results> Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = request.Adapt<ApplicationUser>();
        if (await _userManager.FindByNameAsync(user.UserName) is null)
        {
            authenticationResults.AddErrorMessages(UserErrors.UserDoesNotExist);
            return authenticationResults;
        }

        var result = await _userManager.AddToRoleAsync(user, request.Role);
        authenticationResults.AddErrorMessages(result.Errors.Select(e => e.Description).ToArray());
        if (authenticationResults.ErrorMessages.Count > 0)
        {
            return authenticationResults;
        }
        authenticationResults.IsSuccess = true;
        return authenticationResults;
    }
}
