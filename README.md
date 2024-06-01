# Agricultural Management System

## Overview

This is an ASP.NET MVC web application designed for a simple agricultural management system with two user roles: **Farmer** and **Employee**. The application includes functionalities for managing products and farmers, with role-based access controls.

### Features

- **Navigation Bar**:
  - Home
  - Products
    - Add Product
    - List Products
  - Farmers (Employee only)
    - Add Farmer
    - List Farmers
  - Login
  - Logout

- **Product Management** (Farmer):
  - Add new products.
  - View and search through all products in the database.
  - Search by Farmer Name, Category, or Date Range.

- **Farmer Management** (Employee):
  - Create new farmer accounts.
  - View and manage a list of all farmers.
  - Delete farmer accounts.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- Identity for authentication and authorization
- SQL Server for database

## Getting Started

### Prerequisites

- .NET Core SDK
- SQL Server
- Visual Studio or any preferred IDE

## Usage

### Logging In

- Navigate to the **Login** page using the navbar.
- Log in using one of the default users or create a new farmer account.

### Product Management (Farmer)

- **Add Product**:
  - Click on **Products** > **Add Product**.
  - Fill in the product details and submit.
- **List Products**:
  - Click on **Products** > **List Products**.
  - Use the search fields at the top to filter products by Farmer Name, Category, or Date Range.

### Farmer Management (Employee)

- **Add Farmer**:
  - Click on **Farmers** > **Add Farmer**.
  - Fill in the farmer details and submit.
- **List Farmers**:
  - Click on **Farmers** > **List Farmers**.
  - View all farmers and delete any farmer using the delete option next to each farmer.

## Role-Based Access Control

- **Farmer**:
  - Can add and list products.
- **Employee**:
  - Can add and list farmers.
  - Can delete farmer accounts.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
