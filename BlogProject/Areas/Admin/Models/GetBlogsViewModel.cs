using System;

namespace BlogProject.Areas.Admin.Models
{
    public class GetBlogsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
