using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sadad.Core.ApplicationService.Dtos.UserDto;
using Sadad.Core.ApplicationService.IRepository;

namespace Sadad.Core.ApplicationService.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Sadad.Core.Entities.Model.User> userRepository;
        private readonly IMapper mapper;
        public UserService(IRepository<Sadad.Core.Entities.Model.User> userRepository,
             IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;

        }
        public async Task<string> Create(UserInputDto inputDto)
        {
            var item = userRepository.GetQuery().Where(x => x.EmailAddress == inputDto.EmailAddress).FirstOrDefault();
            if (item == null)
            {
                var useritem = mapper.Map<Sadad.Core.Entities.Model.User>(inputDto);
                userRepository.Insert(useritem);
                await userRepository.Save();
                return $" {inputDto.Name} Created in DataBase";
            }
            return $" {inputDto.Name} This User is exist";
        }

        public async Task<string> Delete(int id)
        {
            var item = userRepository.GetQuery().Where(x => x.Id == id).FirstOrDefault();
            if (item != null)
            {
                await userRepository.Delete(id);
                await userRepository.Save();
                return $"This User With Id:{id} Deleted";
            }
            return $"This User With Id:{id} Is not Exist !!!";
        }

        public async Task<UserOutputDto> Get(int id)
        {
            var item = userRepository.GetQuery().Where(x => x.Id == id).FirstOrDefault();
            if (item == null)
            {
                return null;
            }
            return mapper.Map<UserOutputDto>(item);
        }

        public async Task<List<UserOutputDto>> GetAll()
        {
            var list = userRepository.GetQuery().Select(x => new UserOutputDto()
            {
                Id = x.Id,
                Name = x.Name,
                Gender = x.Gender,
                BirthDate = x.BirthDate,
                EmailAddress = x.EmailAddress
            }).ToList();

            if (list == null)
            {
                return null;
            }
            return list;
        }

        public async Task<string> Update(UserUpdateDto input)
        {
            var item = userRepository.GetQuery().Where(x => x.Id == input.Id).FirstOrDefault();
            if (item == null)
            {
                return $"This User Was not Found !!!";
            }

            item.Name = input.Name;
            item.BirthDate = input.BirthDate;
            item.Gender = input.Gender;
            item.EmailAddress = input.EmailAddress;

            await userRepository.Save();
            return $"This User{item.Id} Updated Successfully";
        }
    }
}
