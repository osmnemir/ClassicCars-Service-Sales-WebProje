using OtoServis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Abstract
{
    public interface IUserRepository : IRepository<Kullanici>
    {
        Task<List<Kullanici>> GetCustomUserList();
        Task<List<Kullanici>> GetCustomUserList(Expression<Func<Kullanici, bool>> expression);
    }
}
