using OtoServis.Data;
using OtoServis.Data.Concrete;
using OtoServis.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Service.Concrete
{
    public class User : UserRepository, IUserService
    {
        public User(DatabaseContext context) : base(context)
        {
        }
    }
}
