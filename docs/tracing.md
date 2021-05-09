# Tracing

This app uses [Jaeger](https://www.jaegertracing.io/) for (distributed) tracing.

To view traces, start the app (see the [readme](../readme.md)), then browse to
http://localhost:16686/.


## Setting up Jaeger in a new project

- install libraries in API project:

```sh
dotnet add package Jaeger -v 0.3.6
dotnet add package OpenTracing.Contrib.NetCore -v 0.6.2
```

- note that the latest versions of these libraries didn't "just work" like the
  above versions did. I don't know why.
- add tracing to the asp.net services. See [Tracing.cs](../src/api/Tracing.cs)
- run `jaegertracing/all-in-one:latest` in docker. See the
  [start Jaeger](../start_jaeger.sh) script

Run your app and make some requests. You should be able to view traces at
http://localhost:16686/. The default configuration of the Jaeger dotnet library
publishes to the default listeners in the `all-in-one` container running on
localhost.


# references
- [Jaeger docs: getting stared](https://www.jaegertracing.io/docs/1.22/getting-started/)
- [Jaeger C# client](https://github.com/jaegertracing/jaeger-client-csharp)
- [walkthrough blog post](https://medium.com/imaginelearning/jaeger-tracing-on-kubernetes-with-net-core-8b5feddb6f2f)
