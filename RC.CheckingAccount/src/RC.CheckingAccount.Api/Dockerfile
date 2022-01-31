#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/RC.CheckingAccount.Api/RC.CheckingAccount.Api.csproj", "src/RC.CheckingAccount.Api/"]
COPY ["src/RC.CheckingAccount.Domain/RC.CheckingAccount.Domain.csproj", "src/RC.CheckingAccount.Domain/"]
COPY ["../RC.Core/src/RC.Core/RC.Core.csproj", "../RC.Core/src/RC.Core/"]
COPY ["src/RC.CheckingAccount.Repository/RC.CheckingAccount.Repository.csproj", "src/RC.CheckingAccount.Repository/"]
COPY ["src/RC.CheckingAccount.Application/RC.CheckingAccount.Application.csproj", "src/RC.CheckingAccount.Application/"]
RUN dotnet restore "src/RC.CheckingAccount.Api/RC.CheckingAccount.Api.csproj"
COPY . .
WORKDIR "/src/src/RC.CheckingAccount.Api"
RUN dotnet build "RC.CheckingAccount.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RC.CheckingAccount.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RC.CheckingAccount.Api.dll"]