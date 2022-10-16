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

    [Route("api/[controller]/[action]")] //      api/SeminarController
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SeminarController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISeminar _seminar;

        public SeminarController(UserManager<ApplicationUser> user, ISeminar seminar)
        {
            _userManager = user;
            _seminar = seminar;
        }
        //Get Seminar By Id

        [HttpGet(Name = "GetSeminarById")]
        public ActionResult<IEnumerable<string>> GetSeminarById(int Id)
        {

            try
            {
                var DataList = _seminar.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _seminar.GetByID(item.Id);
                    _seminar.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }


        //Get All Get All Seminars
        [HttpGet("GetAllSeminars")]
        public ActionResult<IEnumerable<string>> GetAllSeminars()
        {
            var data = JsonConvert.SerializeObject(_seminar.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add Insert Seminar
        [HttpPost(Name = "InsertSeminar")]
        public ActionResult<IEnumerable<string>> InsertSeminar(Seminar seminar)
        {
            _seminar.Insert(seminar);
            _seminar.Save();
            return Ok("Record Successfully Added");
        }


        //Delete Seminar
        [HttpDelete(Name = "DeleteSeminar")]
        public ActionResult<IEnumerable<string>> DeleteSeminar(int Id)
        {

            try
            {
                var DataList = _seminar.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _seminar.Delete(item.Id);
                    _seminar.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update Seminar
        [HttpPut(Name = "UpdateSeminar")]
        public ActionResult<IEnumerable<string>> UpdateSeminar(Seminar seminar)
        {
            try
            {
                _seminar.Update(seminar);
                _seminar.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
