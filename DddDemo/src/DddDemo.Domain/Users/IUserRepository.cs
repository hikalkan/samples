using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DddDemo.Users
{
    public interface IUserRepository
    {
        User Get(string id);
    }
}
