﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrApp.Model
{



    public class TwitterJSON
    {
        public List<Datum> data { get; set; }
        public Meta meta { get; set; }
    }
    public class Datum
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class Meta
    {
        public string newest_id { get; set; }
        public string oldest_id { get; set; }
        public int result_count { get; set; }
        public string next_token { get; set; }
    }


}
