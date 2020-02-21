# Internal DSL - SQL Query Generator

This project showcases an internal domain specific language written in C# for creating SQL queries for SQL Server databases. 

## Metamodel
Instances of the metamodel represent SQL queries and inherit from the AbstractSQLQuery class. The current implementation allows SELECT and UPDATE statements to be created. An instance of a given statement contains instances of the SQLComponent inteface which define clauses of the SQL query such as from, where, join, etc.

![Metamodel](images/metamodel.png)

e.g. an instance of SQLSelect can contain instances of SQLFrom and SQLWhere to create the following query:
```SQL
Select 'x' 
From 'Y' 
Where a = 'b' 
```

The DSL creates SQL queries, which can be executed on appropriate databases. The current example program allows for connecting to SQL Server databases. 

## Code Example

The structure of the DSL is as follows:
```C#
var builder = new SQLQueryBuilder();
var selectQuery = builder.
                    Select("students.name", "grade", "course", "major").
                    Distinct().
                    From("students").
                    InnerJoin("grades",("students.name","grades.name")).
                    Where(("students.name", "grades.name")).
                    OrderBy("students.name").
                    FinishQuery();
```
