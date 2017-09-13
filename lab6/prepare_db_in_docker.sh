docker pull library/postgres
docker run -it --name postgres -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgrespassword -e POSTGRES_DB=inventory -p 5432:5432 library/postgres
dotnet ef migrations add InitialCreate
dotnet ef database update
docker exec -it -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgddpassword -e POSTGRES_DB=inventory postgres /bin/bashInventoryRecord
