using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FlickrApp.Model
{
    public class ImageSourceInfo
    {
        public ImageSource ImageURL { get; set; }
        public string TweetInfo { get; set; }

        public ImageSourceInfo(ImageSource imageURL, string tweetInfo)
        {
            ImageURL = imageURL;
            TweetInfo = tweetInfo;
        }

    }
}
