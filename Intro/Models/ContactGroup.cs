using System;
using System.Collections.Generic;
using System.Text;

namespace Intro
{
    public class ContactGroup : List<Contact>
    {
        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public ContactGroup(string Title, string ShortTitle)
        {
            this.Title = Title;
            this.ShortTitle = ShortTitle;
        }
    }
}
