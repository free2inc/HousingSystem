# HousingSystem

## Project Description

### Application structure

The Catering application is built according to the Onion architecture and consists of the following components:

![structure](https://github.com/free2inc/HousingSystem/blob/main/docs/Structure.png)

- DB is a relational database that stores application state in tables.
- Back-end Application is a separate .NET application that implements a web service.
- Front-end Application is a separate application that runs in the user's browser. Built with Vue JS. It is delivered to the user's browser through a separate endpoint, and accesses the back-end application through the REST API.

### Database

The structure of the database is shown in the figure

![restuml](https://github.com/free2inc/HousingSystem/blob/main/docs/DB.png)

### Back-end Application Description

The web service is built on top of ASP. NET WebAPI and provides an external API built in REST architectural style. The database is accessed through the EntityFramework Core.

Our project consists of:

- api - built using .Net 5, Swagger and MSSQL.
  - Catering.WebApi - Consists of Constrollers, Authentication, Extensions, DTOs, Logger.
  - Catering.ServicesLayer - Consists of Business Logic Part: Services.
  - Catering.RepositoryLayer - Consists of dbContexts, repositories.
  - Catering.DomainLayer - Consists of Data Access Logic: entities, dbContexts, repositories.
- client - built using Vue JS, Skote Vue template, Bootstrap 5.
