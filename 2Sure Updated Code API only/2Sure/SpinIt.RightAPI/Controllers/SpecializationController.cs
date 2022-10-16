using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Spinit.Data.Models;
using Spinit.Data.Models.User;
using Spinit.Data.Services.Infrastructure;
using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace SpinIt.RightAPI.Controllers
{

    [Route("api/[controller]/[action]")] //      api/Specialization
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SpecializationController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISpecialization _specialization;

        public SpecializationController(UserManager<ApplicationUser> user, ISpecialization specialization)
        {
            _userManager = user;
            _specialization = specialization;
        }


        //Get Specialization by Id
        [HttpGet(Name = "GetSpecializationById")]
        public ActionResult<IEnumerable<string>> GetSpecializationById(int Id)
        {

            try
            {
                var DataList = _specialization.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _specialization.GetByID(item.Id);
                    _specialization.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Get All GetAllSpecializations
        [HttpGet("GetAllSpecializations")]
        public ActionResult<IEnumerable<string>> GetAllSpecializations()
        {
            var data = JsonConvert.SerializeObject(_specialization.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add Specialization
        [HttpPost(Name = "InsertSpecialization")]
        public ActionResult<IEnumerable<string>> InsertSpecialization(Specialization specialization)
        {
            _specialization.Insert(specialization);
            _specialization.Save();
            return Ok("Record Successfully Added");
        }


        //Delete Specialization
        [HttpDelete(Name = "DeleteSpecialization")]
        public ActionResult<IEnumerable<string>> DeleteSpecialization(int Id)
        {

            try
            {
                var DataList = _specialization.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _specialization.Delete(item.Id);
                    _specialization.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update Specialization
        [HttpPut(Name = "UpdateSpecialization")]
        public ActionResult<IEnumerable<string>> UpdateSpecialization(Specialization specialization)
        {
            try
            {   
               _specialization.Update(specialization);
                _specialization.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
