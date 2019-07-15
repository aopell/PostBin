using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PostBin.Data;
using PostBin.Models;

namespace PostBin.Controllers
{
    [ApiController, Route("")]
    public class PostBinController : ControllerBase
    {
        IDataSource DataSource = new FileSystemDataSource();

        [HttpGet("{id}")]
        public ActionResult<PostData> Get(string id)
        {
            var post = DataSource.GetPostById(id);

            if (post == null) return NotFound();

            return post;
        }

        [HttpGet("{id}/raw")]
        public ActionResult<JObject> GetRaw(string id)
        {
            var post = DataSource.GetPostById(id);

            if (post == null) return NotFound();

            return post.Data;
        }

        [HttpPost]
        public ActionResult<PostMetadata> Post([FromBody] JObject json)
        {
            PostData data = new PostData
            {
                Data = json,
                Timestamp = DateTimeOffset.Now
            };

            return DataSource.SavePost(data);
        }

        [HttpDelete("{id}/{deleteId}"), HttpGet("{id}/delete/{deleteId}")]
        public ActionResult Delete(string id, string deleteId)
        {
            return StatusCode((int)DataSource.DeletePost(id, deleteId));
        }
    }
}
