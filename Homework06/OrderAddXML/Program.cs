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
    public class Customer
    {
        private string id;
        private string name;
        private string phone;
        private string address;

        public Customer() { }
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
    public class OrderDetails
    {
        private string id;
        private Goods goods;
        private int count;

        public OrderDetails() { }
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
    public class Order : IComparable
    {
        private string id;
        private Customer customer;
        private List<OrderDetails> itemList = new List<OrderDetails>();

        public Order() { }
        public Order(string id, Customer customer, OrderDetails item)
        {
            this.id = id;
            this.customer = customer;
            itemList.Add(item);
        }
        public string Id { get => id; set => id = value; }
        public Customer Customer { get => customer; set => customer = value; }
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

        public bool ItemsEquals(List<OrderDetails> items)
        {
            if(itemList.Count != items.Count)
            {
                return false;
            }
            for(int index = 0; index < items.Count; index++)
            {
                if (! itemList[index].Equals(items[index]))
                {
                    return false;
                }
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   id == order.id &&
                   EqualityComparer<Customer>.Default.Equals(customer, order.customer) &&
                   ItemsEquals(order.ItemList);
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
            if(order == null)
            {
                throw new ArgumentException("添加失败：订单为空");
            }
            orderList.Add(order);
        }

        public void Delete(Order order)
        {
            if(!orderList.Remove(order))
            {
                throw new ArgumentException("删除失败：订单不存在");
            }
        }

        public void Modify_AddItem(Order order, OrderDetails item)
        {
            int orderIndex = orderList.IndexOf(order);
            if(orderIndex == -1)
            {
                throw new ArgumentException("修改失败：订单不存在");
            }
            if(item == null)
            {
                throw new ArgumentException("修改失败：订单明细为空");
            }
            orderList[orderIndex].ItemList.Add(item);
        }

        public void Modify_DeleteItem(Order order, OrderDetails item)
        {
            int orderIndex = orderList.IndexOf(order);
            if (orderIndex == -1)
            {
                throw new ArgumentException("修改失败：订单不存在");
            }
            if(item == null)
            {
                throw new ArgumentException("修改失败：订单明细为空");
            }
            if (!orderList[orderIndex].ItemList.Remove(item))
            {
                throw new ArgumentException("修改失败：订单明细不存在");
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
            foreach (Order order in orderList)
            {
                var query = order.ItemList.Where(item => item.Goods.Name == name);
                if (query.Count() != 0)
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
            orderList.Sort((Order p1, Order p2) => p1.CompareTo(p2));
        }

        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }

        public void Export()
        {
            XmlSerializer xmlSerializier = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("orderList.xml", FileMode.Create))
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
                orderList = orderList.Concat(orders).ToList();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("00001", "LiuFeifan", "18812345678", "WuHan");
            Customer customer2 = new Customer("00002", "Liuxia", "18202939333", "Nanchang");
            Goods pc = new Goods("computer", "Lenovo 16G 512G i5", 4325.99, 1000);
            Goods guitar = new Goods("guitar", "Mesopotamia S200 41", 2680, 2000);
            Goods shirt = new Goods("T-Shirt", "Li-Ning 2021", 129.98, 50);
            Goods bag = new Goods("handbag", "Dior Latest", 10000, 500);
            OrderDetails item0 = new OrderDetails("00000", pc, 1);
            OrderDetails item1 = new OrderDetails("00001", guitar, 2);
            OrderDetails item2 = new OrderDetails("00002", shirt, 3);
            Order order0 = new Order("00000", customer1, item0);
            Order order1 = new Order("00001", customer2, item2);
            OrderService orderService = new OrderService();
            orderService.Add(order0);
            /*orderService.Modify_AddItem(order0, item1);
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
            }*/
            //orderService.Export();
        }
    }
}
