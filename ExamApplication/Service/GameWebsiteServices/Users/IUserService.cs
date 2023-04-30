using ExamApplication.Service.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApplication.Services.Users
{
    public interface IUserService
    {
        Task<ExamApplicationUserDto> CreateUser(ExamApplicationUserDto Dto);
        Task<ExamApplicationUserDto> DeleteUser(string id);
        List<ExamApplicationUserDto> GetAllUsers();
        Task<ExamApplicationUserDto> GetUserById(long id);
        Task<ExamApplicationUserDto> UpdateUser(long id, ExamApplicationUserDto userDto);
        int GetUsersCount();
    }
}
