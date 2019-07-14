using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostBin.Models;

namespace PostBin.Data
{
    public class SQLServerDataSource : IDataSource
    {
        public StatusCode DeletePost(string id, string deleteId)
        {
            throw new NotImplementedException();
        }

        public PostData GetPostById(string id)
        {
            throw new NotImplementedException();
        }

        public bool PostExists(string id)
        {
            throw new NotImplementedException();
        }

        public PostMetadata SavePost(PostData data)
        {
            throw new NotImplementedException();
        }
    }
}
