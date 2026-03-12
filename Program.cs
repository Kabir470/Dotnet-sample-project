/*

CRUD
Create => Create a Category  =>  POST   :  /api/categories
Read => Read a Category      =>  GET    :  /api/categories
Update => Update a Category  =>  PUT    :  /api/categories
Delete => Delete a Category  =>  DELETE :  /api/categories


*/



using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/", () =>
{
    return "api is working fine get method";
});


var products = new List<Product>
    {
        new Product("potato", 10),
        new Product("tomato", 20),
        new Product("banana", 30),
        new Product("apple", 40),
        new Product("orange", 50),
        new Product("kiwi", 60),
        new Product("mango", 55)
    };

app.MapGet("/products", () =>
{

    return Results.Ok(products);
});

List<Category> categories = new List<Category>();





// read a category----------------------------------------------------------------
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);



});


// create a category----------------------------------------------------------------
app.MapPost("/api/categories", ([FromBody] Category categoryData) =>
{

    var newCategory = new Category
    {
        CategoryId = Guid.NewGuid(),
        CName = categoryData.CName,
        Description = categoryData.Description,
        CreatedAt = DateTime.UtcNow
    };
    categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);
});


// update a category----------------------------------------------------------------
app.MapPut("/api/categories/", () =>
{
    var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.NewGuid());
    if (foundCategory == null)
    {
        return Results.NotFound("not found the category with the given id");
    }
    foundCategory.CName = "kabir";
    foundCategory.Description = "update potato to kabir";
    return Results.NoContent();

});


// delete a category-------------------------------------------------------------

app.MapDelete("/api/categories/", () =>
{
    var foundCategory = categories.FirstOrDefault();
    if (foundCategory == null)
    {
        return Results.NotFound("not found the category with the given id");
    }
    categories.Remove(foundCategory);
    return Results.NoContent();

});






/*app.MapPost("/hello", () =>
{
    return Results.Created();
});

app.MapPut("/hello", () =>
{
    return Results.NoContent();
});

app.MapDelete("/hello", () =>
{
    return "delete method call  " + Results.NoContent();
});
*/


app.Run();

public record Category
{
    public Guid CategoryId
    {
        get;
        set;
    }
    public string? CName
    {
        get;
        set;
    }
    public string? Description
    {
        get;
        set;
    }
    public DateTime CreatedAt
    {
        get;
        set;
    }

};
public record ProductDescription
{
    public Guid ProductId
    {
        get;
        set;
    }
    public string? Name
    {
        get;
        set;
    }
    public int Price
    {
        get;
        set;
    }

    public int StockQuantity
    {
        get;
        set;
    }

    public string? Description
    {
        get;
        set;
    }
};

public record Product(string Name, decimal Price);

public record productinfo
{
    public int ID
    {
        get;
        set;
    }
    public string? Name
    {
        get;
        set;
    }
    public decimal Price
    {
        get;
        set;
    }

};