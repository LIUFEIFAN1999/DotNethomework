using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Threading.Tasks;


/*
 *  1、在上次作业的OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；
 *     添加一个Import方法可以从XML文件中载入订单。
    2、对订单程序中OrderService的各个Public方法添加测试用例。

 */
namespace OrderAddXML
{
    [Serializable]
    public class Customer
    {
        private string id;
        private string name;
        private string phone;

        public Customer() { }
        public Customer(string id, string name, string phone)
        {
            this.id = id;
            this.name = name;
            this.phone = phone;
        }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Id { get => id; set => id = value; }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   id == customer.id &&
                   name == customer.name &&
                   phone == customer.phone;
        }

        public override int GetHashCode()
        {
            int hashCode = 1926675307;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(phone);
            return hashCode;
        }

        public override string ToString()
        {
            return $"\t[Customer]\n\tname:{name}\tphone:{phone}\tid:{id}";
        }
    }

    [Serializable]
    public class Goods
    {
        private string name;
        private string description;
        private double price;
        private int weight;

        public Goods() { }
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

    [Serializable]
    public class OrderDetails
    {
        private Goods goods;
        private int count;

        public OrderDetails() { }
        public OrderDetails(Goods goods, int count)
        {
            this.goods = goods;
            this.count = count;
        }

        public int Count { get => count; set => count = value; }
        public double Amount { get => goods.Price * count; }
        public Goods Goods { get => goods; set => goods = value; }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details &&
                   details != null &&
                   EqualityComparer<Goods>.Default.Equals(goods, details.goods);
        }

        public override int GetHashCode()
        {
            int hashCode = -720357890;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(goods);
            hashCode = hashCode * -1521134295 + count.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"\t[OrderDetails]\n{goods}\tcount:{count}\tamount:{Amount}";
        }
    }
    
    [Serializable]
    public class Order : IComparable
    {
        private string id;
        private Customer customer;
        private string address;
        private List<OrderDetails> itemList = new List<OrderDetails>();

        public Order() { }
        public Order(string id, Customer customer, string address, OrderDetails item)
        {
            this.id = id;
            this.customer = customer;
            this.address = address;
            itemList.Add(item);
        }
        public string Id { get => id; set => id = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public string Address { get => address; set => address = value; }
        public List<OrderDetails> ItemList { get => itemList; set => itemList = value; }
        public double Amount
        {
            get
            {
                double amount = 0;
                foreach (OrderDetails item in itemList)
                {
                    amount += item.Amount;
                }
                return amount;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   order != null & id == order.id;
        }

        public override int GetHashCode()
        {
            int hashCode = 2005747568;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderDetails>>.Default.GetHashCode(itemList);
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder orderInfo = new StringBuilder($"[Order]\nid:{id}\n{customer}");
            foreach (OrderDetails item in itemList)
            {
                orderInfo.Append("\n");
                orderInfo.Append(item);
            }
            return orderInfo.ToString();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Order order))
            {
                throw new ArgumentException();
            }
            return this.Id.CompareTo(order.Id);
        }
    }
    public class OrderService
    {
        private List<Order> orderList = new List<Order>();

        public List<Order> OrderList { get => orderList; }

        public OrderService() { }

        public void Add(Order order)
        {
            if(orderList.Exists(o => o.Id == order.Id))
            {
                throw new OrderException("添加失败：订单已存在");
            }
            orderList.Add(order);
        }

        public void Delete(string orderId)
        {
            if(orderList.RemoveAll(order => order.Id == orderId) == 0)
            {
                throw new OrderException("删除失败：订单不存在");
            }
        }

        public void Modify_AddItem(string orderId, OrderDetails item)
        {
            int orderIndex = orderList.FindIndex(order => order.Id == orderId);
            if(orderIndex == -1)
            {
                throw new OrderException("添加失败：订单不存在");
            }
            int itemIndex = orderList[orderIndex].ItemList.FindIndex(_item => _item.Goods.Equals(item.Goods));
            if(itemIndex == -1)
            {
                orderList[orderIndex].ItemList.Add(item);
            }
            else
            {
                orderList[orderIndex].ItemList[itemIndex].Count += item.Count;            
            }
        }

        public void Modify_DeleteItem(string orderId, OrderDetails item)
        {
            int orderIndex = orderList.FindIndex(order => order.Id == orderId);
            if (orderIndex == -1)
            {
                throw new OrderException("删除失败：订单不存在");
            }
            if (orderList[orderIndex].ItemList.RemoveAll(items => items.Equals(item)) == 0)
            {
                throw new OrderException("删除失败：订单明细不存在");
            }
        }

        public void ModifyAddress(string orderId, string newAddress)
        {
            int orderIndex = orderList.FindIndex(order => order.Id == orderId);
            if (orderIndex == -1)
            {
                throw new OrderException("修改失败：订单不存在");
            }
            orderList[orderIndex].Address = newAddress;
        }

        public List<Order> QueryAll()
        {
            return orderList;
        }
        public Order QueryById(string id)
        {
            var query = orderList.Where(order => order.Id == id).FirstOrDefault();
            return query;
        }
        public List<Order> QueryByName(string name)
        {
            var query = orderList.Where(order => order.ItemList.Any(
                item => item.Goods.Name == name
                )
            );
            return query.ToList();
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
            orderList.Sort((Order p1, Order p2) => p1.CompareTo(p2));
        }

        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }

        public void Export(string fileName)
        {
            XmlSerializer xmlSerializier = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xmlSerializier.Serialize(fs, orderList);
            }
        }

        public void Import(string filePath)
        {
            XmlSerializer xmlSerializier = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                List<Order> orders = (List<Order>)xmlSerializier.Deserialize(fs);
                if (orders == null) return;
                orderList.Union(orders);
            }
        }
    }

    public class OrderException : ApplicationException
    {
        public OrderException(string message) : base(message) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Customer customer1 = new Customer("00001", "LiuFeifan", "18812345678");
            Goods pc = new Goods("computer", "Lenovo 16G 512G i5", 4325.99, 1000);
            OrderDetails item0 = new OrderDetails(pc, 1);
            Order order0 = new Order("00000", customer1, "Wuhan", item0);
            OrderService orderService = new OrderService();
            orderService.Add(order0);
            *//*orderService.Modify_AddItem(order0, item1);
            orderService.Modify_AddItem(order0, item2);
            List<Order> queryOrderList = orderService.QueryByCustomer(customer1);
            foreach (Order myOrder in queryOrderList)
            {
                Console.WriteLine(myOrder);
            }
            queryOrderList = orderService.QueryByName("guitar");
            foreach (Order myOrder in queryOrderList)
            {
                Console.WriteLine(myOrder);
            }*//*
            orderService.Export("orderList.xml");*/
            List<String> list = new List<string> { null, null, "1" };
            Console.WriteLine(list.Count);
            list.RemoveAll(item => item == null);
            Console.WriteLine(list.Count);
        }
    }
}
