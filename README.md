# Purchase History Tracking Application

## Assumptions

1. **Frameworks and Versions**:
   - **Backend**: .NET 8
   - **Frontend**: Angular 17.1.0

2. **Authentication and Authorization**:
   - The user is already authenticated and authorized to use the endpoints. No authentication or authorization checks will be implemented.

3. **Data Persistence**:
   - A mock repository with demo data will be used as provided. No actual database or persistent storage will be integrated.

4. **Abstractions and Architecture**:
   - The solution will be overengineered to accommodate future features, implementing clear separations of concerns and dependency injection (IoC).

5. **Logging and Error Handling**:
   - Basic logging will be implemented to provide insights into the application's behavior.
   - Error handling will be implemented to ensure graceful failures and informative error messages.

6. **Testing**:
   - Basic unit tests will be written for the controller and service methods to ensure functionality.

7. **Frontend Implementation**:
   - Angular will be used to create a web interface to display purchase information.
   - The web interface will include a table/data grid for all purchases and a detailed view of the purchase on row click.

## Project Setup

### Backend

1. **Set up the .NET Solution**:
   - Create a .NET 8 solution with separate projects for API and business logic.

2. **Directory Structure**:
   - Organize the solution with folders for Controllers, Models, Repositories, Services, and other necessary components.

3. **Dependencies**:
   - Implement dependency injection to manage the lifecycle of components and services.

4. **API Endpoints**:
   - Implement endpoints to retrieve all purchases, a single purchase by ID, and summary statistics.

5. **Cross-Cutting Concerns**:
   - Add logging, error handling, and unit tests.

### Frontend

1. **Set up the Angular Project**:
   - Initialize an Angular 17.1.0 project for the web interface.

2. **Directory Structure**:
   - Organize the project with components for the purchase list and detail view.

3. **Data Fetching**:
   - Implement services to call the API and fetch purchase data.

4. **User Interface**:
   - Create a table/data grid to display all purchases.
   - Implement row click functionality to show detailed purchase information.
