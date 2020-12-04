using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Core.Interface
{
    interface IRepository<AnyType> where AnyType : class
    {
        AnyType Get(int id);
        List<AnyType> GetAll();

        string Add(AnyType entity);

        string Delete(AnyType entity);

        string Delete(int id);
        string Update(AnyType entity);

        string Publish(int id);
    }
}
