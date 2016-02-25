using FlashCardApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlashCardApp.Controllers
{
    [EnableCors(origins: "*",headers:"*",methods:"*")]
    public class FlashCardsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// Get all Questions and Answers
        /// </summary>
        /// <returns>A list of QAs</returns>
        public IHttpActionResult GetQAs()
        {
            var retval = db.Database.SqlQuery<QA>("Exec GetQAs").ToList();
            return Ok(retval);
        }
        /// <summary>
        /// Get a Question Answer for a specific Id
        /// </summary>
        /// <param name="id">Id is of type int</param>
        /// <returns>One QA with the specified Id</returns>
        public IHttpActionResult GetQA(int id)
        {
            var IdParam = new SqlParameter("@Id", id);
            var retval = db.Database.SqlQuery<QA>("Exec GetQA @Id", IdParam).ToList();
            return Ok(retval);
        }
        /// <summary>
        /// Get the QAs for a specific category
        /// </summary>
        /// <param name="cat">Category Name</param>
        /// <returns>A list of QAs in the specified Category</returns>
        public IHttpActionResult GetQAbyCat(string category)
        {
            var CatParam = new SqlParameter("@Cat", category);
            var retval = db.Database.SqlQuery<QA>("Exec GetQAbyCat @Cat", CatParam).ToList();
            return Ok(retval);
        }
        /// <summary>
        /// Get all Category rows
        /// </summary>
        /// <returns>A list of type Category(Id, Name)</returns>
        public IHttpActionResult GetCategories()
        {
            var retval = db.Database.SqlQuery<Category>("Exec GetCategories").ToList();
            return Ok(retval);
        }
        /// <summary>
        /// Get Distinct Category Names
        /// </summary>
        /// <returns>A list of Category Names (strings)</returns>
        public IHttpActionResult GetCategoryNames()
        {
            var retval = db.Database.SqlQuery<string>("Exec GetCategoryNames").ToList();
            return Ok(retval);
        }
    }
}
