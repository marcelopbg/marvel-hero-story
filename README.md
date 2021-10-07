# marvel-hero-story

There are two ways of running the application.

## 1. Running with Docker

The simplest way is to run it within docker, 
to do so you must have docker installed and follow the steps below:

- navigate do the repository root folter 

- run ```docker build . -t marvel``` (will build the container image, -t is the stands for tag, which we use as a name for the container image).

- run ```docker run -d -p 4779:80 --name marvel marvel``` (will create and run a container named "marvel" within the container image built in the last command named as "marvel")

the container will run on the specified port "4779", you can change the port if you need to do so.

the application should be available at localhost:4779.

## 2. Running with dotnet and nodeJS

To run in a development environment or if you're not familiar with docker you should do the following.

- Install nodeJS

- Install dotnet and it's CLI

- Go to the clientApp folder located in "marvel-hero-story/MarvelHeroStory.Web/ClientApp"

- Run ``` npm install && npm start``` (Application will be served in the port 4200)

- Go to the parent directory located in "marvel-hero-story/MarvelHeroStory.Web"

- Run ``` dotnet run ``` The application should run in port 5001 and proxy to the single page application.

the application should be available at localhost:5001.

