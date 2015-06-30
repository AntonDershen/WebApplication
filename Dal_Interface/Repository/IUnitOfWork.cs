using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
