using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sadad.Core.ApplicationService.Dtos.UserDto;

namespace Sadad.Core.ApplicationService.Services.User
{
   public interface IUserService
    {
        Task<string> Create(UserInputDto inputDto);
        Task<string> Update(UserUpdateDto item);
        Task<string> Delete(int id);
        Task<UserOutputDto> Get(int id);
        Task<List<UserOutputDto>> GetAll();
     
    }
}
