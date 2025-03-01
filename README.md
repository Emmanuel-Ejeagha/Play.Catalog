# Catalog MicroService

## Overview

The **Catalog Service** is a microservice responsible for managing product listings. It provides CRUD operations for catalog items and exposes RESTful APIs for other services to consume.

## Tech Stack

- .NET 8.0
- ASP.NET Core Web API
- MongoDB (Database)
- Docker (Containerization)
- RabbitMQ _(for messaging)_
- Swagger (API Documentation)

## MicroService and pkgs

- Play.Catalog: https://github.com/Emmanuel-Ejeagha/Play.Catalog

- Play.Inventory: https://github.com/Emmanuel-Ejeagha/Play.Inventory

- Play.Common: https://github.com/Emmanuel-Ejeagha/Play.Common

- packages:
  Play.common nuget pkgs: https://github.com/Emmanuel-Ejeagha/packages
- Play.Infra: https://github.com/Emmanuel-Ejeagha/Play.Infra

## Features

- Add, update, delete, and fetch catalog items.
- Retrieve product details by ID.
- Search and filter products.

## Installation

### Prerequisites

- .NET 8.0 SDK
- Docker (if running in containers)
- MongoDB installed or running in a container

### Clone the Repository

```sh
Clone all the repos in one dir
Press F5 Key to enter debug mode
or
navigate to the dotnet of each repo and run:
dotnet run
Goto Play.Infra and run
docker-compose up -d
to start Docker container
```

````

### Run the Service Locally

```sh
dotnet run
````

### Run with Docker

```sh
docker-compose up -d
```

### API Endpoints

| Method | Endpoint          | Description       |
| ------ | ----------------- | ----------------- |
| GET    | `/api/items`      | Get all products  |
| GET    | `/api/items/{id}` | Get product by ID |
| POST   | `/api/items`      | Add a new product |
| PUT    | `/api/items/{id}` | Update a product  |
| DELETE | `/api/items/{id}` | Delete a product  |

### Environment Variables

| Variable                  | Description                 |
| ------------------------- | --------------------------- |
| `MONGO_CONNECTION_STRING` | MongoDB connection string   |
| `SERVICE_PORT`            | Port number for the service |

## Contributing

1. Fork the repository.
2. Create a new feature branch.
3. Commit and push your changes.
4. Submit a pull request.

## License

MIT License

```

```
