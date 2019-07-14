using PostBin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBin.Data
{
    public interface IDataSource
    {
        PostData GetPostById(string id);
        bool PostExists(string id);
        PostMetadata SavePost(PostData data);
        StatusCode DeletePost(string id, string deleteId);
    }

    public enum StatusCode
    {
        OK = 200,
        NotFound = 404,
        Unauthorized = 401
    }
}
