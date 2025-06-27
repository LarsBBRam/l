FROM postgres:17
RUN apt-get update && apt-get install -y postgresql-17-pgvector
COPY ./DbInit/init-db.sql / docker-entrypoint-initdb.d/