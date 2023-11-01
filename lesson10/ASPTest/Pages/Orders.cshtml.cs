using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTest.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly ILogger<OrdersModel> _logger;

        public OrdersModel(ILogger<OrdersModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
