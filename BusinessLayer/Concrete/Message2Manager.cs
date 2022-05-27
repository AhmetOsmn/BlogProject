using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messsage2Dal;

        public Message2Manager(IMessage2Dal messsage2Dal)
        {
            _messsage2Dal = messsage2Dal;
        }

        public void Add(Message2 item)
        {
            _messsage2Dal.Add(item);
        }

        public void Delete(Message2 item)
        {
            _messsage2Dal.Delete(item);
        }

        public List<Message2> GetAll()
        {
            return _messsage2Dal.GetAll();
        }

        public Message2 GetById(int id)
        {
            return _messsage2Dal.GetById(id);
        }

        public List<Message2> GetInboxByWriter(int id)
        {
            return _messsage2Dal.GetInboxByWriter(id);
        }

        public List<Message2> GetSendboxByWriter(int id)
        {
            return _messsage2Dal.GetSendboxByWriter(id);
        }

        public void Update(Message2 item)
        {
            _messsage2Dal.Update(item);
        }
    }
}
