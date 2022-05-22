using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message item)
        {
            _messageDal.Add(item);
        }

        public void Delete(Message item)
        {
            _messageDal.Delete(item);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> GetInboxByWriter(string mail)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == mail);
        }

        public void Update(Message item)
        {
            _messageDal.Update(item);
        }
    }
}
