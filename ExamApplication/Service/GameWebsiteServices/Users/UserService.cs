
using ExamApplication.Data;
using ExamApplication.Data.Models;
using ExamApplication.Service.Mapping.Users;
using ExamApplication.Service.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExamApplication.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ExamApplicationDbContext ExamApplicationDbContext;

        public UserService(ExamApplicationDbContext ExamApplicationDbContext)
        {
            this.ExamApplicationDbContext = ExamApplicationDbContext;
        }

        public Task<ExamApplicationUserDto> CreateUser(ExamApplicationUserDto Dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ExamApplicationUserDto> DeleteUser(string id)
        {
            ExamApplicationUser user = this.ExamApplicationDbContext.Users.SingleOrDefault(user => user.Id == id);
            if (user == null)
            {
                // TODO: throw exception
                return null;
            }

            ExamApplicationUserDto userDto = user.ToDto();
            this.ExamApplicationDbContext.Remove(user);
            await this.ExamApplicationDbContext.SaveChangesAsync();
            return userDto;
        }

        public List<ExamApplicationUserDto> GetAllUsers()
        {
            return ExamApplicationDbContext.Users.Select<ExamApplicationUser, ExamApplicationUserDto>( u => u.ToDto()).ToList();
        }

        public Task<ExamApplicationUserDto> GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public int GetUsersCount()
        {
            return ExamApplicationDbContext.Users.Count();
        }

        public Task<ExamApplicationUserDto> UpdateUser(long id, ExamApplicationUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
