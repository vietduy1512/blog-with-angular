using NTT_BlogEngine.DAL.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTT_BlogEngine.ViewModels
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }

    public class PostIndexViewModel
    {
        public IPagedList<Post> PostList { get; set; }
        public List<Comment> RecentComment { get; set; }
    }
}