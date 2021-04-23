using BLL.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserAsync(int id);
        Task<int> CreateUserAsync(UserDTO user);
        Task UpdateUserAsync(UserDTO user);
    }
}
