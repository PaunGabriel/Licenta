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

    [Route("api/[controller]/[action]")] //      api/Laboratory
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LaboratoryController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILaboratory _laboratory;

        public LaboratoryController(UserManager<ApplicationUser> user, ILaboratory laboratory)
        {
            _userManager = user;
            _laboratory = laboratory;
        }


        //Get Laboratory by Id
        [HttpGet(Name = "GetLaboratoryById")]
        public ActionResult<IEnumerable<string>> GetLaboratoryById(int Id)
        {

            try
            {
                var DataList = _laboratory.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _laboratory.GetByID(item.Id);
                    _laboratory.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Get All Get All Laboratories
        [HttpGet("GetAllLaboratories")] 
        public ActionResult<IEnumerable<string>> GetAllLaboratories()
        {
            var data = JsonConvert.SerializeObject(_laboratory.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add Insert Laboratory
        [HttpPost(Name = "InsertLaboratory")]
        public ActionResult<IEnumerable<string>> InsertLaboratory(Laboratory laboratory)
        {
            _laboratory.Insert(laboratory);
            _laboratory.Save();
            return Ok("Record Successfully Added");
        }


        //Delete Laboratory
        [HttpDelete(Name = "DeleteLaboratory")]
        public ActionResult<IEnumerable<string>> DeleteLaboratory(int Id)
        {

            try
            {
                var DataList = _laboratory.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _laboratory.Delete(item.Id);
                    _laboratory.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update Laboratory
        [HttpPut(Name = "UpdateLaboratory")]
        public ActionResult<IEnumerable<string>> UpdateLaboratory(Laboratory laboratory)
        {
            try
            {
                _laboratory.Update(laboratory);
                _laboratory.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
