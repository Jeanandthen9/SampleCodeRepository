using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Data.OrdersRepo;
using FlooringProgram.Data.ProductsRepo;
using FlooringProgram.Data.TaxesRepo;
using FlooringProgram.UI.Workflows;
using FlooringProgram.Models;
using NUnit.Framework;

namespace FlooringProgram.Tests
{
    [TestFixture]
    class RepositoryTests : CreateOrderWorkflow
    {
        #region ORDERS REPO TESTS

        [Test]
        public void GetNextAccountNum()
        {
            OrderRepository repo = new OrdersMockRepo();

            int nextOrderNum1 = repo.GetNextOrderNumber();
            Assert.AreEqual(20, nextOrderNum1);
        }

        [Test]
        public void ValidAddOrderToRepo()
        {
            // Gotta make sure stateName and productType are CAPITALIZED
            // since they have to be in the same format as their Dictionary key

            string name = "Jeannine";
            string stateName = "michigan".ToUpper();
            string productType = "tile".ToUpper();
            decimal area = 50.55m;

            var repo = OrderRepositoryFactory.CreateOrderRepo();
            int orderNumber = repo.GetNextOrderNumber();

            ProductRepository repo1 = ProductRepositoryFactory.CreateProdRepo();
            Product product = repo1.GetProductByName(productType);
            Assert.IsNotNull(product);

            TaxesRepository repo2 = TaxesRepositoryFactory.CreateTaxRepo();
            State state = repo2.GetStateByFullName(stateName);
            Assert.IsNotNull(state);

            Order newOrder = new Order()
            {
                CustomerName = name,
                State = state,
                ProductType = product,
                Area = area,
                PriceTotal = (product.LaborCost * area) + (product.MaterialCost * area) * state.TaxRate,
                OrderDate = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                OrderNumber = orderNumber
            };

            newOrder = repo.CreateNewOrder(newOrder);
            Assert.IsNotNull(newOrder);
        }

       [Test]
        public void CannotAddOrderToRepoDueToInvalidProduct()
        {
            string name = "Jeannine";
            string stateName = "michigan".ToUpper();
            string productType = "manga".ToUpper();
            decimal area = 50.55m;

            var repo = OrderRepositoryFactory.CreateOrderRepo();
            int orderNumber = repo.GetNextOrderNumber();

            TaxesRepository repo2 = TaxesRepositoryFactory.CreateTaxRepo();
            State state = repo2.GetStateByFullName(stateName);
            Assert.IsNotNull(state);

            ProductRepository repo1 = ProductRepositoryFactory.CreateProdRepo();
            Product product = repo1.GetProductByName(productType);
            Assert.IsNull(product);

            Order newOrder = new Order()
            {
                CustomerName = name,
                State = state,
                //ProductType = product,
               // ProductName = product.Type,
                Area = area,
                //PriceTotal = (product.LaborCost * area) + (product.MaterialCost * area) * state.TaxRate,
                OrderDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                OrderNumber = orderNumber
            };
            Assert.IsNotNull(newOrder.State);
            Assert.IsNull(newOrder.ProductType);
           // because a single property is null within the newOrder object, a newOrder cannot be created!!
            

        }

        [Test]
        public void CannotAddOrderToRepoDueToInvalidState()
        {
            string name = "Jeannine";
            string stateName = "new york".ToUpper();
            string productType = "tile".ToUpper();
            decimal area = 50.55m;

            var repo = OrderRepositoryFactory.CreateOrderRepo();
            int orderNumber = repo.GetNextOrderNumber();

            TaxesRepository repo2 = TaxesRepositoryFactory.CreateTaxRepo();
            State state = repo2.GetStateByFullName(stateName);
            Assert.IsNull(state);

            ProductRepository repo1 = ProductRepositoryFactory.CreateProdRepo();
            Product product = repo1.GetProductByName(productType);
            Assert.IsNotNull(product);

            Order newOrder = new Order()
            {
                CustomerName = name,
                //State = state,
                //StateAbbreviation = state.StateAbbreviation,
                //FullStateName = state.StateName,
                ProductType = product,
                Area = area,
               // PriceTotal = (product.LaborCost * area) + (product.MaterialCost * area) * state.TaxRate,
                OrderDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                OrderNumber = orderNumber
            };
            Assert.IsNotNull(newOrder.ProductType);
            Assert.IsNull(newOrder.State);

            // SAME AS ABOVE TEST!!
            // because a single property is null within the newOrder object, a newOrder cannot be created!!
        }

