using System;
using System.Collections.Generic;
using System.Text;

namespace MinimalRedditWrapper.Things
{
    class Listing<T>
    {
        public string kind;
        string before;
        string after;
        public ListingData<T> data;
    }
}
