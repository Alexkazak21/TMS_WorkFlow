using InventoryAPI.Models;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _secvice;

    public InventoryController(IInventoryService secvice)
    {
        _secvice = secvice;
    }

    public static List<ProductModel> Products { get; } = new List<ProductModel>();

    [HttpPost]
    public ProductListModel GetProducts()
    {
        return _secvice.GetProducts();
    }

    [HttpPost]
    public CategiriesModel GetCategories()
    {
        return _secvice.GetCategories();
    }
    /// <summary>
    /// To find all available categories use GetCategotyes()
    /// </summary>
    /// <param name="model">Specify data in apropriate format mentioned below</param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddProduct([FromBody] ProductModel model)
    {
        var result = _secvice.AddProduct(model);

        if (!result.Seccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult ChangeProduct([FromBody] ProductModel model)
    {
        var result = _secvice.ChangeProduct(model);

        if (!result.Seccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
