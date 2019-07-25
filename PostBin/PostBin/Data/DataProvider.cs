using PostBin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBin.Data
{
    public static class DataProvider
    {
        private static IDataSource DataSource = new FileSystemDataSource();

        public static StatusCode DeletePost(string id, string deleteId)
        {
            Post p = DataSource.GetPostById(id);
            if (p == null) return StatusCode.NotFound;
            if (deleteId != p.Metadata.DeleteId) return StatusCode.Unauthorized;

            DataSource.DeletePost(id);
            return StatusCode.OK;
        }

        public static PostData GetPostById(string id)
        {
            return DataSource.GetPostById(id)?.Data;
        }

        public static bool PostExists(string id)
        {
            return DataSource.PostExists(id);
        }

        public static PostMetadata SavePost(PostData data)
        {
            // Generate unique ID
            string id = PostId.Generate();
            while (PostExists(id))
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

            DataSource.SavePost(p);

            return p.Metadata;
        }
    }

    public enum StatusCode
    {
        OK = 200,
        NotFound = 404,
        Unauthorized = 401
    }
}
