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
browse to http://localhost:16686/

Notes on setting up Jaeger:
- run `jaegertracing/all-in-one:latest` in docker. See the
  [start Jaeger](./start_jaeger.sh) script
- install libraries in API project:

> dotnet add package Jaeger -v 0.3.6
> dotnet add package OpenTracing.Contrib.NetCore -v 0.6.2

- note that the latest versions of these libraries didn't "just work" like the
  above versions did. I don't know why.
- initialise tracing in the asp.net services. See [Tracing.cs](./src/api/Tracing.cs)


# todo
- docker-compose
- jaeger
    - why doesn't latest Jaeger and/or OpenTracing.Contrib.NetCore dotnet
      packages work? Used older version to be able to see traces in Jaeger UI.
      Latest Jaeger all-in-one image works fine.
    - refs
        - https://medium.com/imaginelearning/jaeger-tracing-on-kubernetes-with-net-core-8b5feddb6f2f
        - https://www.jaegertracing.io/docs/1.22/getting-started/
        - https://github.com/jaegertracing/jaeger-client-csharp
- starting with a fresh db, does inserting a dog also insert an animal?
- pgweb
- prometheus + grafana
- logging ... elk?
