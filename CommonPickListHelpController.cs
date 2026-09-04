using Microsoft.AspNetCore.Mvc;
using PJAverageRate.Repository;
namespace PJAverageRate.PickListController
{
    public class CommonPickListHelpController : Controller
    {
        private readonly ICommonPickRepository _repository;

        public CommonPickListHelpController(ICommonPickRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult OpenHelp(string helpCode, string query)
        {
            var data = _repository.GetPickList(query);

            return PartialView("_CommonPick", data);
        }
    }
}
