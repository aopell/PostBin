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
        [HttpGet("{id}")]
        public ActionResult<PostData> Get(string id)
        {
            var post = DataProvider.GetPostById(id);

            if (post == null) return NotFound();

            return post;
        }
            
        [HttpGet("{id}/raw")]
        public ActionResult<JToken> GetRaw(string id)
        {
            var post = DataProvider.GetPostById(id);

            if (post == null) return NotFound();

            return post.Data;
        }

        [HttpPost]
        public ActionResult<PostMetadata> Post([FromBody] JToken json, string title = null, string source = null)
        {
            PostData data = new PostData
            {
                Title = title,
                Source = source,
                Data = json,
                Timestamp = DateTimeOffset.Now
            };

            return DataProvider.SavePost(data);
        }

        [HttpDelete("{id}/{deleteId}"), HttpGet("{id}/delete/{deleteId}")]
        public ActionResult Delete(string id, string deleteId)
        {
            return StatusCode((int)DataProvider.DeletePost(id, deleteId));
        }
    }
}
