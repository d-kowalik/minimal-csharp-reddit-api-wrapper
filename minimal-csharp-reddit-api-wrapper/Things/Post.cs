using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MinimalRedditWrapper.Things
{
    public class Post : Thing
    {
        private PostData _dataCache;
        public new PostData Data => _dataCache ??= base.Data.ToObject<PostData>();
    }
}