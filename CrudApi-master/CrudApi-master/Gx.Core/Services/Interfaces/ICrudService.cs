using Gx.DataLayer.Entities.Crud;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gx.Core.Services.Interfaces
{
    public interface ICrudService :IDisposable
    {
    
        Task<List<Crud>> GetAllCrud();
        Task<Crud> GetCrudById(long Id);
        Task Edit(Crud Queue);
        Task Create(Crud Queue);
        Task Delete(long Id);

        bool IsUserExistsByEmail(string email);
        bool IsUserExistsByEmail(string email,bool isEdit, Int64 id);
        bool IsUserExistsByNameFamily(string name,string family,int dateofBirth);
        bool IsUserExistsByNameFamily(string name,string family,int dateofBirth, bool isEdit, Int64 id);
    }
}
