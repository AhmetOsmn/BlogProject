using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        #region Reletionships
        public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2> SenderWriter { get; set; }
        public virtual ICollection<Message2> ReceiverWriter { get; set; }

        #endregion

    }
}
