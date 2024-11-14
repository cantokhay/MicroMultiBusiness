# MicroMultiBusiness

E-Commerce Platform with Microservices 🛒 | Over 50+ hours of learning from Udemy.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Microservices Overview](#microservices-overview)
- [Architecture](#architecture)
- [Other Tools](#other-tools)

## Introduction

MicroMultiBusiness is an e-commerce application built using microservices architecture, providing a modular and scalable solution for real-world online shopping scenarios. This repository contains the complete source code and resources for developing and managing an e-commerce platform.

## Features

- 🔐 **User Authentication and Authorization**: Secure user access with Identity Server and JWT.
- 🛍 **Product Catalog Management**: Manage products with MongoDB integration.
- 🛒 **Shopping Cart and Checkout System**: Efficient cart management with Redis for real-time updates.
- 📦 **Order Management**: Track and manage orders through a dedicated microservice.
- 💳 **Payment Gateway Integration**: Supports payment processing for a seamless shopping experience.
- 🧩 **Microservices Architecture**: Each feature operates as an independent microservice.
- 📱 **Responsive Frontend Design**: Optimized for various devices and screen sizes.

## Technologies Used

### Backend

- **ASP.NET Core 8.0**: For microservices and API development.
- **Identity Server 4**: Manages user authentication and authorization.
- **Dapper**: Lightweight ORM for efficient data access.
- **Redis**: Fast and reliable session and cache management.
- **RabbitMQ**: Handles asynchronous communication between services.
- **SignalR**: Real-time notifications and updates.
- **Ocelot API Gateway**: Manages and routes API requests.

### Databases

- **MSSQL**: Core relational database for structured data.
- **MongoDB**: Flexible document-based database for product catalogs.
- **PostgreSQL**: Relational database for managing user comments.
- **Redis**: Caching and session management for shopping cart.
- **SQLite**: Lightweight database for local data storage and testing.

### Infrastructure & Tools

- **Docker**: Containerizes each microservice for easy deployment.
- **Postman**: API testing and interaction.
- **Swagger**: API documentation for quick reference and testing.
- **RapidAPI**: Integrates third-party APIs for enhanced functionality.
- **DBeaver**: Database management and querying.

## Microservices Overview

- 🛒 **Basket Service**: Manages user carts with Redis.
- 📦 **Cargo Service**: Tracks shipping and delivery using MSSQL.
- 🗃 **Catalog Service**: Manages product listings with MongoDB.
- 📝 **Comment Service**: Supports user reviews stored in PostgreSQL.
- 💸 **Discount Service**: Applies coupons and discounts using MSSQL and Dapper.
- 📷 **Images Service**: Manages product images uploaded to Google Drive.
- 🏦 **Order Service**: Processes and manages user orders.
- 🔒 **Identity Service**: Handles authentication with IdentityServer4 and OAuth2.
- 💰 **Payment Service**: Uses RabbitMQ, SignalR, and RapidAPI for real-time payment processing.

## Architecture

The project is built with **Onion Architecture**, employing best practices like **CQRS**, **Mediator**, and **Repository Design Patterns** for clear separation of concerns and scalability. Key design patterns are used to ensure clean and maintainable code:

- **CQRS Design Pattern**: Separates read and write operations for optimized performance.
- **Mediator Pattern**: Manages complex operations and decouples services.
- **Repository Pattern**: Encapsulates data access logic.

## Other Tools

- **Ocelot API Gateway**: Ensures smooth routing and load balancing.
- **FluentValidation**: Provides validation for request models.
- **Localization**: Supports multiple languages for enhanced user experience.
- **Portainer**: Manages Docker containers visually for ease of use.

This project is an extensive demonstration of modern e-commerce with microservices, Docker, and cloud-based integrations—ideal for those looking to deepen their skills in building scalable, real-world applications!
