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
        public MProduct UpdateProduct(MProduct product)
        {
            _context.Products.Update(product);
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
        public MCustomer UpdateCustomer(MCustomer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }
        public List<MOrders> GetOrdersWithAllLocations()
        {
            return _context.Orders
            .Select(
                order => new MOrders { 
                    Id = order.Id,
                    Total = order.Total,
                    CustID = order.CustID,
                    LocationID = order.LocationID,
                    date = order.date
                }
            ).ToList();
        }
        public MCustomer GetCustomerById(int id)
        {
            MCustomer customerExists = _context.Customers.FirstOrDefault(cus => cus.Id == id);
            if (customerExists == null) return null;
            return new MCustomer(customerExists.Id, customerExists.Name, customerExists.PhoneNo, customerExists.Address, customerExists.Password);
        }
        public MLocation GetLocationById(int id)
        {
            MLocation locationExists = _context.Locations.FirstOrDefault(loc => loc.Id == id);
            if (locationExists == null) return null;
            return new MLocation(locationExists.Id, locationExists.Name, locationExists.Address);
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
        public List<MOrders> GetOrderByCustomerId(int id)
        {
            /*List<MOrders> mOrders = _context.Orders.Select(
                order => new MOrders()
                {
                    Id = order.Id,
                    CustID = order.CustID,
                    LocationID = order.LocationID,
                    date = order.date,
                    storeFronts = order.storeFronts,
                    customer = order.customer,
                    lineItems = _context.LineItems.Select(
                        orderitem => new MLineItems()
                        {
                            OrderID = orderitem.OrderID,
                            ProId = orderitem.ProId,
                            Quantity = orderitem.Quantity,
                            product = _context.Products.Select(pro => new MProduct
                            {
                                Barcode = pro.Barcode,
                                Name = pro.Name,
                                Price = pro.Price,
                            }).Where(p => p.Barcode == orderitem.ProId).FirstOrDefault(),
                            orders = orderitem.orders
                        }).Where(o => o.OrderID == order.Id).ToList(),
                    Total = order.Total

                }
            ).OrderBy(item => item.date).Where(order => order.CustID == id).ToList();*/

            List<MOrders> mOrders =
                (from o in _context.Orders
                join l in _context.Locations on o.LocationID equals l.Id
                where o.CustID.Equals(id)
                select new MOrders
                {
                    Id = o.Id,
                    CustID = o.CustID,
                    LocationID = o.LocationID,
                    date = o.date,
                    storeFronts = new MLocation { 
                    Id = l.Id,
                    Name=l.Name,
                    Address = l.Address
                    },
                    Total = o.Total
                }).ToList();
            return mOrders;
        }
        public List<MOrders> GetOrderByLocationId(int id)
        {
            List<MOrders> mOrders = 
                (from o in _context.Orders
                    join l in _context.Locations on o.LocationID equals l.Id
                    where o.LocationID.Equals(id)
                    select new MOrders
                    {
                        Id = o.Id,
                        CustID = o.CustID,
                        LocationID = o.LocationID,
                        date = o.date,
                        storeFronts = new MLocation
                        {
                            Id = l.Id,
                            Name = l.Name,
                            Address = l.Address
                        },
                        Total = o.Total
                    }).ToList();
            return mOrders;
        }
        public List<MLineItems> GetAllOrders(int searchedListItemsByOrderId)
        {
            List<MLineItems> result = (
                from li in _context.LineItems
                join o in _context.Orders on li.OrderID equals o.Id
                join p in _context.Products on li.ProId equals p.Barcode
                where li.OrderID.Equals(searchedListItemsByOrderId)
                select new MLineItems
                {
                    Id = li.Id,
                    OrderID = o.Id,
                    ProId = p.Barcode,
                    Quantity = li.Quantity,
                    product = new MProduct
                    {
                        Barcode = p.Barcode,
                        Name = p.Name,
                        Price = p.Price
                    },
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

        public MInventory UpdateInventory(MInventory inventory)
        {
             _context.Inventories.Update(inventory); 
             _context.SaveChanges();
            return inventory;
        }
        
        public List<MInventory> GetInventoryInStore(int id)
        {
            return (from i in _context.Inventories
                    join p in _context.Products on i.ProductId equals p.Barcode
                    join l in _context.Locations on i.StoreId equals l.Id
                    where i.StoreId.Equals(id)
                    let mProduct = new MProduct()
                    {
                        Barcode = p.Barcode,
                        Name = p.Name,
                        Price = p.Price
                    }
                    let mStore = new MLocation()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Address = l.Address
                    }
                    select new MInventory()
                    {
                        Id = i.Id,
                        StoreId = l.Id,
                        ProductId = p.Barcode,
                        Quantity = i.Quantity,
                        Products = mProduct,
                        StoreFront = mStore
                    }).ToList();
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

        public void ItemToAddInOrders(MOrders orders)
        {
            //ItemToUpdateInventory(orders);
            MOrders newOrder = new MOrders
            {
                CustID = orders.CustID,
                LocationID = orders.LocationID,
                Total = orders.Total,
                date = DateTime.Now
            };
            try
            {
                MOrders AddedOrded = _context.Orders.Add(newOrder).Entity;
                _context.SaveChanges();
                ItemToAdd(AddedOrded.Id, orders.lineItems);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ItemToUpdateInventory(MOrders orders)
        {
            
            foreach (MLineItems order in orders.lineItems)
            {
              if(GetProductExitInInventory(order.locations.Id,order.ProId) != null){
                    UpdateInventory(new MInventory
                    {
                        Id = GetInventoryById(GetProductExitInInventory(order.locations.Id,order.ProId).Id).Id,
                        StoreId = orders.LocationID,
                        ProductId = order.ProId,
                        Quantity = GetInventoryById(GetProductExitInInventory(order.locations.Id,order.ProId).Id).Quantity - order.Quantity
                    });
              }
            }
        }

        public MCustomer searchACustomer(MCustomer customer)
        {
            MCustomer found = _context.Customers.FirstOrDefault(pro => pro.PhoneNo == customer.PhoneNo);
            if (found == null) return null;
            return new MCustomer(found.Id, found.Name, found.PhoneNo, found.Address, found.Password);
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
        public MInventory GetProductExitInInventory(int id, string Barcode)
        {
            MInventory AlreadyExits =  _context.Inventories.FirstOrDefault(invPro => invPro.ProductId == Barcode && invPro.StoreId == id);
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
        public MCustomer DeleteCustomer(MCustomer mCustomer)
        {
            MCustomer cusToBeDeleted = _context.Customers.First(cus => cus.Id == mCustomer.Id);
            _context.Customers.Remove(cusToBeDeleted);
            _context.SaveChanges();
            return mCustomer;
        }

        public MProduct GetProductById(string Barcode)
        {
            return _context.Products.Find(Barcode);
        }

        public MProduct DeleteAProduct(MProduct mProduct)
        {
            MProduct toBeDeleted = _context.Products.First(pro => pro.Barcode == mProduct.Barcode);
            _context.Products.Remove(toBeDeleted);
            _context.SaveChanges();
            return mProduct;
        }
    }
}