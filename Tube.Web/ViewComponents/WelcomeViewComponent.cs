using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Tube.Web.Model;
using Tube.Web.Services;

namespace Tube.Web.ViewComponents
{
    public class WelcomeViewComponent : ViewComponent
    {
        private readonly IRepository<Student> _repository;

        public WelcomeViewComponent(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var count = _repository.GetAll().Count().ToString();
            return View("Default",count);
        }
    }
}
