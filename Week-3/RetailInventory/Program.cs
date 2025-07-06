using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;
class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        var electronics = new Category { Name = "Electronics" };
        var groceries = new Category { Name = "Groceries" };

        await context.Categories.AddRangeAsync(electronics, groceries);

        var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
        var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

        await context.Products.AddRangeAsync(product1, product2);
        await context.SaveChangesAsync();

//5.1
        var products = await context.Products.ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - ₹{p.Price}");
        }
//5.2
            var product = await context.Products.FindAsync(25);
        Console.WriteLine($"Found: {product?.Name}");
//5.3
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"Expensive: {expensive?.Name}");
//6.1
        var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        if (product != null)
        {
            product.Price = 70000; await context.SaveChangesAsync();
        }
//6.2
        var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
        if (toDelete != null)
        {
            context.Products.Remove(toDelete);
            await context.SaveChangesAsync();
        }
        var products = await context.Products.ToListAsync();
        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.Name} - ₹{prod.Price}");
            Console.WriteLine("Rice has been deleted");
        }

//7.1
        var filtered = await context.Products.Where(p => p.Price > 1000).OrderByDescending(p => p.Price).ToListAsync();
        foreach (var p in filtered)
        {
            Console.WriteLine($"{p.Name}-₹{p.Price}");
        }
//7.2
        var productDTOs = await context.Products.Select(p => new {p.Name,p.Price}).ToListAsync();
        Console.WriteLine("\nProjected DTOs (Name + Price):");
        foreach (var dto in productDTOs)
        {
            Console.WriteLine($"{dto.Name} - ₹{dto.Price}");
        }
}
}