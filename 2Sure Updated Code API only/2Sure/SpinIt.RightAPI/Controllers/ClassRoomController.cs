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
    
    public class ClassRoomController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IClassRoom _classroom;

        public ClassRoomController(UserManager<ApplicationUser> user, IClassRoom classRoom)
        {
            _userManager = user;
            _classroom = classRoom;
        }

        // Get Class by Id

        [HttpGet(Name = "GetClassRoomById")]
        public ActionResult<IEnumerable<string>> GetClassRoomById(int Id)
        {

            try
            {
                var DataList = _classroom.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _classroom.GetByID(item.Id);
                    _classroom.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Get All GetAllClassRooms
        [HttpGet("GetAllClassRooms")]
        public ActionResult<IEnumerable<string>> GetAllClassRooms()
        {
            var data = JsonConvert.SerializeObject(_classroom.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add ClassRoom
        [HttpPost(Name = "InsertClassRoom")]
        public ActionResult<IEnumerable<string>> InsertClassRoom(ClassRoom classRoom)
        {
            _classroom.Insert(classRoom);
            _classroom.Save();
            return Ok("Record Successfully Added");
        }


        //Delete DeleteClassRoom
        [HttpDelete(Name = "DeleteClassRoom")]
        public ActionResult<IEnumerable<string>> DeleteClassRoom(int Id)
        {

            try
            {
                var DataList = _classroom.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _classroom.Delete(item.Id);
                    _classroom.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update ClassRoom
        [HttpPut(Name = "UpdateClassRoom")]
        public ActionResult<IEnumerable<string>> UpdateClassRoom(ClassRoom classroom)
        {
            try
            {   
               _classroom.Update(classroom);
                _classroom.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
