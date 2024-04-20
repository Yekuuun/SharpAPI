```                
               ________  ___  ___  ________  ________  ________  ________  ________  ___     
              |\   ____\|\  \|\  \|\   __  \|\   __  \|\   __  \|\   __  \|\   __  \|\  \    
              \ \  \___|\ \  \\\  \ \  \|\  \ \  \|\  \ \  \|\  \ \  \|\  \ \  \|\  \ \  \   
               \ \_____  \ \   __  \ \   __  \ \   _  _\ \   ____\ \   __  \ \   ____\ \  \  
                \|____|\  \ \  \ \  \ \  \ \  \ \  \\  \\ \  \___|\ \  \ \  \ \  \___|\ \  \ 
                  ____\_\  \ \__\ \__\ \__\ \__\ \__\\ _\\ \__\    \ \__\ \__\ \__\    \ \__\
                 |\_________\|__|\|__|\|__|\|__|\|__|\|__|\|__|     \|__|\|__|\|__|     \|__|
                 \|_________|                                                                
```


**SharpAPI** is a simple and easy-to-use pre-built ASP.NET Core web API using clean architecture. Unlike other base clean architecture projects, I've decided to develop additional features to help you build fast and robust web APIs using .NET 8.

This project includes a base user service application for managing users.

## Code Architecture
Before delving into features, let's explain the code organization:

**MODELS:**
Models are used to define your future database entities. I've chosen to use BaseEntity models to centralize data logic, such as IDs and creation dates, for cleaner code.

**REPOSITORIES:**
Repositories are utilized to interact directly with the database using an abstraction layer for communication.

**SERVICES:**
Services are employed to manipulate client data using DTOs (Data Transfer Objects) and interact with the database using repository methods.

**CONTROLLERS:**
Controllers are responsible for interacting with your API through endpoints and retrieving data.

**MIGRATIONS :**
Migrations are used to interact with database creating your Models into it.

Creating migrations ? : `dotnet ef migrations add <migration_name>`

---

You will also find a demonstration of pagination system used to interact with large amount of data using pages.

## Depencies 
this project use to following dependencies :
- Entity framework
- SQL server
- Automapper to map entities for DTO's

## Launching project : 
1. clone project on your local machine with `git clone https://github.com/Yekuuun/SharpAPI.git`
2. go to `/api` and use `dotnet restore`
3. launch application using `dotnet watch run`

**Note :**
Make sure Entity Framework is installed on your local machine. Install it :
`dotnet tool install --global dotnet-ef`

---

<img
  src="https://github.com/Yekuuun/SharpAPI/blob/main/src/dotnet-api-swagger.png?raw=true"
  alt="DebugInfo" />


