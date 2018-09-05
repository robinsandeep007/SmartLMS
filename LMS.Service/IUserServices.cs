using LMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Service
{
    public interface IUserServices
    {
        IEnumerable<users> GetAllActiveUsers();
        users GetUserByID(Guid id);
        users GetUserByUserName(string username);
        users Login(users user);
        bool Add(users user);
        
    }

}
