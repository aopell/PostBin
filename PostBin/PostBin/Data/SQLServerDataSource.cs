using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostBin.Models;

namespace PostBin.Data
{
    public class SQLServerDataSource : IDataSource
    {
        public void DeletePost(string id)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(string id)
        {
            throw new NotImplementedException();
        }

        public bool PostExists(string id)
        {
            throw new NotImplementedException();
        }

        public void SavePost(Post p)
        {
            throw new NotImplementedException();
        }
    }
}
