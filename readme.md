# dotnet boilerplate app

An observable dotnet asp.net web API.

- dotnet core web api
- [Marten document database](https://martendb.io/)
    - runs on postgres
- [Jaeger](https://www.jaegertracing.io/) for tracing


# getting started
```sh
./start_db.sh
./start_jaeger.sh
cd src/api
dotnet run
browse to https://localhost:5001/swagger
```


# inspecting/querying the db
```sh
# interactive psql session
docker exec -it boilerplate_db psql -U postgres
# print current schema to console
docker exec boilerplate_db pg_dump -U postgres -s postgres
```

For more about the db, see the [db docs](./docs/db.md).


# viewing traces in Jaeger
Browse to http://localhost:16686/. For more details, see [tracing](./docs/tracing.md)


# todo
- docker-compose
- pgweb
- prometheus + grafana
- logging ... elk?
- jaeger
    - why doesn't latest Jaeger and/or OpenTracing.Contrib.NetCore dotnet
      packages work? Used older version to be able to see traces in Jaeger UI.
      Latest Jaeger all-in-one image works fine.
- db: starting with a fresh db, does inserting a dog also insert an animal?
