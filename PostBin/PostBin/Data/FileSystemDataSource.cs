using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostBin.Models;

namespace PostBin.Data
{
    public class FileSystemDataSource : IDataSource
    {
        const string BasePath = "posts";
        private string GetPath(string id) => Path.Join(BasePath, id + ".json");

        public StatusCode DeletePost(string id, string deleteId)
        {
            Post p = GetPost(id);
            if (p == null) return StatusCode.NotFound;
            if (deleteId != p.Metadata.DeleteId) return StatusCode.Unauthorized;

            File.Delete(GetPath(id));
            return StatusCode.OK;
        }

        private Post GetPost(string id)
        {
            if (!PostExists(id)) return null;
            return JsonConvert.DeserializeObject<Post>(File.ReadAllText(GetPath(id)));
        }

        public PostData GetPostById(string id)
        {
            Post p = GetPost(id);
            if (p == null) return null;
            return p.Data;
        }

        public bool PostExists(string id)
        {
            return File.Exists(GetPath(id));
        }

        public PostMetadata SavePost(PostData data)
        {
            // Generate unique ID
            string id = PostId.Generate();
            while (GetPostById(id) != null)
            {
                id = PostId.Generate();
            }

            Post p = new Post
            {
                Data = data,
                Metadata = new PostMetadata
                {
                    Id = id,
                    DeleteId = PostId.Generate()
                }
            };

            string path = GetPath(id);
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(p));

            return p.Metadata;
        }
    }
}
