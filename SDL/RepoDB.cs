using Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SDL
{
    public class RepoDB : IRepository
    {
        private ChocolatefactoryContext _context;
        public RepoDB(ChocolatefactoryContext context)
        {
            this._context = context;
        }
        public MCustomer AddCustomer(MCustomer customer)
        {
            //this records the change in the cotext change tracker that we want to add this particular entity
            // to the db 
            _context.Customers.Add(
                new MCustomer
                {
                    Name = customer.Name,
                    PhoneNo = customer.PhoneNo,
                    Address = customer.Address
                }
            );
            //this persists the chnage to the database
            _context.SaveChanges();
            return customer;
        }

        public MProduct AddProduct(MProduct product)
        {
            _context.Products.Add(
                new MProduct
                {
                    Barcode = product.Barcode,
                    Name = product.Name,
                    Price = product.Price
                }
             );
            _context.SaveChanges();
            return product;
        }

        public MLocation AddStore(MLocation location)
        {
            _context.Locations.Add(
                    new MLocation
                    {
                        Name = location.Name,
                        Address = location.Address
                    }
                );
            _context.SaveChanges();
            return location;
        }

        public List<MCustomer> GetAllCustomers()
        {
            return _context.Customers
            .Select(
                customer => new MCustomer(customer.Id, customer.Name, customer.PhoneNo, customer.Address, customer.Password)
            ).ToList();
        }
        public List<MLocation> GetAllLocation()
        {
            return _context.Locations.Select(
                locat => new MLocation(
                            locat.Id,
                            locat.Name,
                            locat.Address)
                ).ToList();
        }

        public List<MOrders> GetAllOrders(MLocation searchedOrdersInStore)
        {
            List<MOrders> result = (
                from o in _context.Orders
                join c in _context.Customers on o.CustID equals c.Id
                join l in _context.Locations on o.storeFronts.Id equals l.Id
                where o.storeFronts.Id.Equals(searchedOrdersInStore.Id)
                select new MOrders()
                {
                    Id = o.Id,
                    Total = o.Total,
                    customer = new MCustomer()
                    {
                        Name = c.Name,
                        PhoneNo = c.PhoneNo,
                        Address = c.Address
                    },
                    storeFronts = new MLocation()
                    {
                        Name = l.Name,
                        Address = l.Address
                    }
                }
            ).ToList();
            return result;
        }

        public List<MProduct> GetAllProductss()
        {
            return _context.Products.Select(
                product => new MProduct(product.Barcode, product.Name, product.Price)
            ).ToList();
        }
        public MProduct GetAProduct(MProduct product)
        {
            MProduct found = _context.Products.FirstOrDefault(pro => pro.Barcode == product.Barcode && pro.Name == product.Name && pro.Price == product.Price);
            if (found == null) return null;
            return new MProduct(found.Barcode, found.Name, found.Price);
        }

        public MLocation GetAStore(MLocation location)
        {
            MLocation found = _context.Locations.FirstOrDefault(store => store.Name == location.Name && store.Address == location.Address);
            if (found == null) return null;
            return new MLocation(found.Id, found.Name, found.Address);
        }

        public List<MInventory> GetProductInStock(MLocation mLocation)
        {
            return _context.Inventories.Where(inv => inv.StoreId == mLocation.Id).Select(
                invent => new MInventory
                {
                    StoreId = invent.StoreId,
                    ProductId = invent.ProductId,
                    Quantity = invent.Quantity
                }
            ).ToList();
        }
        List<MLocation> GetStoreById(int id)
        {
            return _context.Locations.Where(s => s.Id == id).Select(store => new MLocation
            {
                Id = store.Id,
                Name = store.Name,
                Address = store.Address
            }).ToList();
        }

        public MInventory UpdateInventory(MInventory inventory)
        {
             _context.Inventories.Update(inventory); 
             _context.SaveChanges();
            return inventory;
        }
        
        public List<MInventory> GetInventoryInStore(int id)
        {
            return _context.Inventories.Where(inv => inv.StoreId == id).Select(
                 invent => new MInventory
                 {
                     Id = invent.Id,
                     StoreId = invent.StoreId,
                     ProductId = invent.ProductId,
                     Quantity = invent.Quantity
                 }
             ).ToList();
        }

        public List<MProduct> GetProductsInventory(MInventory inventory)
        {
            return _context.Products.Where(pro => pro.Barcode == inventory.ProductId).Select(
                prod =>
                new MProduct
                {
                    Barcode = prod.Barcode,
                    Name = prod.Name,
                    Price = prod.Price
                }
            ).ToList();
        }

        public void ItemToAdd(int orderid, List<MLineItems> lineItems)
        {
            foreach (MLineItems item in lineItems)
            {
                MLineItems line1 = _context.LineItems.Add(
                    new MLineItems
                    {
                        OrderID = orderid,
                        ProId = item.ProId,
                        Quantity = item.Quantity
                    }
                ).Entity;
            }
            _context.SaveChanges();
        }
        // public void ItemToUpdateInventory(MOrders orders){
        //     Entity.Inventory inventory = new Entity.Inventory{

        //     }
        // }
        public void ItemToAddInOrders(MOrders orders)
        {
            MOrders newOrder = new MOrders
            {
                CustID = orders.CustID,
                LocationID = orders.LocationID,
                Total = orders.Total
            };
            try
            {
                MOrders AddedOrded = _context.Orders.Add(newOrder).Entity;
                _context.SaveChanges();
                ItemToAdd(AddedOrded.Id, orders.lineItems);
                // ItemToUpdateInventory(orders);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public MCustomer searchACustomer(MCustomer customer)
        {
            MCustomer found = _context.Customers.FirstOrDefault(pro => pro.PhoneNo == customer.PhoneNo);
            if (found == null) return null;
            return new MCustomer(found.Name, found.PhoneNo, found.Address, found.Password);
        }

        public MProduct searchAProduct(string barcode)
        {
            MProduct found = _context.Products.FirstOrDefault(prod1 => prod1.Barcode == barcode);
            if (found == null) return null;
            return new MProduct(found.Barcode, found.Name, found.Price);
        }

        public MInventory AddProductInInventory(MInventory mInventory)
        {
            _context.Inventories.Add(
                new MInventory
                {
                    StoreId = mInventory.StoreId,
                    ProductId = mInventory.ProductId
                });
            _context.SaveChanges();
            return mInventory;
        }

        public MInventory GetInventoryById(int id)
        {
            MInventory found = _context.Inventories.FirstOrDefault(inv => inv.Id == id);
            if (found == null) return null;
            return new MInventory(found.Id, found.StoreId, found.ProductId, found.Quantity);
        }
        public void DeleteAProduct(string barcode)
        {
            MProduct toBeDeleted = _context.Products.First(pro => pro.Barcode == barcode);
            _context.Products.Remove(toBeDeleted);
            _context.SaveChanges();
        }
        public MInventory GetProductExitInInventory(string Barcode)
        {
            MInventory AlreadyExits =  _context.Inventories.FirstOrDefault(invPro => invPro.ProductId == Barcode);
            if (AlreadyExits == null) return null;
            return new MInventory(AlreadyExits.Id, AlreadyExits.StoreId, AlreadyExits.ProductId, AlreadyExits.Quantity);
        }
        public MInventory DeleteInventory(MInventory mInventory)
        {
            MProduct proToBeDeleted = _context.Products.First(pro => pro.Barcode == mInventory.ProductId);
            _context.Products.Remove(proToBeDeleted);
            _context.SaveChanges();
            MInventory toBeDeleted = _context.Inventories.First(inv => inv.Id == mInventory.Id);
            _context.Inventories.Remove(toBeDeleted);
            _context.SaveChanges();
            return mInventory;
        }
    }
}