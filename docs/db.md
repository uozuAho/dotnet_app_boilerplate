# The database

The database for this application is built on [Marten](https://martendb.io/).


# Type hierarchies
I'm currently trying to understand how type hierarchies are supported by Marten.
See https://martendb.io/documentation/documents/advanced/hierarchies/ .


# Notes
- when animal schema was defined, the animal table was created on the existing
  database, and was left empty, even though there were existing subclasses
  in the other tables. How is this supposed to be managed?
