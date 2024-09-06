FROM ubuntu:24.04

RUN apt-get update --yes
RUN apt-get install build-essential --yes
RUN apt install zlib1g --yes
RUN apt-get install -y dotnet-sdk-8.0

COPY . . 

RUN dotnet add package xunit
RUN dotnet add package Bogus
RUN dotnet add package Microsoft.EntityFrameworkCore.InMemory 
RUN dotnet add package Swashbuckle.AspNetCore
RUN dotnet add package XRoadLib

CMD dotnet run