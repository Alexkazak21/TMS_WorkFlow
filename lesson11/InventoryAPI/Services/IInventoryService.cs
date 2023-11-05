using InventoryAPI.Models;
namespace InventoryAPI.Services;

public interface IInventoryService
{
    ProductListModel GetProducts();
    StashListModel GetProductsByCategory();
    ExecResultModel AddProduct(ProductModel product);
    ExecResultModel ChangeProduct(ProductModel product);
    ExecResultModel AllSumOfProducts();
    CategiriesModel GetCategories();
}
