# Restaurant Management System (Backend API)

A robust, API-driven backend solution engineered to optimize and streamline the order management lifecycle for restaurants. This system provides specialized workflows for Customers, Restaurant Owners, and Super Admins to handle onboarding, menu management, and live order tracking.

## Objective
To deliver a high-performance, secure, and scalable backend API that bridges the gap between hungry customers and restaurant operations, ensuring smooth order transitions, accurate reporting, and bulletproof role isolation.

---

## Tech Stack & Architecture

* **Framework:** .NET Framework 4.8 (Web API / MVC Architecture)
* **Database:** SQL Server
* **Data Access Layer:** Dual-approach utilizing **ADO.NET** (for high-performance raw SQL execution) and **Entity Framework (EF)** (for robust ORM capabilities and entity state tracking)
* **Reporting:** Telerik Reports / Crystal Reports 
* **Testing:** NUnit / MSTest
* **Hosting:** Internet Information Services (IIS) 

---

## User Roles & Core Capabilities

### 1. Super Admin
* Register and provision new restaurant entities into the ecosystem.

### 2. Restaurant Owner
* Add, update, toggle availability, or deprecate `menu_items` (dishes, pricing).
*  Live interface to **Accept** or **Reject** incoming customer orders based on kitchen capacity.

### 3. Customer
* Fetch detailed restaurant information, operating hours

---

## Getting Started & Installation

### Prerequisites
* Windows OS with **IIS** enabled
* **Visual Studio 2026** (with .NET Framework 4.8 targeting pack)
* **SQL Server Management Studio (SSMS)**

### Local Setup Steps

1. **Clone the Repository:**
   ```bash
   git clone 
   cd <your reponame>
   ```

2. **Database Configuration:**
   * Open `Web.config` in the root directory.
   * Update the connection string to match your local SQL Server instance:
     ```xml
     <connectionStrings>
       <add name="RestaurantDBContext"
        connectionString="Data Source=YOUR_SERVER;Initial Catalog=RestaurantManagementDB;Integrated Security=True;" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

3. **Apply Database Migrations:**
   * Open the **Package Manager Console** in Visual Studio and run:
     ```powerShell
     Update-Database
     ```
4. **Run the Application:**
   * Set the Web API project as the Startup Project.
   * Press `F5` to run via IIS Express or publish directly to your local **IIS Manager**.
