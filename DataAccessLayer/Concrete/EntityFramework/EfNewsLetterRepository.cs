﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Generic;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfNewsLetterRepository : GenericRepository<NewsLetter>, INewsLetterDal
    {
    }
}
