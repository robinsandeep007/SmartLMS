using LMS.Data;
using LMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Service
{
    public class UserServices : IUserServices
    {
        private SmartLMSDbContext _context;
        public UserServices(SmartLMSDbContext context)
        {
            _context = context;
        }

        public bool Add(users user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                if(!string.IsNullOrEmpty(ex.Message))
                return false;
            }
            return true;
        }

       
        public users Login(users user)
        {
            return _context.users.Single(a => a.username == user.username); 
        }


        public IEnumerable<users> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public users GetUserByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public users GetUserByUserName(string username)
        {
            throw new NotImplementedException();
        }

    }
}
