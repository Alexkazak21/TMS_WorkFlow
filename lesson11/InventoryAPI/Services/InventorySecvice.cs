using InventoryAPI.Models;
using System.Text.Json;

namespace InventoryAPI.Services;

public class InventorySecvice : IInventoryService
{
    public List<ProductModel> Products { get; } = new List<ProductModel>();
    public List<string> Categogies { get; } = new List<string>(JsonSerializer.Deserialize<List<string>>(File.ReadAllText("Categories.json")));

    public CategiriesModel GetCategories()
    {
        return new CategiriesModel()
        {
            Categiries = new List<string>(Categogies.Select(x => x))
        };
    }
    public ExecResultModel AddProduct(ProductModel product)
    {
        if (string.IsNullOrWhiteSpace(product.Id))
        {
            return new ExecResultModel
            {
                Seccess = false,
                Message = "No such Product was found"
            };
        }

        if (product.Amount < 0)
        {
            return new ExecResultModel
            {
                Seccess = false,
                Message = "You can`t add negative ammount of Product"
            };
        }

        if (product.Price < 0)
        {
            return new ExecResultModel
            {
                Seccess = false,
                Message = "Pric can`t be less then ZERO"
            };
        }

        foreach (var item in Products)
        {
            if (item.Id == product.Id)
            {
                return new ExecResultModel
                {
                    Seccess = false,
                    Message = "Product already exist"
                };
            }
        }


        Products.Add(new ProductModel
        {
            Id = product.Id,
            Amount = product.Amount,
            Price = product.Price,
            Category = product.Category,
        });

        return new ExecResultModel
        {
            Seccess = true,
            Message = "Product was secsessfully added"
        };
    }

    public ExecResultModel AllSumOfProducts()
    {
        decimal totalSum = 0;

        foreach (var item in Products)
        {
            totalSum += (item.Amount * item.Price);
        }

        if (totalSum < 0)
        {
            return new ExecResultModel
            {
                Seccess = false,
                Message = $"Total sum of products is less then zero",
            };
        }

        return new ExecResultModel
        {
            Seccess = true,
            Message = $"Total sum of products in stash is {totalSum}",
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product">Change will de allowed only by ID of product</param>
    /// <returns></returns>
    public ExecResultModel ChangeProduct(ProductModel product)
    {
        if (string.IsNullOrWhiteSpace(product.Id))
        {
            return new ExecResultModel
            {
                Seccess = false,
                Message = "No such Product was found"
            };
        }

        bool productDeleted = false;
        foreach (var item in Products)
        {
            if (item.Id == product.Id)
            {
                productDeleted = true;
            }
        }

        if (productDeleted)
        {

            Products.Remove(Products.First(x => x.Id == product.Id));
            Products.Add(new ProductModel
            {
                Id = product.Id,
                Amount = product.Amount,
                Price = product.Price,
                Category = product.Category,
            });
        }
        else
        {
            return new ExecResultModel
            {
                Seccess = false,
                Message = $"Product with ID = {product.Id} doesn`t exits"
            };
        }


        return new ExecResultModel
        {
            Seccess = true,
            Message = $"Product {product.Id} was updated",
        };

    }

    public ProductListModel GetProducts()
    {
        return new ProductListModel
        {
            Products = Products.ToArray(),
        };
    }

    public StashListModel GetProductsByCategory()
    {
        StashModel[] stash = new StashModel[Categogies.Count];


        for (int i = 0; i < Categogies.Count; i++)
        {
            stash[i] = new StashModel();
            stash[i].Category = Categogies[i];
            stash[i].Inventoties = Products.Where(x => x.Category == Categogies[i]).ToList();
        }

        return new StashListModel() { AllStash = stash.ToArray() };
    }
}
