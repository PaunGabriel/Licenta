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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubjectController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubject _subject;

        public SubjectController(UserManager<ApplicationUser> user, ISubject subject)
        {
            _userManager = user;
            _subject = subject;
        }

        //Get Subject by Id
        [HttpGet(Name = "GetSubjectById")]
        public ActionResult<IEnumerable<string>> GetSubjectById(int Id)
        {

            try
            {
                var DataList = _subject.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _subject.GetByID(item.Id);
                    _subject.Save();
                    return Ok(item);
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Get All Get All Subjects
        [HttpGet("GetAllSubjects")]
        public ActionResult<IEnumerable<string>> GetAllSubjects()
        {
            var data = JsonConvert.SerializeObject(_subject.GetAll().ToList(), Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            return Ok(data);
        }

        //Add Insert Subject
        [HttpPost(Name = "InsertSubject")]
        public ActionResult<IEnumerable<string>> InsertSubject(Subject subject)
        {
            _subject.Insert(subject);
            _subject.Save();
            return Ok("Record Successfully Added");
        }


        //Delete Delete Subject
        [HttpDelete(Name = "DeleteSubject")]
        public ActionResult<IEnumerable<string>> DeleteSubject(int Id)
        {

            try
            {
                var DataList = _subject.GetAll().Where(x => x.Id == Id).ToList();
                foreach (var item in DataList)
                {
                    _subject.Delete(item.Id);
                    _subject.Save();
                    return Ok("Record Succeessfully Deleted");
                }
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }

        }

        //Update Update Subject
        [HttpPut(Name = "UpdateSubject")]
        public ActionResult<IEnumerable<string>> UpdateSubject(Subject subject)
        {
            try
            {
                _subject.Update(subject);
                _subject.Save();
                return Ok("Record Successfully Updated");
            }
            catch (Exception)
            {
                return Ok();
            }
        }

    }
}
