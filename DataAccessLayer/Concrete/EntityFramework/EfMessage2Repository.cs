using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Generic;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInboxByWriter(int id)
        {
            using (Context context = new())
            {
                return context.Message2s.Include(x => x.SenderWriter).Where(x => x.ReceiverId == id).ToList();
            }
        }

        public List<Message2> GetSendboxByWriter(int id)
        {
            using (Context context = new())
            {
                return context.Message2s.Include(x => x.ReceiverWriter).Where(x => x.SenderId == id).ToList();
            }
        }
    }
}
