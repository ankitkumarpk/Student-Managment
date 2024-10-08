Student Management System
This project is a full-stack student management system built using Angular 18 (non-standalone), ASP.NET Core Web API, MySQL, and Dapper. The application allows users to create, read, update, and delete student records with a user-friendly interface and efficient data handling.

Table of Contents
Tech Stack
Features
Prerequisites
Installation
Running the Application
Usage
API Endpoints
Screenshots
Contributing
License
Tech Stack
Frontend: Angular 18, Angular Material, ngx-toastr, SweetAlert2
Backend: ASP.NET Core Web API
Database: MySQL
ORM: Dapper
Notifications: ngx-toastr for toast notifications and SweetAlert2 for popups
Features
Create, Read, Update, Delete (CRUD) operations for student records.
Real-time validation and error feedback using Angular Reactive Forms.
Responsive UI with Angular Material components.
Toastr notifications for user feedback (e.g., success or error messages).
SweetAlert2 popups for confirmation before updating or deleting records.
MySQL for efficient data storage and retrieval, handled through Dapper.
Prerequisites
Before you begin, ensure you have the following installed:

Node.js (v16 or higher)
Angular CLI (v18 or higher)
.NET SDK (v7 or higher)
MySQL Server
Installation
1. Clone the repository
bash
Copy code
git clone https://github.com/your-username/student-management-system.git
cd student-management-system
2. Backend (ASP.NET Core Web API)
Navigate to the backend project folder and restore the dependencies:

bash
Copy code
cd StudentCrudAPI
dotnet restore
3. Frontend (Angular 18)
Navigate to the Angular project folder and install dependencies:

bash
Copy code
cd StudentCrudClient
npm install
Running the Application
1. Backend (ASP.NET Core Web API)
Ensure MySQL is running and update the connection string in the appsettings.json file:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=student_db;User=root;Password=yourpassword;"
}
Run the backend API:

bash
Copy code
cd StudentCrudAPI
dotnet run
The API will be running at https://localhost:5001.

2. Frontend (Angular Application)
Run the Angular frontend:

bash
Copy code
cd StudentCrudClient
ng serve
The frontend will be running at http://localhost:4200.

Usage
Once the application is running, you can perform the following actions:

Add Student: Fill out the form and submit to add a new student.
Edit Student: Click the edit button next to a student, modify the form, and save the changes.
Delete Student: Click the delete button next to a student to remove them from the system.
View All Students: The homepage displays a list of all registered students.
API Endpoints
GET /api/student: Retrieves a list of all students.
GET /api/student/{id}: Retrieves details of a specific student.
POST /api/student: Creates a new student.
PUT /api/student/{id}: Updates an existing student.
DELETE /api/student/{id}: Deletes a student by ID.
