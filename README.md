## FoodShop_Management

# FoodShop Project
Online e-commerce website for food ordering with role-based access control and separate layouts. Built with C# .NET, Blazor, and ORM.

# Features
- Client Side
- Browse food menu
- Add to cart
- Place orders
- Order history
- Authentication & authorization
- Responsive UI
- Role-Based System

Different users have different layouts and permissions:
Customer:
    View foods
    Place orders
    Track orders
    Manage profile

Admin:
    Dashboard layout
    Manage foods
    Manage users
    Manage orders

Delivery Staff:
    View assigned deliveries
    Update delivery status

# Role-Based Layout
The application uses protected routes and dynamic layouts based on user roles.

# Tech Stack
_Frontend
    .NET
    Bootstrap (CSS)

_Backend
    Blazor
    ORM
    MYSQL (Database)

_Authentication
    Login/Register
    Role-based authorization


## FoodShop.Web
- Blazor frontend application
- Contains UI pages and components
- Handles user interactions (HTML, UI logic)

## FoodShop.Data
- Data access layer
- Contains ORM models and database context
- Handles communication with the database

## FoodShop.Models
- Helper logic layer
- Handles operations between Web and Data layers

## How It Works
1\. The user interacts with the \*\*FoodShop.Web\*\* (Blazor UI)
2\. The web layer calls services in the backend
3\. Services process logic and interact with \*\*FoodShop.Data\*\*
4\. Data layer communicates with the database using ORM 
5\. Results are returned back to the UI

## How To Run It
- # If you do not have migration file in Foodshop.Data then
- # When Inside file go to tool -> nu-package cmd
=======
# How To Run It
- If you do not have (Migration file) inside Foodshop.data
- go to tool -> nu-package cmd -> change directory to (Foodshop.data) instead of (Foodshop.web)
- Run:  Add-Migration InitialCreate
        Update-Database
