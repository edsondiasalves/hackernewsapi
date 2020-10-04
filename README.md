![.NET Core](https://github.com/edsondiasalves/hackernewsapi/workflows/.NET%20Core/badge.svg?branch=master)
[![Coverage Status](https://coveralls.io/repos/github/edsondiasalves/hackernewsapi/badge.svg?branch=master)](https://coveralls.io/github/edsondiasalves/hackernewsapi?branch=master)

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

## Cache
The default request use in memory cache to avoid get again the same stories, to disable it use:
    - curl GET 'http://localhost:5000/hackernews' --header 'DisableCache: true'

For cache cleaning
    - curl GET 'http://localhost:5000/clean'

## Changelog

Check the [Changelog file](/CHANGELOG.md) to see how I evolved the code since the beginner, there is a few tagged version and a short description
## Next features

There is a bunch of features and good practices to enhance the service, I will add them as soon as posible, the main improvement points are:

 - Integration tests: Implement integrated test that run the server and fetch real data.

 - Global exception handler: Implement a single point of treatment for exceptions (Global Filter)

 - Input validation: Implement a single point for treat mandatory fields in the request