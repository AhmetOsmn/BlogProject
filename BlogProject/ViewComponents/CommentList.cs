using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogProject.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    UserName="Ahmet"
                },     new UserComment
                {
                    Id = 2,
                    UserName="Mert"
                },     new UserComment
                {
                    Id = 3,
                    UserName="Emre"
                },
            };
            return View(commentValues);
        }
    }
}
