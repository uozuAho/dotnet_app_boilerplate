# dotnet boilerplate app

- dotnet core web api
- [Marten document database](https://martendb.io/)
    - runs on postgres


# getting started
```sh
./start_db.sh
cd src/api
dotnet run
```


# inspecting/querying the db
```sh
# interactive psql session
docker exec -it boilerplate_db psql -U postgres
# print current schema to console
docker exec boilerplate_db pg_dump -U postgres -s postgres
```

For more about the db, see the [db docs](./docs/db.md).


# todo
- docker-compose
- pgweb
- prometheus + grafana
- jaeger
- logging ... elk?
