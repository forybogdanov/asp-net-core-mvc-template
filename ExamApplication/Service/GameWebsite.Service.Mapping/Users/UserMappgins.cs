
using ExamApplication.Data.Models;
using ExamApplication.Service.Models.Users;

namespace ExamApplication.Service.Mapping.Users
{
    public static class UserMappgins
    {
        public static ExamApplicationUser ToEntity(this ExamApplicationUserDto ExamApplicationUserDto)
        {
            return new ExamApplicationUser
            {
                Id = ExamApplicationUserDto.Id,
                UserName = ExamApplicationUserDto.UserName,
                Email = ExamApplicationUserDto.Email,
                Name = ExamApplicationUserDto.Name,
                LastName = ExamApplicationUserDto.LastName,
            };
        }

        public static ExamApplicationUserDto ToDto(this ExamApplicationUser ExamApplicationUser)
        {
            return new ExamApplicationUserDto
            {
                Id = ExamApplicationUser.Id,
                UserName = ExamApplicationUser.UserName,
                Email = ExamApplicationUser.Email,
                Name = ExamApplicationUser.Name,
                LastName = ExamApplicationUser.LastName,
            };
        }
    }
}
