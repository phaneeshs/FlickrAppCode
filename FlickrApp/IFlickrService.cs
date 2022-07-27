using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrApp
{
    interface IFlickrService
    {
         List<Uri> getFlickrXMLForSearchWord(string searchWord);
    }
}
