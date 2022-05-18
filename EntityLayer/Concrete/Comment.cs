using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }

        #region Relationships 
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        #endregion
    }
}