        [Test]
        public void CannotAddInvalidStateAndProduct()
        {
            string name = "Jeannine";
            string stateName = "new york".ToUpper();
            string productType = "manga".ToUpper();
            decimal area = 50.55m;

            var repo = OrderRepositoryFactory.CreateOrderRepo();
            int orderNumber = repo.GetNextOrderNumber();

            TaxesRepository repo2 = TaxesRepositoryFactory.CreateTaxRepo();
            State state = repo2.GetStateByFullName(stateName);
            Assert.IsNull(state);

            ProductRepository repo1 = ProductRepositoryFactory.CreateProdRepo();
            Product product = repo1.GetProductByName(productType);
            Assert.IsNull(product);

            Order newOrder = new Order()
            {
                CustomerName = name,
               // State = state,
               // StateAbbreviation = state.StateAbbreviation,
                //FullStateName = state.StateName,
                //ProductType = product,
                // ProductName = product.Type,
                Area = area,
                //PriceTotal = (product.LaborCost * area) + (product.MaterialCost * area) * state.TaxRate,
                OrderDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                OrderNumber = orderNumber
            };
            Assert.IsNotNull(newOrder.CustomerName);
            Assert.IsNotNull(newOrder.Area);
            Assert.IsNotNull(newOrder.OrderDate);
            Assert.AreEqual(20, newOrder.OrderNumber);

            Assert.IsNull(newOrder.State);
            Assert.IsNull(newOrder.ProductType);

            // because MULTIPLE properties are null within the newOrder object, a newOrder cannot be created!!
        }

        [Test]
        public void ListAllOrdersInRepo()
        {
            var repo = OrderRepositoryFactory.CreateOrderRepo();

            repo.ListAllOrdersInRepo();


        }

        // giorno becomes 16, Josuke 17, Jolyne 18, and Johnny 19
        // mettaton, alphys, and undyne can't be added, so they're skipped
        [TestCase("laminate", "michigan", "Giorno Brando", 80.55)]
        //[TestCase("wood", "new york", "Alphys", 72)]
        [TestCase("tile", "indiana", "Jouske Higashikata", 35.9)]
       // [TestCase("foam", "ohio", "Mettaton", 15.5)]
        [TestCase("carpet", "ohio", "Jolyne Kujo", 38.2)]
       // [TestCase("foam", "new york", "Undyne", 33.3)]
        [TestCase("wood", "pennsylvania", "Johnny Joestar", 8)]

        // These can't be added because the product and/or state is not in the repo!
        //[TestCase("foam", "ohio", "Mettaton", 15.5)]
        //[TestCase("wood", "new york", "Alphys", 72)]
        //[TestCase("foam", "new york", "Undyne", 33.3)]
        public void AddNewOrderThenListAllOrders(string productName, string stateName, string custName, decimal area)
        {
            var repo = OrderRepositoryFactory.CreateOrderRepo();

            int orderNum = repo.GetNextOrderNumber();

            ProductRepository pRepo = ProductRepositoryFactory.CreateProdRepo();
            Product p = pRepo.GetProductByName(productName.ToUpper());

            TaxesRepository sRepo = TaxesRepositoryFactory.CreateTaxRepo();
            State s = sRepo.GetStateByFullName(stateName.ToUpper());

            Order newOrder1 = new Order()
            {
                CustomerName = custName,
                Area = area,
                State = s,
                ProductType = p,
                OrderDate = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                OrderNumber = orderNum,
                PriceTotal = ((p.LaborCost*area) + (p.MaterialCost*area)) / s.TaxRate
            };

            newOrder1 = repo.CreateNewOrder(newOrder1);

            repo.ListAllOrdersInRepo();
        }
        #endregion
    }

    [TestFixture]
    class RepositoryTests2 : OrderSearchWorkflow
    {
        [Test]
        public void SearchForExistingOrder()
        {
            string date = "07/05/2016";
            int orderNum = 4;

            var repo = OrderRepositoryFactory.CreateOrderRepo();

            OrderProcessing request = new OrderProcessing();
            Response response = request.SearchForOrder(date, orderNum);

            Assert.IsTrue(response.Success == true);

            Console.WriteLine($"NAME EXPECTED: Dio Brando\nNAME RECEIVED: {response.OrderInfo.CustomerName}");
        }
    }
}
