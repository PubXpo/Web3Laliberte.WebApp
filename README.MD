# Project Name

## Description
Welcome to **Web3 Laliberté**! This is a donation and gift fulfilment web application built with a modern tech stack, featuring a React frontend and a C# backend. The application provides robust API endpoints to manage contact logs, orders, and FAQs efficiently.

## Technologies Used
The following technologies are leveraged to build and maintain the application:
- **JavaScript**
- **React**
- **npm**
- **SQL**
- **C#**

## Prerequisites
Before beginning, ensure the following are installed:
- **Docker**
- **Docker Compose**
- **.NET SDK**

## Getting Started

### Installation

1. **Start the application using Docker Compose:**
    ```sh
    docker-compose -f docker-compose.dev.yml up --build
    ```

2. **Set up the database and run migrations:**
    Ensure the database container is running. Then, apply the migrations:
    ```sh
    cd Server/Services/Web3Laliberte.OperationsAPI
    dotnet ef database update
    ```
    Alternatively, manually create the users, database, and tables using the `init.sql` script.

### Usage

**Localhost Application URLs:**
Access the applications via the following URLs. Both applications include footer links to each other.
- **Donation Flagship:** `http://localhost:4010/`
- **Admin Portal:** `http://localhost:4020/`

Log in to the Admin Portal using "admin" as both the username and password.

**Swagger API URL:**
Explore the API documentation at [Swagger Documentation](http://localhost:4000/swagger/index.html).

## API Endpoints

### Contact Logs
- **GET** `/api/contactlogs` - Retrieve all contact logs
- **GET** `/api/contactlogs/{id}` - Retrieve a contact log by ID
- **POST** `/api/contactlogs` - Create a new contact log
- **PUT** `/api/contactlogs/{id}` - Update a contact log by ID
- **DELETE** `/api/contactlogs/{id}` - Delete a contact log by ID

### Orders
- **GET** `/api/orders` - Retrieve all orders
- **GET** `/api/orders/{id}` - Retrieve an order by ID
- **POST** `/api/orders` - Create a new order
- **PUT** `/api/orders/{id}` - Update an order by ID
- **DELETE** `/api/orders/{id}` - Delete an order by ID

### FAQs
- **GET** `/api/faqs` - Retrieve all FAQs
- **GET** `/api/faqs/{id}` - Retrieve an FAQ by ID
- **POST** `/api/faqs` - Create a new FAQ
- **PUT** `/api/faqs/{id}` - Update an FAQ by ID
- **DELETE** `/api/faqs/{id}` - Delete an FAQ by ID

## License
This project is licensed under the MIT License.