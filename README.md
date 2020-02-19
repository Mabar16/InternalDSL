# InternalDSL

This project showcases an internal domain specific language written in C# for creating SQL queries. 

Instances of the metamodel represent SQL queries. The current implementation allows SELECT and UPDATE statements to be created. An instance of a given statement contains instances of objects representing the other clauses of the query, i.e. SQLSelect object contains one or no instances of the SQLWhere class and exactly one instance of the SQLFrom class. 

The DSL creates SQL queries, which can be executed on appropriate databases. The current example program allows for connecting to SQL and Postgres databases. 
