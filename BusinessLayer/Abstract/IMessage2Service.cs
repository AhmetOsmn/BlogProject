using BusinessLayer.Abstract.Generic;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        List<Message2> GetInboxByWriter(int id);
        List<Message2> GetSendboxByWriter(int id);

    }
}
