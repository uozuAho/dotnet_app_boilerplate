#!/bin/bash

docker run --rm -d \
    --name boilerplate_db \
    -p 5432:5432 \
    -e POSTGRES_PASSWORD=postgres \
    postgres
