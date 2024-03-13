# Movie Microservices Project

This project aims to create a microservice architecture for managing movies and their reviews. The system is built using various technologies and follows best practices for scalability, maintainability, and performance.

## Technologies Used

- **Backend**: .NET Core
- **NoSQL Database**: MongoDB
- **Message Broker**: RabbitMQ
- **Caching**: Redis
- **Containerization**: Docker
- **API Design**: REST
- **Frontend**: React
- **Message Bus**: MassTransit
- **Object-Relational Mapping**: EF Core
- **API Gateway**: Ocelot
- **Authentication**: JWT

## Project Overview

The project consists of two main microservices:

1. **Movie Service**: Responsible for CRUD operations related to movies, including managing their attributes such as genre, description, rating, and release date.
   
2. **Review Service**: Manages reviews for movies, allowing users to add, remove, and vote on reviews. This service also implements webhooks to update movie details when a review is validated.

## Features

### Movie Service:

- Add new movies
- Remove existing movies
- Retrieve movie details including genre, description, rating, and release date
- Simple CRUD operations for managing movies

### Review Service:

- Add reviews for movies
- Remove reviews
- Upvote or downvote reviews
- Webhook integration to update movie details upon review validation
- Authentication for registered users and moderators

## Architecture

The architecture follows microservice principles, with each service encapsulating specific functionality and communicating with each other via REST APIs and message brokers.

### Components:

- **API Gateway (Ocelot)**: Handles API requests and routes them to the appropriate microservice.
- **Message Broker (RabbitMQ)**: Facilitates asynchronous communication between microservices.
- **Authentication (JWT)**: Provides secure access to the system for registered users and moderators.
- **Caching (Redis)**: Improves performance by caching frequently accessed data.
- **Database (MongoDB)**: Stores movie and review data in a NoSQL format.
- **Message Bus (MassTransit)**: Ensures reliable communication between microservices.

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository
2. Navigate to the project directory
3. Install Docker if not already installed
4. Build and run Docker containers for each microservice
5. Access the frontend application via a web browser

Detailed instructions for setting up and running the project can be found in the respective README files within each microservice directory.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
