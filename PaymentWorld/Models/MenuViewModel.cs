using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Codebase.Website.Models
{
    public class MenuViewModel
    {
        public bool ShowSlider
        {
            get;
            set;
        }

        public List<LinkTag> ImageList
        {
            get;
            set;
        }

        public string MenuPartialView
        {
            get;
            set;
        }

        public string MenuSliderPartialView
        {
            get;
            set;
        }
    }

    public struct LinkTag
    {
        public string Src
        {
            get;
            set;
        }

        public string Alt
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Usemap
        {
            get;
            set;
        }
    }
}