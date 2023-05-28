[![Open in Gitpod](https://gitpod.io/button/open-in-gitpod.svg)](https://gitpod.io/#https://github.com/edsondiasalves/hackernewsapi)

![.NET Core](https://github.com/edsondiasalves/hackernewsapi/workflows/.NET%20Core/badge.svg?branch=master)
[![Coverage Status](https://coveralls.io/repos/github/edsondiasalves/hackernewsapi/badge.svg?branch=master)](https://coveralls.io/github/edsondiasalves/hackernewsapi?branch=master)

# This is the HackerNewsApi

The hacker new api, is a service that returns the last news from https://news.ycombinator.com/

## How to run the app
    - mkdir hackernewsapi
    - git clone https://github.com/edsondiasalves/hackernewsapi.git
    - dotnet run --project hackernewsapi/hackernewsapi.csproj 

## How to run the unit tests
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

 - Global exception handler: Implement a single point of treatment for exceptions (Global Filter)

 - Input validation: Implement a single point for treat mandatory fields in the request