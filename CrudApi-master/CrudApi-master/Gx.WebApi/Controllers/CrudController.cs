using Microsoft.AspNetCore.Mvc;
using Gx.Core.Services.Interfaces;
using System.Threading.Tasks;
using Gx.Core.Utilities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Gx.WebApi.Controllers;
using Gx.DataLayer.Entities.Crud;

namespace Queuening.WebApi.Controllers
{
    public class CrudController : SiteBaseController
    {
        #region constractor

        private ICrudService db;
        public CrudController(ICrudService _db)
        {
            this.db = _db;
        }

        #endregion

        #region users select 

        /// <summary>
        /// get one record of crud 
        /// </summary>
        /// <param name="id">for filter crud must enter the id </param>
        /// <returns></returns>
        [HttpGet("GetCrudById/{id:long}")]
        public async Task<IActionResult> GetCrudById([FromRoute] long id)
        {
            var retObj = await db.GetCrudById(id);
            return JsonResponseStatus.Success(retObj);
        }

        /// <summary>
        /// get all record without any filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCrud")]
        public async Task<IActionResult> GetAllCrud()
        {
            //if (!User.Identity.IsAuthenticated)
            //    return JsonResponseStatus.Error("UnAuthenticate");

            var retObj = await db.GetAllCrud();
            return JsonResponseStatus.Success(retObj);
        }


        /// <summary>
        /// this is for edit
        /// </summary>
        /// <param name="_Crud">type of Crud Object</param>
        /// <returns></returns>
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Crud _Crud)//, 
        {

            bool isExistEmail = db.IsUserExistsByEmail(_Crud.Email, true, _Crud.Id);
            bool isExistNameFamilyBirthdate = db.IsUserExistsByNameFamily(_Crud.Firstname, _Crud.Lastname, _Crud.DateOfBirth,true,_Crud.Id);

            if (isExistEmail)
                return JsonResponseStatus.Error(
                    new { info = "Email is  Exist..." }
                    );

            if (isExistNameFamilyBirthdate)
                return JsonResponseStatus.Error(
                    new { info = "this first name and lastname and dateofbirth is Exist..." }
                    );


            try
            {
                if (ModelState.IsValid)
                {

                    await db.Edit(_Crud);
                    return JsonResponseStatus.Success();
                }

                return JsonResponseStatus.Error();
            }
            catch (DbUpdateConcurrencyException er)
            {
                return NotFound(er.Message);
            }

            return Ok(_Crud);
        }

        /// <summary>
        /// this is for insert new item 
        /// </summary>
        /// <param name="data"> type of Crud Object</param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Crud data)
        {
            bool isExistEmail = db.IsUserExistsByEmail(data.Email);
            bool isExistNameFamilyBirthdate = db.IsUserExistsByNameFamily(data.Firstname,data.Lastname,data.DateOfBirth);

            if (isExistEmail )
                return JsonResponseStatus.Error(
                    new { info = "Email is  Exist..."}
                    );

            if (isExistNameFamilyBirthdate)
                return JsonResponseStatus.Error(
                    new{ info =  "this first name and lastname and dateofbirth is Exist..."  }
                    );


            Crud newObj = new Crud();
            try
            {
                if (ModelState.IsValid)
                {
                    newObj.Firstname = data.Firstname;
                    newObj.Lastname = data.Lastname;
                    newObj.DateOfBirth = Convert.ToInt32(data.DateOfBirth);
                    newObj.PhoneNumber = data.PhoneNumber;
                    newObj.Email = data.Email;
                    newObj.BankAccountNumber = Convert.ToInt32(data.BankAccountNumber);
                    newObj.CreateUserId = Convert.ToInt64(data.CreateUserId);
                    newObj.UpdateUserId = newObj.CreateUserId;
                    newObj.CreateDate = DateTime.Now;
                    newObj.LastUpdateDate = newObj.CreateDate;
                    newObj.Status = Convert.ToBoolean(data.Status);

                    await db.Create(newObj);

                    return JsonResponseStatus.Success(newObj);
                }

                return JsonResponseStatus.Error();
            }
            catch (DbUpdateConcurrencyException er)
            {
                return NotFound(er.Message);
            }

            return Ok(newObj);
        }


        /// <summary>
        /// this is for delete item 
        /// </summary>
        /// <param name="id"> id of item that must delete</param>
        /// <returns></returns>
        [HttpDelete("Delete/{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return JsonResponseStatus.Error("UnAuthenticate");

            try
            {
                if (ModelState.IsValid)
                {
                    await db.Delete(id);
                    return JsonResponseStatus.Success();
                }

                return JsonResponseStatus.Error();
            }
            catch (DbUpdateConcurrencyException er)
            {
                return NotFound(er.Message);
            }

            return Ok();
        }

        #endregion


    }
}
