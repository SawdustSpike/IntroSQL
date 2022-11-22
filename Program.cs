using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using IntroSQL;
//^^^^MUST HAVE USING DIRECTIVES^^^^

 var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);
/* var repo = new DapperDepartmentRepository(conn);

Console.WriteLine("Type a new Department name");

var newDepartment = Console.ReadLine();

repo.InsertDepartment(newDepartment);

var departments = repo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine(dept.Name);
} */
var prodRepo = new DapperProductRepository(conn);
var products = prodRepo.GetAllProducts();
prodRepo.DisplayAllProducts(products);
Console.WriteLine("What do you want to call the new product?");
var prodName = Console.ReadLine();
Console.WriteLine($"How much are we charging for {prodName}?");
var prodPrice = double.Parse(Console.ReadLine());
Console.WriteLine($"And what catagory would you say {prodName} belongs in? \n" +
    "1- Large Electronics\n" +
    "2- Small Electronics\n" +
    "3- Media\n" +
    "4- Others\n" +
    "9- butts (don't ask)");
var prodID = int.Parse(Console.ReadLine());
prodRepo.CreateProduct(prodName, prodPrice, prodID);
products = prodRepo.GetAllProducts();
prodRepo.DisplayAllProducts(products);
Console.WriteLine("What's the ProductID of the item you wish to go on sale?");
var iD = int.Parse(Console.ReadLine());
Console.WriteLine("What do you want the sale price to be?");
var newPrice = double.Parse(Console.ReadLine());
prodRepo.UpdateProduct(iD, newPrice);
products = prodRepo.GetAllProducts();
prodRepo.DisplayAllProducts(products);
Console.WriteLine($"Okay, we had fun but it's time to say goodbye to the new product. What's the ProductId for {prodName}?");
var killNum = int.Parse(Console.ReadLine());
prodRepo.DeleteProduct(killNum, prodName);
products = prodRepo.GetAllProducts();
prodRepo.DisplayAllProducts(products);











