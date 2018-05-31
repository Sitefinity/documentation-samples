// Documentation srticles: https://docs.sitefinity.com/for-developers-add-custom-fields-to-the-checkout-widget

using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Ecommerce.Catalog.Model;
using Telerik.Sitefinity.Ecommerce.Orders.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.Ecommerce.Catalog;
using Telerik.Sitefinity.Modules.Ecommerce.Configuration;
using Telerik.Sitefinity.Modules.Ecommerce.Orders;
using Telerik.Sitefinity.Modules.Ecommerce.Orders.Business;
using Telerik.Sitefinity.Modules.Ecommerce.Orders.Web.UI.CheckoutViews;
using Telerik.Sitefinity.Modules.Ecommerce.Shipping;

namespace SitefinityWebApp.WebFormWidgetsSamples.Checkout
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string resultMessage = string.Empty;

            try
            {
                ProcessOrder();
                resultMessage = "Order created successfully.";
            }

            catch (Exception ex)
            {
                resultMessage = Server.HtmlDecode(string.Format("{0}{1}{2}{1}{3}",
                    ex.Message, "<br/><br/>", ex.StackTrace, ex.InnerException));
            }

            this.resultTextBox.Text = resultMessage;
        }

        public static void ProcessOrder()
        {
            CatalogManager catalogManager = CatalogManager.GetManager();
            OrdersManager ordersManager = OrdersManager.GetManager();

            Product product = catalogManager.GetProducts().Where(p => p.Title == ExistingProductTitle &&

                p.Status == ContentLifecycleStatus.Live).FirstOrDefault();


            CartOrder cartOrder = ordersManager.CreateCartOrder();
            cartOrder.OrderDate = DateTime.Now;
            cartOrder.OrderStatus = OrderStatus.Pending;

            int orderNumber = ordersManager.GetOrders().LastOrDefault().OrderNumber + 1;

            cartOrder.OrderNumber = orderNumber;
            cartOrder.OrderDate = DateTime.Now;
            cartOrder.LastModified = DateTime.Now;
            cartOrder.OrderAttempts = 0;

            var currency = Config.Get<EcommerceConfig>().DefaultCurrency;

            cartOrder.Currency = currency;

            Customer customer = ordersManager.GetCustomers().Where(c => c.CustomerFirstName == ExistingCustomerFirstName).FirstOrDefault();

            cartOrder.UserId = customer.Id;

            CartDetail orderDetail = new CartDetail();

            orderDetail.Id = Guid.NewGuid();
            orderDetail.ProductId = product.Id;
            orderDetail.Quantity = 1;
            orderDetail.ProductAvailable = true;
            orderDetail.Price = product.Price;
            orderDetail.IsShippable = true;
            cartOrder.Details.Add(orderDetail);

            CheckoutState state = UpdateCheckoutState(customer, ordersManager, cartOrder);

            ordersManager.SaveChanges();

            EcommerceOrderCalculator calculator = new EcommerceOrderCalculator();

            calculator.CalculateAndSaveChanges(cartOrder);

            ordersManager.Checkout(cartOrder.Id, state, customer);
            ordersManager.SaveChanges();
            catalogManager.SaveChanges();
        }

        public static CheckoutState UpdateCheckoutState(Customer customer, OrdersManager ordersManager, CartOrder cartOrder)
        {
            CheckoutState state = new CheckoutState();
            ShippingManager shippingManager = ShippingManager.GetManager();

            var shippingMethod = shippingManager.GetShippingMethods().FirstOrDefault();

            state.ShippingMethodId = shippingMethod.Id;
            state.ShippingServiceName = shippingMethod.Name;
            cartOrder.ShippingMethodId = state.ShippingMethodId;

            state.ShippingFirstName = customer.CustomerFirstName;
            state.ShippingLastName = customer.CustomerLastName;
            state.ShippingCompany = MockCompany;
            state.ShippingEmail = customer.CustomerEmail;
            state.ShippingAddress1 = MockAdressOne;
            state.ShippingAddress2 = MockAdressTwo;
            state.ShippingCity = MockCity;
            state.ShippingCountry = MockCountry;
            state.ShippingCountryName = MockCountry;
            state.ShippingZip = MockZip;
            state.ShippingPhoneNumber = MockPhone;
            state.BillingFirstName = customer.CustomerFirstName;
            state.BillingLastName = customer.CustomerLastName;
            state.BillingCompany = MockCompany;
            state.BillingEmail = customer.CustomerEmail;
            state.BillingAddress1 = MockAdressOne;
            state.BillingAddress2 = MockAdressTwo;
            state.BillingCity = MockCity;
            state.BillingCountry = MockCountry;
            state.BillingCountryName = MockCountry;
            state.BillingZip = MockZip;
            state.BillingPhoneNumber = MockPhone;

            state.OrderRequiresShipping = true;

            UpdateCartDetails(state, ordersManager, customer, cartOrder);

            return state;
        }

        private static void UpdateCartDetails(CheckoutState checkoutState, OrdersManager ordersManager, Customer customer, CartOrder cartOrder)
        {
            CartAddress shippingAddress = null;

            if (checkoutState.OrderRequiresShipping)
            {
                shippingAddress = ordersManager.CreateCartAddress();
                shippingAddress.FirstName = checkoutState.ShippingFirstName;
                shippingAddress.LastName = checkoutState.ShippingLastName;
                shippingAddress.Address = checkoutState.ShippingAddress1;
                shippingAddress.Address2 = checkoutState.ShippingAddress2;
                shippingAddress.AddressType = AddressType.Shipping;
                shippingAddress.City = checkoutState.ShippingCity;
                shippingAddress.PostalCode = checkoutState.ShippingZip;
                shippingAddress.StateRegion = checkoutState.ShippingState;
                shippingAddress.Country = checkoutState.ShippingCountry;
                shippingAddress.Phone = checkoutState.ShippingPhoneNumber;
                shippingAddress.Email = checkoutState.ShippingEmail;
                shippingAddress.Company = checkoutState.ShippingCompany;
                shippingAddress.County = checkoutState.ShippingCounty;
                cartOrder.Addresses.Add(shippingAddress);
            }

            var billingAddress = ordersManager.CreateCartAddress();

            billingAddress.FirstName = checkoutState.BillingFirstName;
            billingAddress.LastName = checkoutState.BillingLastName;
            billingAddress.Address = checkoutState.BillingAddress1;
            billingAddress.Address2 = checkoutState.BillingAddress2;
            billingAddress.AddressType = AddressType.Billing;
            billingAddress.City = checkoutState.BillingCity;
            billingAddress.PostalCode = checkoutState.BillingZip;
            billingAddress.StateRegion = checkoutState.BillingState;
            billingAddress.Country = checkoutState.BillingCountry;
            billingAddress.Phone = checkoutState.BillingPhoneNumber;
            billingAddress.Email = checkoutState.BillingEmail;
            billingAddress.Company = checkoutState.BillingCompany;
            billingAddress.County = checkoutState.BillingCounty;

            cartOrder.Addresses.Add(billingAddress);

            decimal vatTaxAmount = cartOrder.VatTaxAmount.HasValue ? cartOrder.VatTaxAmount.Value : 0;

            checkoutState.SubTotal = cartOrder.SubTotalDisplay + vatTaxAmount;
            checkoutState.TotalWeight = cartOrder.Weight;
            checkoutState.Tax = cartOrder.Tax;
            checkoutState.ShippingAmount = cartOrder.ShippingTotal;
            checkoutState.ShippingTax = cartOrder.ShippingTax;
            checkoutState.ShippingTaxRate = cartOrder.ShippingTaxRate;
            checkoutState.DiscountAmount = cartOrder.DiscountTotal;
            checkoutState.Total = cartOrder.Total;

            var paymentmethod = ordersManager.GetPaymentMethods().FirstOrDefault();

            checkoutState.PaymentMethodId = paymentmethod.Id;
            checkoutState.PaymentMethodType = paymentmethod.PaymentMethodType;

            CartPayment cartPayment = ordersManager.CreateCartPayment();

            cartPayment.PaymentMethodId = paymentmethod.Id;
            cartPayment.PaymentMethodType = paymentmethod.PaymentMethodType;
            cartPayment.CreditCardCustomerName = customer.CustomerFirstName;
            cartPayment.CreditCardNumber = MockCreditCardNumber;

            cartOrder.Payments.Add(cartPayment);
        }

        #region Mock Information

        private const string ExistingProductTitle = "MyTestProduct";
        private const string ExistingCustomerFirstName = "Ivaylo";
        private const string MockCountry = "Test Country";
        private const string MockCity = "Test city";
        private const string MockZip = "6000";
        private const string MockAdressOne = "Adresss line 1";
        private const string MockAdressTwo = "Address line 2";
        private const string MockCompany = "Test company";
        private const string MockPhone = "359123456";
        private const string MockCreditCardNumber = "123456789";

        #endregion

    }
}