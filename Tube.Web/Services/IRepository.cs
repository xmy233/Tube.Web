using System;
using System.Collections.Generic;
using Tube.Web.Model;

namespace Tube.Web.Services
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T newModel);
       
    }
}
