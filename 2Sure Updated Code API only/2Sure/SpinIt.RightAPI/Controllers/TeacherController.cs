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

    [Route("api/[controller]/[action]")] //      api/Teacher
    [ApiController]

    public class TeacherController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITeacher _teacher;

        public TeacherController(UserManager<ApplicationUser> user, ITeacher teacher)
        {
            _userManager = user;
            _teacher = teacher;
        }
        // Get One Teacher

        [HttpGet(Name = "GetTeacherById")]

        public ActionResult<IEnumerable<string>> GetTeacherById(int Id)
        {

            try
            {
                var DataList = _teacher.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _teacher.GetByID(item.Id);
                    _teacher.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Get All Get All Teachers
        [HttpGet("GetAllTeachers")]
        public ActionResult<IEnumerable<string>> GetAllTeachers()
        {
            var data = JsonConvert.SerializeObject(_teacher.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add Teacher
        [HttpPost(Name = "InsertTeacher")]
        public ActionResult<IEnumerable<string>> InsertTeacher(Teacher teacher)
        {
            _teacher.Insert(teacher);
            _teacher.Save();
            return Ok("Record Successfully Added");
        }


        //Delete DeleteTeacher
        [HttpDelete(Name = "DeleteTeacher")]
        public ActionResult<IEnumerable<string>> DeleteTeacher(int Id)
        {

            try
            {
                var DataList = _teacher.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _teacher.Delete(item.Id);
                    _teacher.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update Teacher
        [HttpPut(Name = "UpdateTeacher")]
        public ActionResult<IEnumerable<string>> UpdateTeacher(Teacher teacher)
        {
            try
            {   
               _teacher.Update(teacher);
                _teacher.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
