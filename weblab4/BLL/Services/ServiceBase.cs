using BLL.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public abstract class ServiceBase
    {
        protected void ValidateEntity<T>(T entity) where T : class
        {
            if(entity == null)
            {
                throw new NotFoundException();
            }
        }
    }
}
