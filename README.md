\### FoodShop\_Management



Online e-commerce website for food ordering built with C# .NET, Blazor, and ORM.



\# Features

\- User authentication

\- Food product listing

\- Shopping cart

\- Order management



\# Project Structure



The solution is divided into 3 layers:



\## FoodShop.Web

\- Blazor frontend application

\- Contains UI pages and components

\- Handles user interactions (HTML, UI logic)



\## FoodShop.Data

\- Data access layer

\- Contains ORM models and database context

\- Handles communication with the database



\## FoodShop.Models

\- Helper logic layer

\- Handles operations between Web and Data layers



\## ⚙️ How It Works

1\. The user interacts with the \*\*FoodShop.Web\*\* (Blazor UI)

2\. The web layer calls services in the backend

3\. Services process logic and interact with \*\*FoodShop.Data\*\*

4\. Data layer communicates with the database using ORM 

5\. Results are returned back to the UI

