# ASP.NET Core Redis Example

This project demonstrates a basic implementation of Redis caching in an ASP.NET Core Web API application using `IDistributedCache`. The goal is to show how Redis can be used for caching in a clean, beginner-friendly, but production-aware manner.

## 📦 Technologies Used

- .NET 9
- Redis
- `Microsoft.Extensions.Caching.StackExchangeRedis`
- `StackExchange.Redis`
- Docker (optional, for local Redis instance)

## 🚀 Getting Started

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/sinanganiz/aspnetcore-redis-example.git
cd aspnetcore-redis-example
```

### 2️⃣ Run Redis Server (via Docker)

If you don’t have Redis installed locally, you can easily spin it up with Docker:

```bash
docker run -d -p 6379:6379 --name redis redis
```

To stop and remove the container later:

```bash
docker stop redis && docker rm redis
```

⚠️ Make sure Docker is installed and running.

### 3️⃣ Run the API

```bash
cd RedisDemo.API
dotnet run
```

### Configuration

```appsettings.json```

```json
{
  "ConnectionStrings": {
    "Redis": "localhost:6379"
  }
}
```

## 🧱 Project Structure

```bash
aspnetcore-redis-example/
│
├── RedisDemo.API/
│   ├── Controllers/
│   │   └── WeatherForecastController.cs
│   ├── Models/
│   │   └── WeatherForecast.cs
│   ├── Services/
│   │   ├── ICacheService.cs
│   │   └── RedisCacheService.cs
│   ├── Program.cs
│   └── appsettings.json
└── AspNetCoreRedisExample.sln
```

## 📬 Example Request

``GET /weatherforecast``

```bash
curl http://localhost:5000/api/WeatherForecast
```

- On first request: generates and caches random weather data.
- On subsequent requests: returns data from Redis cache.
- Cache expires after 60 seconds.
