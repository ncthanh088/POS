# POS Application

## Table of Contents
- [Overview](#overview)
- [Architecture](#architecture)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
  - [Backend Setup](#backend-setup)
    - [Database Migration](#database-migration)
  - [Frontend Setup](#frontend-setup)
    - [Tailwind CSS Configuration](#tailwind-css-configuration)
- [Usage](#usage)
- [Additional Information](#additional-information)

## Overview
This POS (Point of Sale) application is built using a clean architecture with the backend developed in ASP.NET Core and the frontend utilizing Blazor WASM, Blazor Hybrid, and MAUI. The application supports various features such as browsing items, signing in and out, printing receipts, and processing payments.

## Architecture
The application follows a clean architecture pattern and is divided into the following projects:
- **API**: Handles HTTP requests and responses.
- **Application**: Contains business logic and application services.
- **Domain**: Contains the core business entities and logic.
- **Infrastructure**: Contains data access, external services, and infrastructure-related concerns.

## Features
- **Browse Items**: Allows users to browse through available items.
- **Sign In**: Enables user authentication.
- **Logout**: Allows users to log out of the application.
- **Print Receipt**: Provides functionality to print receipts.
- **Process Payment**: Handles payment processing.

## Prerequisites
Ensure the following are installed on your machine:
- .NET SDK
- Entity Framework Core CLI
- Node.js and npm

## Setup Instructions

### Backend Setup

1. **Clone the repository**:

    ```bash
    git clone https://github.com/your-repo/POS-Application.git
    cd POS-Application
    ```

2. **Restore .NET dependencies**:

    ```bash
    dotnet restore
    ```

#### Database Migration

1. **Add a new migration**:

    ```bash
    dotnet ef --startup-project src/POS.Api/POS.Api.csproj migrations add create-database --context POSDbContext --output-dir DAL/Migrations --project src/POS.Infrastructure/POS.Infrastructure.csproj
    ```

    This command creates a new migration named `create-database` for the `POSDbContext` context, outputting migration files to the `DAL/Migrations` directory within the `src/POS.Infrastructure` project.

2. **Update the database**:

    ```bash
    dotnet ef --startup-project src/POS.Api database update
    ```

    This command applies the latest migrations to the database using the `POS.Api` project as the startup project.

### Frontend Setup

1. **Navigate to the frontend directory**:

    ```bash
    cd src/POS.Frontend
    ```

2. **Install Node.js dependencies**:

    ```bash
    npm install
    ```

#### Tailwind CSS Configuration

1. **Compile and watch Tailwind CSS**:

    ```bash
    npx tailwindcss -i .\Styles\tailwind.css -o .\wwwroot\css\tailwind.css --watch
    ```

    This command compiles the input Tailwind CSS file located at `.\Styles\tailwind.css` and outputs the processed CSS to `.\wwwroot\css\tailwind.css`. The `--watch` flag ensures that the command keeps running and watches for any changes to the input file, recompiling the CSS automatically when changes are detected.

## Usage

1. **Run the backend API**:

    ```bash
    dotnet run --project src/POS.Api/POS.Api.csproj
    ```

2. **Run the frontend application** (Blazor WASM or Blazor Hybrid depending on your configuration):

    ```bash
    dotnet run --project src/POS.Frontend/POS.Frontend.csproj
    ```

    For Blazor Hybrid and MAUI applications, refer to the respective project directories and follow the specific setup and run instructions provided.

## Additional Information

For detailed information, refer to the official documentation of:
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-6.0)
- [Tailwind CSS](https://tailwindcss.com/docs)

If you encounter any issues or have questions, feel free to reach out to the project maintainers.
