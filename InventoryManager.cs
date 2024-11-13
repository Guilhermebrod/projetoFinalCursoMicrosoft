using System;
using System.Collections.Generic;

//class where name, price and stock will be stored
public class InventoryManager
{
    public string name;
    public decimal price;
    public int stock;

    public Product(string name, decimal price, int stock)
    {
        this.name = name;
        this.price = price;
        this.stock = stock;
    }
}
					
public class StockManager {
	
	//list of objects that will hold all of the objects
	static List<Product> products = new List<Product>();

    static void Main(string[]args){
		
		while(true){
		
		//interface for the user to choose what will happen next
        Console.WriteLine("Stock Manager");
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. Update stock");
        Console.WriteLine("3. View products");
        Console.WriteLine("4. Delete product");
		Console.WriteLine("5. Exit");

        string item = Console.ReadLine();
		
		if(item == "5")
			break;

		switch(item){
			case "1":
				AddProduct();
				break;
			case "2":
				UpdateStock();
				break;
			case "3":
				ViewProducts();
				break;
			case "4":
				DeleteProduct();
				break;
			default:
				Console.WriteLine("Invalid item number.");
				break;
			}
			
		}
	
    }
	
	static void AddProduct(){
		
		//the product name, price and stock is asked to the user and saved into variables to be used in the object creation
		Console.WriteLine("Enter product name:");
		
		String name = Console.ReadLine();
		
		Console.WriteLine("Enter product price:");
		
		decimal.TryParse(Console.ReadLine(), out decimal price);
		
		Console.WriteLine("Enter product stock:");
		
		int.TryParse(Console.ReadLine(), out int stock);
		
		products.Add(new Product(name, price, stock));
		
	}
	
	static void UpdateStock(){
		
		//if there is no product the console will warn the user
		if(products.Count != 0){
		
			Console.WriteLine("Choose a product to update its stock:");

			for(int x = 0; x < products.Count; x++){
				
				//list of the products name so the user knows which product he wants to update the stock
				//variable x gets incremented so that the products list starts at 1, and not 0, it gets decremented later when it is used again
				Console.WriteLine((x + 1) + ". " + products[x].name);

			}

			int.TryParse(Console.ReadLine(), out int choice);

			Console.WriteLine("Enter a value to be added to or subtracted from the stock.(To subtract, enter a negative number):");

			int.TryParse(Console.ReadLine(), out int val);

			//the attribute stock gets automatically updated by adding a value the user entered(if it is negative it will subtract)
			products[choice - 1].stock += val;
			
		}
		
		else{
			
			Console.WriteLine("There are no products available.");
		
		}
		
	}
	
	static void ViewProducts(){
		
		//if there is no product the console will warn the user
		if(products.Count != 0){
		
			Console.WriteLine("List of products:");

			for(int x = 0; x < products.Count; x++){
				
				//list of products by name, price and stock
				Console.WriteLine("Name: " + products[x].name + " Price: " + products[x].price + " Stock: " + products[x].stock);

			}
		}
		
		else{
		
			Console.WriteLine("There are no products available.");
		
		}
		
	}
	
	static void DeleteProduct(){
		
		//if there is no product the console will warn the user
		if(products.Count != 0){
	
			Console.WriteLine("Choose a product to be deleted:");

			for(int x = 0; x < products.Count; x++){
				
				//list of the products name so the user knows which product he wants to delete
				//variable x gets incremented so that the products list starts at 1, and not 0, it gets decremented later when it is used again
				Console.WriteLine((x + 1) + ". " + products[x].name);

			}

			int.TryParse(Console.ReadLine(), out int choice);

			//RemoveAt already moves the next items of the list to the left
			products.RemoveAt(choice - 1);
			
		}
		
		else{
			
			Console.WriteLine("There are no products available.");
			
		}
	
	}
	
}