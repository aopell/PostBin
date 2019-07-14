using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostBin.Data
{
    public static class PostId
    {
        const string Charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static Random rand = new Random();

        public static string Generate() => new string(Enumerable.Range(0, 6).Select(_ => Charset[rand.Next(Charset.Length)]).ToArray());
    }
}
