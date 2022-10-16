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

    [Route("api/[controller]/[action]")] //      api/ClassRoom
    [ApiController]
    
    public class GroupController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGroup _group;

        public GroupController(UserManager<ApplicationUser> user, IGroup group)
        {
            _userManager = user;
            _group = group;
        }


        //Get Group by Id
        [HttpGet(Name = "GetGroupById")]
        public ActionResult<IEnumerable<string>> GetGroupById(int Id)
        {

            try
            {
                var DataList = _group.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _group.GetByID(item.Id);
                    _group.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Get All Get All Groups
        [HttpGet("GetAllGroups")]
        public ActionResult<IEnumerable<string>> GetAllGroups()
        {
            var data = JsonConvert.SerializeObject(_group.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add Insert Group
        [HttpPost(Name = "InsertGroup")]
        public ActionResult<IEnumerable<string>> InsertGroup(Group group)
        {
            _group.Insert(group);
            _group.Save();
            return Ok("Record Successfully Added");
        }


        //Delete Group
        [HttpDelete(Name = "DeleteGroup")]
        public ActionResult<IEnumerable<string>> DeleteGroup(int Id)
        {

            try
            {
                var DataList = _group.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _group.Delete(item.Id);
                    _group.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update Update Group
        [HttpPut(Name = "UpdateGroup")]
        public ActionResult<IEnumerable<string>> UpdateGroup(Group group)
        {
            try
            {
                _group.Update(group);
                _group.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
