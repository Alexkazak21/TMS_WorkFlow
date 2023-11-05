using InventoryAPI.Models;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class StashController : ControllerBase
{
    private readonly IInventoryService _secvice;

    public StashController(IInventoryService secvice)
    {
        _secvice = secvice;

    }

    [HttpPost]
    public StashListModel GetProductsByCategory()
    {
        return _secvice.GetProductsByCategory();
    }

    [HttpPost]
    public IActionResult AllSumOfProducts()
    {
        var rerult = _secvice.AllSumOfProducts();

        if (!rerult.Seccess)
        {
            return BadRequest(rerult.Message);
        }

        return Ok(rerult);
    }
}