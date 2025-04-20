Objective:
Create a system that stores users and transaction data in a database. Implement efficient algorithms for processing and summarizing transaction data.

Scenario:
1.	Database Storage: Store all users and transaction data in an SQL database. Each transaction should have only a unique ID, user ID, amount, creation date and transaction type.
2.	Complex Logic: Implement efficient in-memory processing for summarizing transaction data, such as calculating the total amount per user and per transaction type.

Evaluation Criteria:
•	Code Efficiency
•	Correctness
•	Best Practices

Requirements:
•	Database Operations:
o	Add Transaction: Insert a new transaction into the database.
o	Fetch Transactions: Retrieve transaction data from the database.
o	CRUD Users: All users Crud operations
•	Complex Logic Operations:
o	Total Amount Per User: Calculate the total transaction amount for each user.
o	Total Amount Per Transaction Type: Calculate the total transaction amount for each transaction type.
o	High-Volume Transactions: Identify transactions above a certain threshold amount.
•	Create a simple API without authentication: API clients should be able to call all Database and Complex Logic Operations through the API
•	Use Swagger
•	Use Automapper
•	Use DTOs and Entities: even if the model is duplicated is just to show if you know how to work with Automapper
•	Use EFCore
•	Have a sample of unit tests and integration tests: no need to cover all code
•	Follow Solid principles
•	Use Polymorphism: if applicable
•	Use a Generic approach: When possible
•	Transaction Entity Model to be used (This is pseudo code):

public class Transaction 
{ 
  public int Id { get; set; } 
  public string UserId { get; set; } 
  public decimal Amount { get; set; } 
  public TransactionTypeEnum TransactionType { get; set; }
  public Datetime CreatedAt { get; set; }
}

Public enum TransactionTypeEnum
{
	Debit,
	Credit
}

