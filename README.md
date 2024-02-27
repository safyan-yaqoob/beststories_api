# Hacker News API Integration

This ASP.NET Core API integrates with the Hacker News API to retrieve the best stories and provides caching for efficient performance.

## Features

- Retrieves the best stories from the Hacker News API based on user-defined parameters.
- Implements caching to optimize performance and reduce the load on the Hacker News API.
- Utilizes the circuit breaker pattern to handle transient faults when communicating with the Hacker News API.
- Allows users to specify the number of stories to retrieve.

## Getting Started

Follow these instructions to get the project up and running on your local machine.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) installed on your machine.
- HackervNews API(https://hacker-news.firebaseio.com/v0/)

### Installation

1. Clone the repository:

   ```sh
   git clone (https://github.com/safyan-yaqoob/beststories_api.git)
   
### How to run

1. Run by dotnet CLI:

   ```sh
   dotnet run

2. Run by Visual Studio
   ```sh
   Open the project in Visual Studio and press the green Start Button.
