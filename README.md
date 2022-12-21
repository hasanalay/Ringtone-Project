
# DESCRIPTION

A brief description of what this project does and who it's for
These instructions describe the steps required to create and connect to a database. First of all, a database administrator (for example, Microsoft SQL Server Management Studio, MySQL Workbench, etc.) is used to create a database. Using the database administrator, you can follow the following steps:
## Create a Database For the System:
- Open the database manager and create a database. In this step, you will determine the name and location of the database.

- Using the database administrator, run the following SQL commands in a query:

```
CREATE TABLE users (
id INTEGER PRIMARY KEY,
name VARCHAR(255),
email VARCHAR(255),
password VARCHAR(255)
);

CREATE TABLE ringtones (
id INTEGER PRIMARY KEY,
name VARCHAR(255),
artist VARCHAR(255),
imageurl VARCHAR(255),
audiourl VARCHAR(255),
category VARCHAR(255),
price DECIMAL
);

CREATE TABLE card_payments (
id INTEGER PRIMARY KEY,
user_id INTEGER,
ringtone_id INTEGER,
transaction_id VARCHAR(255),
amount DECIMAL,
FOREIGN KEY (user_id) REFERENCES users(id),
FOREIGN KEY (ringtone_id) REFERENCES ringtones(id)
);
```

Additionally, change the identify specification from column properties to yes

These commands will create three tables in your database with the names **`"users", "ringtones" and "card_payments"`**. These tables will contain fields with the following types of data:


- the `"users` table will contain: `id`, `name`, `email` and `password` fields.
- the `ringtones` table will contain: `id`, `name`, `artist`, `imageurl`, `audiourl`, `category` and `price` fields.
- the `card_payments` table will contain: `id`, `user_id`, `ring_id`, `transaction_id` and `amount` fields. In addition, the `user_id` and `ringtones` fields refer to the `id` fields in the `users` and `ringtones` tables.
## Connect to the Databese With Entity Framework:
After creating your database, you can follow the steps below to connect to a .NET project(specifically in Visual Studio Code)  :

Switch to the CMD in your project and run the following commands:
- `dotnet tool install --global dotnet-ef`
- `dotnet add package from Microsoft.EntityFrameworkCore.Design`
- `dotnet add package Microsoft.EntityFrameworkCore.SQLServer`

These commands will add the **Entity Framework Core (EF Core)** to your project. EF Core is a database access layer used to communicate with your database.
Add the following line to the appsettings.json file of your project:

`"ConnectionStrings": {"db": "Server=name;Database=dbname;Trusted_Connection=True;TrustServerCertificate=True"}`

This line specifies the connection string that is required to connect to your database. replace the `name` and `dbname` values with the server name and name of your **Database**.

## Run the Project on Your LocalHost:

This step contains two commands
To install all node modules that are need to be installed.
- `npm i` or `npm install`

To run the project 
- `dotnet watch run`

After that the project will run in your localhost.
