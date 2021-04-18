FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app
COPY *.sln .
COPY src/Example.Service/*.csproj ./src/Example.Service/
COPY test/Example.Service.UnitTest/*.csproj ./test/Example.Service.UnitTest/
COPY test/Example.Service.ComponentTest/*.csproj ./test/Example.Service.ComponentTest/
RUN dotnet restore
# copy full solution over
COPY . .
RUN dotnet build
FROM build AS testrunner
WORKDIR /app/test/Example.Service.UnitTest
CMD ["dotnet", "test", "--logger:trx"]
# run the unit tests
FROM build AS test
WORKDIR /app/test/Example.Service.UnitTest
RUN dotnet test --logger:trx
# run the component tests
FROM build AS componenttestrunner
WORKDIR /app/test/Example.Service.ComponentTest
CMD ["dotnet", "test", "--logger:trx"]
# publish the API
FROM build AS publish
WORKDIR /app/src/Example.Service
RUN dotnet publish -c Release -o out

# run the api
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /app/src/Example.Service/out ./
EXPOSE 80
ENTRYPOINT ["dotnet", "Example.Service.dll"]