using AutoMapper;
using BLL.Abstractions;
using BLL.Abstractions.DTO;
using BLL.Abstractions.Infrastructure;
using BLL.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUnit _unit;
        private readonly IMapper _mapper;

        public UserService(IUnit unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<int> CreateUserAsync(UserDTO user)
        {
            var userToAdd = _mapper.Map<DAL.Abstractions.Models.User>(user);
            var resId = await _unit.UserRepository.CreateAsync(userToAdd);

            if ((resId ?? 0) == 0)
                throw new OperationCanceledException();

            return resId.Value;
        }

        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await _unit.UserRepository.GetAsync(id);

            ValidateEntity(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            var userToUpdate = _mapper.Map<DAL.Abstractions.Models.User>(user);
            await _unit.UserRepository.UpdateAsync(userToUpdate);
        }
    }
}
