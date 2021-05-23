using Application.Infrastructure.Persistence;
using Application.Services.Commons;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    internal class UserService :BaseService, IUserService
    {
        public UserService(ICarRentalDbContext context) : base(context)
        {

        }
        public Response<User> Add(User user)
        {
            var result= Context.User.Add(user);
            Context.SaveChanges();

            return Response<User>.Success("Kullanıcı başarıyla kaydedildi.", result.Entity);
        }

        public User GetByEmail(string eMail)
        {
            return Context.User.Where(u => u.Email == eMail).SingleOrDefault();
        }
    }
}
