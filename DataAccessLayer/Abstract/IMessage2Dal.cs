using DataAccessLayer.Abstract.Generic;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetMessageListByWriter(int id);
    }
}
