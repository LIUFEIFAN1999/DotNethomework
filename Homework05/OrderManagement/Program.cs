using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户、订单金额等进行查询）功能。

 *提示：主要的类有Order（订单）、OrderDetails（订单明细），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。
 *在Program里面可以调用OrderService的方法完成各种订单操作。

 要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5） OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
 */

namespace OrderManagement
{
    class Customer
    {
        private string id;
        private string name;
        private string phone;
        private string address;

        public Customer(string id, string name, string phone, string address)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.address = address;
        }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Id { get => id; set => id = value; }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   id == customer.id &&
                   name == customer.name &&
                   phone == customer.phone &&
                   address == customer.address;
        }

        public override int GetHashCode()
        {
            int hashCode = 1926675307;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(address);
            return hashCode;
        }

        public override string ToString()
        {
            return $"\t[Customer]\n\tname:{name}\tphone:{phone}\taddress:{address}\tid:{id}";
        }
    }

    class Goods
    {
        private string name;
        private string description;
        private double price;
        private int weight;

        public Goods(string name, string description, double price, int weight)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.weight = weight;
        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public int Weight { get => weight; set => weight = value; }

        public override bool Equals(object obj)
        {
            return obj is Goods goods &&
                   name == goods.name &&
                   description == goods.description &&
                   price == goods.price &&
                   weight == goods.weight;
        }

        public override int GetHashCode()
        {
            int hashCode = 1442200354;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            hashCode = hashCode * -1521134295 + price.GetHashCode();
            hashCode = hashCode * -1521134295 + weight.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"\t\t[Goods]\n\t\tname:{name}\tprice:{price}\tweight:{weight}\tdescription:{description}";
        }
    }
    class OrderDetails
    {
        private string id;
        private Goods goods;
        private int count;

        public OrderDetails(string id, Goods goods, int count)
        {
            this.id = id;
            this.Goods = goods;
            this.count = count;
        }

        public string Id { get => id; set => id = value; }
        public int Count { get => count; set => count = value; }
        public double Amount { get => goods.Price * count; }
        public Goods Goods { get => goods; set => goods = value; }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   id == details.id &&
                   EqualityComparer<Goods>.Default.Equals(goods, details.goods) &&
                   count == details.count;
        }

        public override int GetHashCode()
        {
            int hashCode = -720357890;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(goods);
            hashCode = hashCode * -1521134295 + count.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"\t[OrderDetails]\n\tid:{id}\n{goods}\tcount:{count}\tamount:{Amount}";
        }
    }
    class Order: IComparable
    {
        private string id;
        private Customer customer;
        private List<OrderDetails> items;

        public Order(string id, Customer customer)
        {
            this.id = id;
            this.customer = customer;
            items = new List<OrderDetails>();
        }
        public string Id { get => id; set => id = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public double Amount
        {
            get
            {
                double amount = 0;
                foreach(OrderDetails item in items)
                {
                    amount += item.Amount;
                }
                return amount;
            }
        }
        public List<OrderDetails> Items { get => items; set => items = value; }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   id == order.id &&
                   EqualityComparer<Customer>.Default.Equals(customer, order.customer) &&
                   EqualityComparer<List<OrderDetails>>.Default.Equals(items, order.items);
        }

        public override int GetHashCode()
        {
            int hashCode = 2005747568;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderDetails>>.Default.GetHashCode(items);
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder orderInfo = new StringBuilder($"[Order]\nid:{id}\n{customer}");
            foreach(OrderDetails item in items)
            {
                orderInfo.Append("\n");
                orderInfo.Append(item);
            }
            return orderInfo.ToString();
        }

        public int CompareTo(object obj)
        {
            Order order = obj as Order;
            if (order == null)
            {
                throw new ArgumentException();
            }
            return this.Id.CompareTo(order.Id);
        }
    }
    class OrderService
    {
        private List<Order> orderList;

        public OrderService()
        {
            orderList = new List<Order>();
        }
        public void Add(Order order)
        {
            orderList.Add(order);
        }

        public void Delete(Order order)
        {
            try
            {
                orderList.Remove(order);
            }catch(NullReferenceException e)
            {
                throw new NullReferenceException($"{e.Message}:订单不存在");
            }
        }

        public void Modify_AddItem(Order order, OrderDetails item)
        {
            try
            {
                int orderIndex = orderList.IndexOf(order);
                List<OrderDetails> items = orderList[orderIndex].Items;
                items.Add(item);
                orderList[orderIndex].Items = items;
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"{e.Message}:订单参数错误");
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException($"{e.Message}:订单不存在");
            }
        }

        public void Modify_DeleteItem(Order order, OrderDetails item)
        {
            try
            {
                int orderIndex = orderList.IndexOf(order);
                List<OrderDetails> items = orderList[orderIndex].Items;
                items.Remove(item);
                orderList[orderIndex].Items = items;
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException($"{e.Message}:订单参数错误");
            }
            catch (IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException($"{e.Message}:订单不存在");
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException($"{e.Message}:订单明细不存在");
            }
        }
        public List<Order> QueryById(string id)
        {
            var query = orderList.Where(order => order.Id == id).OrderBy(order => order.Amount);
            return query.ToList();
        }
        public List<Order> QueryByName(string name)
        {
            List<Order> orders = new List<Order>();
            foreach(Order order in orderList)
            {
                var query = order.Items.Where(item => item.Goods.Name == name);
                if(query.FirstOrDefault() != null)
                {
                    orders.Add(order);
                }
            }
            orders.Sort((order1, order2) => (int)(order1.Amount - order2.Amount));
            return orders;
        }
        public List<Order> QueryByCustomer(Customer customer)
        {
            var query = orderList.Where(order => order.Customer.Equals(customer)).OrderBy(order => order.Amount);
            return query.ToList();
        }
        public List<Order> QueryByAmount(double amount)
        {
            var query = orderList.Where(order => order.Amount == amount).OrderBy(order => order.Amount);
            return query.ToList();
        }

        public void Sort()
        {
            orderList.Sort((Order p1, Order p2)=>p1.CompareTo(p2));
        }

        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("00001", "LiuFeifan", "123456789", "WuHan");
            Goods pc = new Goods("computer", "Lenovo 16G 512G i5", 4325.99, 1000);
            Goods guitar = new Goods("guitar", "Mesopotamia S200 41", 2680, 2000);
            OrderDetails item1 = new OrderDetails("00001", pc, 1);
            OrderDetails item2 = new OrderDetails("00002", guitar, 2);
            Order order = new Order("00001", customer);
            OrderService orderService = new OrderService();
            orderService.Add(order);
            orderService.Modify_AddItem(order, item1);
            orderService.Modify_AddItem(order, item2);
            List<Order> queryOrderList = orderService.QueryByCustomer(customer);
            foreach(Order myOrder in queryOrderList)
            {
                Console.WriteLine(myOrder);
            }
            queryOrderList = orderService.QueryByName("guitar");
            foreach (Order myOrder in queryOrderList)
            {
                Console.WriteLine(myOrder);
            }
        }
    }
}
