using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Gx.Core.Services.Interfaces;
using Gx.DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gx.DataLayer.Entities.Crud;

namespace Gx.Core.Services.Implementations
{
    public class CrudService : ICrudService
    {
        #region constructor

        private IGenericRepository<Crud> genericRepository;
        public CrudService(IGenericRepository<Crud> _genericRepository)
        {
            this.genericRepository = _genericRepository;
        }

        #endregion

        #region User Section

        public async Task<Crud> GetCrudById(long Id)
        {
            return await genericRepository.GetEntityById(Id);
        }


        public async Task<List<Crud>> GetAllCrud()
        {
            return await genericRepository.GetEntitiesQuery().ToListAsync();
        }

        public async Task Delete(long id)
        {
            await genericRepository.DeleteEntity(id);
        }

        public async Task Edit(Crud _InputObj)
        {
            Crud obj = await GetCrudById(_InputObj.Id);

            if (obj != null)
            {
                obj.Id = _InputObj.Id;
                obj.Firstname = _InputObj.Firstname;
                obj.Lastname = _InputObj.Lastname;
                obj.DateOfBirth = _InputObj.DateOfBirth;
                obj.PhoneNumber = _InputObj.PhoneNumber;
                obj.Email = _InputObj.Email;
                obj.BankAccountNumber = _InputObj.BankAccountNumber;

                obj.Status = _InputObj.Status;
                obj.UpdateUserId = _InputObj.UpdateUserId;
                obj.LastUpdateDate = System.DateTime.Now;
                obj.CreateUserId = _InputObj.CreateUserId;
                obj.UpdateUserId = _InputObj.UpdateUserId;

                genericRepository.UpdateEntity(obj);
                await genericRepository.SaveChanges();
            }
        }

        public async Task Create(Crud _InputObj)
        {
            await genericRepository.AddEntity(_InputObj);
            await genericRepository.SaveChanges();
        }


        public  bool IsUserExistsByEmail(string email)
        {
            return genericRepository.GetEntitiesQuery()
                .Any(s => s.Email.ToLower() == email.ToLower().Trim());
        }
        public bool IsUserExistsByEmail(string email,bool isEdit,Int64 id)
        {
            return genericRepository.GetEntitiesQuery()
                .Any(s => s.Id != id && s.Email.ToLower() == email.ToLower().Trim());
        }

        public bool IsUserExistsByNameFamily(string name, string family, int dateofBirth)
        {
            return genericRepository.GetEntitiesQuery()
                .Any(s => s.DateOfBirth == dateofBirth
                       && s.Firstname.ToLower() == name.ToLower().Trim() 
                       && s.Lastname.ToLower()== family.ToLower().Trim() 
                        );
        }

        public bool IsUserExistsByNameFamily(string name, string family, int dateofBirth, bool isEdit, Int64 id)
        {
            return genericRepository.GetEntitiesQuery()
                .Any(s => s.Id != id
                        && s.DateOfBirth == dateofBirth
                       && s.Firstname.ToLower() == name.ToLower().Trim()
                       && s.Lastname.ToLower() == family.ToLower().Trim()
                        );
        }


        #endregion

        #region dispose

        public void Dispose()
        {
            genericRepository?.Dispose();
        }

        #endregion
    }
}