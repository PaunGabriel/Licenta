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

    [Route("api/[controller]/[action]")] //      api/SubGroup
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubGroupController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubGroup _subgroup;

        public SubGroupController(UserManager<ApplicationUser> user, ISubGroup subgroup)
        {
            _userManager = user;
            _subgroup = subgroup;
        }


        //Get SubGroup by Id
        [HttpGet(Name = "GetSubGroupById")]
        public ActionResult<IEnumerable<string>> GetSubGroupById(int Id)
        {

            try
            {
                var DataList = _subgroup.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _subgroup.GetByID(item.Id);
                    _subgroup.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Get All Get All SubGroups
        [HttpGet("GetAllSubGroups")]
        public ActionResult<IEnumerable<string>> GetAllSubGroups()
        {
            var data = JsonConvert.SerializeObject(_subgroup.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add Insert SubGroup
        [HttpPost(Name = "InsertSubGroup")]
        public ActionResult<IEnumerable<string>> InsertSubGroup(SubGroup subgroup)
        {
            _subgroup.Insert(subgroup);
            _subgroup.Save();
            return Ok("Record Successfully Added");
        }


        //Delete SubGroup
        [HttpDelete(Name = "DeleteSubGroup")]
        public ActionResult<IEnumerable<string>> DeleteSubGroup(int Id)
        {

            try
            {
                var DataList = _subgroup.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _subgroup.Delete(item.Id);
                    _subgroup.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update SubGroup
        [HttpPut(Name = "UpdateSubGroup")]
        public ActionResult<IEnumerable<string>> UpdateSubGroup(SubGroup subgroup)
        {
            try
            {
                _subgroup.Update(subgroup);
                _subgroup.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
