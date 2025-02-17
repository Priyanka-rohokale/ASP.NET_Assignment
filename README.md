This is a simple ASP.NET MVC application for processing customer orders. It calculates a discount based on customer type:
Loyal Customers get a 10% discount if their order is $100 or more.
New Customers get no discount.
The application includes a user-friendly UI, business logic for discount calculation, and unit tests for validation.
Project Structure

ASP.NET-OrderProcessing/
│── ASP.NET Assignment/               # Main ASP.NET MVC Application
│   ├── Controllers/
│   │   ├── OrderController.cs        # Handles order processing logic
│   ├── Models/
│   │   ├── Order.cs                  # Defines Order model with properties
│   ├── Views/
│   │   ├── Order/
│   │   │   ├── Create.cshtml         # Order entry form
│   │   │   ├── Results.cshtml        # Displays order summary with discount
│   ├── webconfig.cs/                      # Add conncection string
│  
│── OrderProcessing.Tests/             # Unit test project
│   ├── OrderTests.cs                  # MSTest test cases
│── .github/                            # GitHub Actions CI/CD pipeline
│   ├── workflows/
│   │   ├── dotnet.yml                 # CI/CD pipeline for test automation

***Business Logic
If Customer Type = "Loyal" and Order Amount >= 100, apply a 10% discount.
Otherwise, no discount.
Implementation in OrderController.cs:
public IActionResult CalculateDiscount(Order order)
{
    decimal discount = (order.OrderAmount >= 100 && order.CustomerType == "Loyal") 
                        ? 0.10m * order.OrderAmount 
                        : 0;

    order.Discount = discount;
    order.FinalAmount = order.OrderAmount - discount;

    return View("Results", order);
}
---
Unit Testing
The test project OrderProcessing.Tests contains MSTest-based unit tests for discount calculation.
Example test in OrderTests.cs:
[TestMethod]
public void CalculateDiscount_LoyalCustomer_Above100()
{
    var order = new Order { OrderAmount = 150, CustomerType = "Loyal" };
    var discount = order.OrderAmount >= 100 && order.CustomerType == "Loyal" ? 0.10m * order.OrderAmount : 0;
    Assert.AreEqual(15, discount);
}
