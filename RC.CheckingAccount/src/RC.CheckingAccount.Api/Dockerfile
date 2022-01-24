#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CheckingAccount/src/RC.CheckingAccount.Api/RC.CheckingAccount.Api.csproj", "CheckingAccount/src/RC.CheckingAccount.Api/"]
RUN dotnet restore "CheckingAccount/src/RC.CheckingAccount.Api/RC.CheckingAccount.Api.csproj"
COPY . .
WORKDIR "/src/CheckingAccount/src/RC.CheckingAccount.Api"
RUN dotnet build "RC.CheckingAccount.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RC.CheckingAccount.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RC.CheckingAccount.Api.dll"]