using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlickrApp.Utility
{
    public class FlickrUtility : IFlickrService
    {
        public static string flickrURL = @"https://www.flickr.com/services/feeds/photos_public.gne";

        public List<Uri> getFlickrXMLForSearchWord(string searchWord)
        {
            List<Uri> ImageURList = new List<Uri>();
            var xraw = XDocument.Load(flickrURL + "?tags=" + searchWord);
            XNamespace ns = xraw.Root.GetDefaultNamespace();
            var entries = xraw.Descendants(ns + "entry");
            foreach (var entry in entries)
            {
                var jpgLinkInfo = entry.Elements(ns + "link").Where(a => a.Attribute("type").Value == "image/jpeg");
                ImageURList.Add(new Uri(jpgLinkInfo.FirstOrDefault().Attribute("href").Value));
            }
            return ImageURList;
        }
    }
}
