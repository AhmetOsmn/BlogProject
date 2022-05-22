using BusinessLayer.Abstract.Generic;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetInboxByWriter(string mail);
    }
}
