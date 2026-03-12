// /*

// CRUD
// Create => Create a Category  =>  POST   :  /api/categories
// Read => Read a Category      =>  GET    :  /api/categories
// Update => Update a Category  =>  PUT    :  /api/categories
// Delete => Delete a Category  =>  DELETE :  /api/categories


// */



// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
// app.MapGet("/", () =>
// {
//     return "api is working fine get method";
// });

// app.MapGet("/hello", () =>
// {
//     //int age;
//     var response = new { message = "this is a message from get method", success = true, age = 54, year = 10 };
//     return response;
//     //return "get method call. change 2";
// });

// var products = new List<Product>
//     {
//         new Product("potato", 10),
//         new Product("tomato", 20),
//         new Product("banana", 30),
//         new Product("apple", 40),
//         new Product("orange", 50),
//         new Product("kiwi", 60),
//         new Product("mango", 55)
//     };

// app.MapGet("/products", () =>
// {

//     return Results.Ok(products);
// });

// List<Category> categories = new List<Category>();

// app.MapGet("/api/categories", () =>
// {
//     return Results.Ok(categories);



// });

// app.MapPost("/api/categories", () =>
// {
//     int n;
//     var newCategory = new Category
//     {
//         CategoryId = Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"),
//         CName = "potato",
//         Description = "this is a potato for home to make breakfast",
//         CreatedAt = DateTime.UtcNow
//     };
//     categories.Add(newCategory);
//     return Results.Created($"/api/categories/{newCategory.CategoryId}", newCategory);
// });


// // delete a category

// app.MapDelete("/api/categories/", () =>
// {
//     var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"));
//     if (foundCategory == null)
//     {
//         return Results.NotFound("not found the category with the given id");
//     }
//     categories.Remove(foundCategory);
//     return Results.NoContent();

// });



// app.MapPut("/api/categories/", () =>
// {
//     var foundCategory = categories.FirstOrDefault(category => category.CategoryId == Guid.Parse("d290f1ee-6c54-4b01-90e6-d701748f0851"));
//     if (foundCategory == null)
//     {
//         return Results.NotFound("not found the category with the given id");
//     }
//     foundCategory.CName = "kabir";
//     foundCategory.Description = "update potato to kabir";
//     return Results.NoContent();

// });


// /*app.MapPost("/hello", () =>
// {
//     return Results.Created();
// });

// app.MapPut("/hello", () =>
// {
//     return Results.NoContent();
// });

// app.MapDelete("/hello", () =>
// {
//     return "delete method call  " + Results.NoContent();
// });
// */


// // self practice
// List<productinfo> categoryList = new List<productinfo>();

// app.MapGet("/api/categorys", () =>
// {
//     return Results.Ok(categoryList);
// });
// int i = 0;
// app.MapPost("/api/categorys", () =>
// {


//     var newcategory = new productinfo
//     {
//         ID = i + 1,
//         Name = "potato" + (i + 1),
//         Price = 10
//     };
//     i++;
//     categoryList.Add(newcategory);

//     return Results.Created("/api/categorys", categoryList);


// });



// app.MapDelete("/api/categorys", () =>
// {

//     var foundID = categoryList.FirstOrDefault(categoryList => categoryList.ID == i--);
//     if (foundID == null)
//     {
//         return Results.NotFound($"not found the id{foundID}");
//     }

//     categoryList.Remove(foundID);

//     return Results.NoContent();

// });

// app.Run();

// public record Category
// {
//     public Guid CategoryId
//     {
//         get;
//         set;
//     }
//     public string? CName
//     {
//         get;
//         set;
//     }
//     public string? Description
//     {
//         get;
//         set;
//     }
//     public DateTime CreatedAt
//     {
//         get;
//         set;
//     }

// };
// public record ProductDescription
// {
//     public Guid ProductId
//     {
//         get;
//         set;
//     }
//     public string? Name
//     {
//         get;
//         set;
//     }
//     public int Price
//     {
//         get;
//         set;
//     }

//     public int StockQuantity
//     {
//         get;
//         set;
//     }

//     public string? Description
//     {
//         get;
//         set;
//     }
// };

// public record Product(string Name, decimal Price);

// public record productinfo
// {
//     public int ID
//     {
//         get;
//         set;
//     }
//     public string? Name
//     {
//         get;
//         set;
//     }
//     public decimal Price
//     {
//         get;
//         set;
//     }

// };