using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Commands.AddUserToRole;
public record AddUserToRoleCommand(
    string UserName,
    string Role
) : ICommand;