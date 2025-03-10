# Easy Employee Management System (EEMS)

![WPF](https://img.shields.io/badge/WPF-.NET-blue)
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-ORM-green)
![Layered Architecture](https://img.shields.io/badge/Architecture-Layered-orange)

The Easy Employee Management System EEMS) is a desktop application designed to manage employee-related operations in an organization. It will provide features such as adding employees, tracking absences, managing departments, assigning projects, and handling vacations, sanctions, training, and leaves.

## Screenshots

<img src="https://github.com/user-attachments/assets/d9f09ced-cb96-40d3-bae9-3f277f1e149f" width=100% height="auto">

<img src="https://github.com/user-attachments/assets/be010574-cd29-4694-b4d7-52231863afd8" width=100% height="auto">


## Features

- **Employee Management**:
  - Add, update, and delete employee records.
  - View employee details (name, department, job nature, etc.).
- **Absence Tracking**:
  - Track employee absences and generate reports.
- **Department Management**:
  - Create and manage departments.
  - Assign employees to departments.
- **Project Management**:
  - Assign employees to projects.
  - Track project progress and employee involvement.
- **Vacation and Leave Management**:
  - Apply for vacations and leaves.
  - Approve or reject leave requests.
- **Sanctions and Training**:
  - Record employee sanctions.
  - Schedule and track employee training sessions.
- **Reporting**:
  - Generate reports for employee performance, absences, leaves, and more.


## Technologies Used

- **Front End**: WPF (Windows Presentation Foundation)
- **Back End**: .NET Core
- **Database**: SQL Server
- **ORM**: Entity Framework Core (Code-First Approach)
- **Architecture**: Layered Architecture (UI, Business Logic, Data Access) and MVVM
- **Tools**: Visual Studio, SQL Server Management Studio (SSMS)



## Project Structure

The project follows a **layered architecture** with the following layers:

1. **UI Layer (WPF)**:
   - Contains the user interface (Windows, Pages, and user controls).
   - Communicates with the Business Logic Layer for data processing.

2. **Business Logic Layer**:
   - Contains the core business logic and services.
   - Validates data and processes requests from the UI Layer.

3. **Data Access Layer**:
   - Manages database operations using Entity Framework Core.
   - Contains entity classes (e.g., `Employee`, `Department`, `Project`, etc.).
   - Defines the database schema using EF Core Code-First.


## Getting Started

### Prerequisites

- [.NET 9 SDK ](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or alternative)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or another database supported by EF Core)

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/amuza2/Easy-Employee-Management-System.git
   cd easy-employee-management-system
   ```

2. **Set Up the Database**:
   - Update the connection string in `appsettings.json`  to point to your SQL Server instance.
   - Run the following commands in the Package Manager Console to apply migrations and create the database:
     ```bash
     Update-Database
     ```

3. **Run the Application**:
   - Open the solution in Visual Studio.
   - Build and run the project.
