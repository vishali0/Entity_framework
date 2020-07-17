using System;
//using Crud_Operation.Models;
using Crud_Operation.Repository;
using System.Linq;
using System.Security.Cryptography;
using Crud_Operation.NewFolder;
//using codeFirstApproach.Repository;

namespace Crud_Operation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ApplicationDbContext _db = new ApplicationDbContext();            
            CustomerRepository customer4 = new CustomerRepository();

            Console.WriteLine("#######################################################################################################");
            Console.WriteLine("################################## CODE FIRST APPROACH #################################################");
            Console.WriteLine("#######################################################################################################");


            Console.WriteLine();
            Console.WriteLine("-----------------------------------------Customer Insertion----------------------------------------------");
            InsertData(_db);

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------Getting AllCustomer Details-------------------------------------------");
            //reading data
            ReadData(_db);


            var customer = _db.Customers.Where(a => a.Id == 2).FirstOrDefault();
            Console.WriteLine();
            
            Console.WriteLine("----------------------------------------Get Customer Details with condition-------------------------------------");
            
            Console.WriteLine();
            Console.WriteLine("Id\t" + "Name\t" + "Email\t\t\t" + "Location\t" + "Address\t" + "IsActive\t");

            if (customer!=null)
            {
                Console.WriteLine(customer.Id+"\t"+ customer.Name + "\t"+customer.Email + "\t\t"+customer.Location + "\t\t"+customer.Address + "\t"+customer.IsActive
                    + "\t");
            }
            //reading data
            //ReadData(_db);


            Console.WriteLine();
            Console.WriteLine("----------------------------------------Get Customer Details after updation-------------------------------------");

            Console.WriteLine("Please Enter Id to update");
            int id = Convert.ToInt32(Console.ReadLine());

            var customer2 = _db.Customers.Where(a => a.Id == id).FirstOrDefault();
            if (customer2!=null)
            {
            //    //write code for updating data
                customer2.Name = "#Guvi";
                _db.SaveChanges();

            }
            else
            {
               Console.WriteLine("no person found for this id");
            }
            //reading data
            ReadData(_db);
            

           

            Console.WriteLine();
            Console.WriteLine("----------------------------------------Get Customer Details after Deletion-------------------------------------");


            Console.WriteLine("Please Enter Id to delete");
            int id_d = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("User details after deleting id(7) ");
            customer4.DeleteCustomer(id_d);
            //reading data
            ReadData(_db);

            Console.WriteLine();
            Console.WriteLine("----------------------------------------Get Customer Details who are Active-------------------------------------");


            Console.WriteLine("User details are Active ");
            customer4.ActiveCustomers();
            //reading data
            ReadData(_db);

            Console.WriteLine();
            Console.WriteLine("----------------------------------------Get Customer Details after Adding New row-------------------------------------");


            Customer addCustomer = new Customer();
            addCustomer.Id = 111;
            addCustomer.Name = "Vysh";
            addCustomer.Email = "vysh@gmail.com";
            addCustomer.Location = "Hyderabad";
            addCustomer.Address = "Street1";
            addCustomer.IsActive = true;
            Console.WriteLine();
            customer4.AddCustomer(addCustomer);
            //reading data
            ReadData(_db);

            static void InsertData(ApplicationDbContext _db)
            {
                Customer c = new Customer();
                Console.WriteLine("Enter Name");
                c.Name = Console.ReadLine();

                Console.WriteLine("Enter Location");
                c.Location = Console.ReadLine();

               
                Console.WriteLine("Enter Address");
                c.Address = Console.ReadLine();

                
                c.Email = "vish@gmail.com";
                c.IsActive = true;
                

                _db.Customers.Add(c);
                _db.SaveChanges();
            }

            static void ReadData(ApplicationDbContext _db)
            {

                var customer1 = _db.Customers.ToList();
                Console.WriteLine("Id\t" + "Name\t" + "Email\t\t\t" + "Location\t" + "Address\t" + "IsActive\t");
                if (customer1.Any())
                {
                    foreach (var item in customer1)
                    {
                        Console.WriteLine(item.Id + " \t" + item.Name + "\t " + item.Email + "\t\t" + item.Location + "\t\t"+ item.Address + "\t"+ item.IsActive);
                    }
                }
                else
                {
                    Console.WriteLine("no data found");
                }
            }

            Console.WriteLine();
            
           
        }
    }
}
