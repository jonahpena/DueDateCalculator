FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DueDateCalculator/DueDateCalculator.csproj", "DueDateCalculator/"]
RUN dotnet restore "DueDateCalculator/DueDateCalculator.csproj"
COPY . .
WORKDIR "/src/DueDateCalculator"
RUN dotnet build "DueDateCalculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DueDateCalculator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DueDateCalculator.dll"]
