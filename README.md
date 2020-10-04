![.NET Core](https://github.com/edsondiasalves/hackernewsapi/workflows/.NET%20Core/badge.svg?branch=master)
[![Coverage Status](https://coveralls.io/repos/github/edsondiasalves/hackernewsapi/badge.svg)](https://coveralls.io/github/edsondiasalves/hackernewsapi)

# This is the HackerNewsApi

The hacker new api, is a service that returns


## How to run the app
    - mkdir hackernewsapi
    - git clone [](https://github.com/edsondiasalves/hackernewsapi.git)
    - cd hackernewsapi
    - dotnet build
    - cd src
    - dotnet run 

## How to run the unit tests
    - cd hackernewsapi
    - dotnet test

## How to get the data
    - curl GET 'http://localhost:5000/hackernews'

## Changelog

Check the [Changelog file](/CHANGELOG.md) to see how I evolved the code since the beginner, there is a few tagged version and a short description
## Next features

There is a bunch of features and good practices to enhance the service, I will add them as soon as posible, the main improvement points are:

 - Caching the results: Implement a cache mecanism that hold the details of the stories and the user can opt use it or not.

 - Code coverage reports: Implement the code coverage report tool

 - Clear cache endpoint: Enndpoin to clean the existent cache.

 - Swagger documentation: Generate automatically swagger documentation of the service description

 - Global exception handler: Implement a single point of treatment for exceptions (Global Filter)

 - Input validation: Implement a single point for treat mandatory fields in the request

 - Integration tests: Implement integrated test that run the server and fetch real data.

 - Continuous Integration: Implement a pipeline that checks the state of the code before commit in the main branch