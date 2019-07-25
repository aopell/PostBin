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

        public void DeletePost(string id)
        {
            File.Delete(GetPath(id));
        }

        public Post GetPostById(string id)
        {
            if (!PostExists(id)) return null;
            return JsonConvert.DeserializeObject<Post>(File.ReadAllText(GetPath(id)));
        }

        public bool PostExists(string id)
        {
            return File.Exists(GetPath(id));
        }

        public void SavePost(Post p)
        {
            string path = GetPath(p.Metadata.Id);
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(p));
        }
    }
}
