# HousingSystem

## Project Description

### Application structure

The Catering application is built according to the Onion architecture and consists of the following components:

![structure](https://user-images.githubusercontent.com/84620072/136130919-a3110363-e78c-41d4-82f2-5363e65508ed.png)

- DB is a relational database that stores application state in tables.
- Back-end Application is a separate .NET application that implements a web service.
- Front-end Application is a separate application that runs in the user's browser. Built with Vue JS. It is delivered to the user's browser through a separate endpoint, and accesses the back-end application through the REST API.

### Database

The structure of the database is shown in the figure

![restuml](https://user-images.githubusercontent.com/84620072/136130715-6a3eb029-8f82-4e29-bb58-39ddfe121571.png)

### Back-end Application Description

The web service is built on top of ASP. NET WebAPI and provides an external API built in REST architectural style. The database is accessed through the EntityFramework Core.

Our project consists of:

- api - built using .Net 5, Swagger and MSSQL.
  - Catering.WebApi - Consists of Constrollers, Authentication, Extensions, DTOs, Logger.
  - Catering.ServicesLayer - Consists of Business Logic Part: Services.
  - Catering.RepositoryLayer - Consists of dbContexts, repositories.
  - Catering.DomainLayer - Consists of Data Access Logic: entities, dbContexts, repositories.
- client - built using Vue JS, Skote Vue template, Bootstrap 5.
