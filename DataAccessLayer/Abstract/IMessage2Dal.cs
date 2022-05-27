using DataAccessLayer.Abstract.Generic;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetInboxByWriter(int id);
        List<Message2> GetSendboxByWriter(int id);
    }
}
