using CompanyStructure.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace CompanyStructure.Contract
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<bool> Login(LoginDto loginDto);
    }
}
