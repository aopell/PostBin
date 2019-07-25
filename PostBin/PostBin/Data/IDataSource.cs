using PostBin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBin.Data
{
    public interface IDataSource
    {
        Post GetPostById(string id);
        bool PostExists(string id);
        void SavePost(Post p);
        void DeletePost(string id);
    }
}
