# Fullstack Project

![TypeScript](https://img.shields.io/badge/TypeScript-v.4-green)
![SASS](https://img.shields.io/badge/SASS-v.4-hotpink)
![React](https://img.shields.io/badge/React-v.18-blue)
![Redux toolkit](https://img.shields.io/badge/Redux-v.1.9-brown)
![.NET Core](https://img.shields.io/badge/.NET%20Core-v.7-purple)
![EF Core](https://img.shields.io/badge/EF%20Core-v.7-cyan)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-v.14-drakblue)

This project involves creating a Fullstack project with React and Redux on the frontend and ASP.NET Core 7 on the backend. The goal is to provide a seamless experience for users, along with robust management system for administrators.

- Frontend: SASS, TypeScript, React, Redux Toolkit
- Backend: ASP .NET Core, Entity Framework Core, PostgreSQL

You can follow the same topics as your backend project or choose the alternative one, between E-commerce and Library. You can reuse the previous frontend project, with necessary modification, or make a new layout to fit your backend server.

## Table of Contents

1. [Features](#features)
   - [Mandatory features](#mandatory-features)
   - [Extra features](#extra-features)
2. [Requirements](#requirements)
3. [Getting Started](#getting-started)
4. [Testing](#testing)

## Features

### Mandatory features

#### User Functionalities

1. User Management: Users should be able to register for an account and log in. Users cannot register themselves as admin.
2. Browse Products: Users should be able to view all available products and single product, search and sort products.
3. Add to Cart: Users should be able to add products to a shopping cart, and manage cart.
4. Checkout: Users should be able to place order.

#### Admin Functionalities

1. User Management: Admins should be able to view and delete users.
2. Product Management: Admins should be able to view, edit, delete and add new products.
3. Order Management: Admins should be able to view all orders

### Extra features

#### User Functionalities

1. User Management: Users should be able to view and edit only certain properties in their accounts. They also can unregister their own accounts.
2. Authentication and account registration with Google Oauth.
3. Order Management: Users should be able to view their order history, track the status of their orders, and potentially cancel orders within a certain timeframe.

#### Admin Functionalities

1. User Management: Admins should be able to edit users' role and create new users.
2. Order Management: Admins should be able to update order status, view order details, handle returns/refunds, and cancel orders.

And any other extra features that you want to implement ...

## Requirements

1. Apply CLEAN architecture in your backend. In README file, explain the architecture of your project as well.
2. Implement Error Handling Middleware: This will ensure any exceptions thrown in your application are handled appropriately and helpful error messages are returned.
3. Document with Swagger: Make sure to annotate your API endpoints and generate a Swagger UI for easier testing and documentation.
4. Project should have proper file structure, naming convention, and comply with Rest API.
5. `README` file should sufficiently describe the project, as well as the deployment.

## Getting Started

1. Your full stack project should have one git repo to manage both frontend and backend. The shared .git in the root directory is used to push commits to the remote repo. In case you need to deploy frontend and backend to different server, you can inittiate another `.git` folder in each repository. Syntax: `cd frontend` -> `git init` (similar to backend folder). Remember to add `.gitignore` for each folder when you intiate `git` repo.
2. `frontend` folder is for the react frontend. Start with `backend` first before moving to `frontend`.
3. In the `backend`, here is the recommended order:

   - Plan Your Database Schema before start coding

   - Set Up the Project Structure

   - Build the models

   - Create the Repositories

   - Build the Services

   - Set Up Authentication & Authorization

   - Build the Controllers

   - Implement Error Handling Middleware

4. You should focus on the mandatory features first. Make sure you have minimal working project before opting for advanced functionalities.

Testing should be done along the development circle, early and regularly.

## Testing

Unit testing, and optionally integration testing, must be included for both frontend and backend code. Aim for high test coverage and ensure all major functionalities are covered.

# Introduction

This repository contains the code for Sailesh Karki, Fullstack Project.
- Link to Web Api page. [Api Webpage] (https://saileshecom-app.azurewebsites.net/swagger/index.html)
- Link to frontend page. [UI page] (https://saileshe-ecom-webshop.netlify.app)

Endpoints: 

- /api/v1/auth

- /api/v1/carts

- /api/v1/cartitems

- /api/v1/categorys

- /api/v1/orders

- /api/v1/orderproducts

- /api/v1/products

- /api/v1/users


## Technologies

- TypeScript
- C#
-.Net Core
- EF Core
- PostgreSql

## Entity Relationship Diagram
The is the database schema designed in Lucid app showing 7 tables and their relationship.

[ERD] (https://lucid.app/lucidchart/a11bb4a1-bb02-4def-ac60-6d8369d6f073/edit?page=0_0&invitationId=inv_f63e8a90-761c-49ac-a934-0883cc121c72#)

[App-Design] (https://lucid.app/lucidspark/5de551fb-af72-4962-8385-00955c1fb85a/edit?invitationId=inv_4c26e2c2-99b2-40a3-83f7-d559aa0b590c&page=0_0#)

## Project Structure

````

│   .gitignore
│   README.md
├───Planning
│       ├───ERD.jpeg
│       ├───Architecture.jpeg
├───backend
│   ├───WebApi.Business
│   │   │   WebApi.Business.csproj
│   │   │   WebApi.Business.sln
│   │   │
│   │   └───src
│   │       ├───Abstractions
│   │       │       IAuthService.cs
│   │       │       IBaseService.cs
│   │       │       ICartService.cs
│   │       │       ICartItemService.cs
│   │       │       ICategoryService.cs
│   │       │       IOrderProductService.cs
│   │       │       IOrderService.cs
│   │       │       IProductService.cs
│   │       │       IUserService.cs
│   │       │
│   │       ├───Common
│   │       │       CustomErrorHandler.cs
│   │       │
│   │       ├───Dtos
│   │       │       CartDto.cs
│   │       │       CartItemDto.cs
│   │       │       CategoryDto.cs
│   │       │       OrderDto.cs
│   │       │       OrderProductDto.cs
│   │       │       PasswordUpdateDto.cs
│   │       │       ProductDto.cs
│   │       │       UserDto.cs
│   │       │
│   │       ├───Implementation
│   │       │       BaseService.cs
│   │       │       CartItemService.cs
│   │       │       CartService.cs
│   │       │       OrderProductService.cs
│   │       │       OrderService.cs
│   │       │       ProductService.cs
│   │       │       UserService.cs
│   │       │
│   │       └───Shared
│   │               AuthService.cs
│   │               PasswordService.cs
│   │
│   ├───WebApi.Controller
│   │   │   WebApi.Controller.csproj
│   │   │
│   │   └───src
│   │       └───Controllers
│   │               AuthController.cs
│   │               BaseController.cs
│   │               CartController.cs
│   │               CartItemController.cs
│   │               CategoryController.cs
│   │               OrderController.cs
│   │               OrderProductController.cs
│   │               ProductController.cs
│   │               UserController.cs
│   │
│   ├───WebApi.Core
│   │   │   WebApi.Core.csproj
│   │   │   WebApi.Core.sln
│   │   │
│   │   └───src
│   │       ├───Abstractions
│   │       │       IBaseRepo.cs
│   │       │       ICartItemRepo.cs
│   │       │       ICartRepo.cs
│   │       │       ICategoryRepo.cs
│   │       │       IOrderProductRepo.cs
│   │       │       IOrderRepo.cs
│   │       │       IProductRepo.cs
│   │       │       IUserRepo.cs
│   │       │
│   │       ├───Entities
│   │       │       BaseEntity.cs
│   │       │       Cart.cs
│   │       │       CartItem.cs
│   │       │       Order.cs
│   │       │       OrderProduct.cs
│   │       │       Product.cs
│   │       │       TimeStamp.cs
│   │       │       User.cs
│   │       │
│   │       └───Shared
│   │               QueryOptions.cs
│   │
│   ├───WebApi.Testing
│   │   │   Usings.cs
│   │   │   WebApi.Test.csproj
│   │   │   WebApi.Test.sln
│   │   └───src
│   │       └───Business.Test
│   │           ├───ProductServiceTest.cs
│   │           └───UserServiceTest.cs
│   │
│   └───WebApi.WebApi
│       │   appsettings.Development.json
│       │   appsettings.json
│       │   appsettings.example.json
│       │   WebApi.WebApi.csproj
│       │
│       ├───Migrations
│       │       20230816142450_DatabaseCreate.cs
│       │       20230816142450_DatabaseCreate.Designer.cs
│       │       DatabaseContextModelSnapshot.cs
│       │
│       ├───Properties
│       │       launchSettings.json
│       ├───Middleware
│       │       ErrorHandlerMiddleware.cs
│       └───src
│           │   Program.cs
│           │
│           ├───Configuration
│           │       MapperProfile.cs
│           │
│           ├───Database
│           │       DatabaseContext.cs
│           │       TimeStampInterceptor.cs
│           │
│           │
│           └───RepoImpementations
│                   BaseRepo.cs
│                   CartRepo.cs
│                   CartItemRepo.cs
│                   CategoryRepo.cs
│                   OrderProductRepo.cs
│                   OrderRepo.cs
│                   ProductRepo.cs
│                   UserRepo.cs
└───frontend
````