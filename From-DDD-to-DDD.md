# From DDD to DDD through OCD and TDD
*My journey from Data-driven to Domain-driven*

## About this talk
- My experience as a software developer
- All the steps in the learning process
- Hopefully you learn from my mistakes

not so much about the "strategic side" really more about "tactical" in the trenches

# The beginning

Freshly graduated
Learnt how to program (or so I thought) in Java / OO / Design patterns ... 
actually started with Microsoft stack during internship

## Omnipotent Relational Db
e-commerce custom apps 
- public site (ASP.NET)
- admin site (ASP Classic / VbScript)

stored procedures only, no queries in code

app is a wrapper around Stored Procedures ... 
(classic ASP / VbScript .... early .NET)

View + Db (= data + Busines logic)

integration through the database (Front + Admin)

maintenance / source control of the database (hint : it's hard !)

it actually works "fine" when 
- mostly alone on a project (you can fit it all in **your** head)
- small project (you can fit it **all** in your head)
- initial version
- mostly read (e-commerce catalogue)

It really sucks for :
- evolutions to schema / stored procedure
- automated testing
- dev environment

you tend to over-engineer things "just in case" / not change stuff that should change ... 
Big design up front

the process : come up with a data model (tables , relationships etc)

Db first sort of design

add in translations / history and it gets funky :)

-----
other experience
the Database change committee ... 
there is ONE database / shared between apps , replicated 
rows have a double id (sqlId / incId) -> used for replication + db generated IDs.

db is shared 
many tables / many columns ... because it must model reality universally !

app doesn't own the db ... 
shared between apps (and replicated) 
it takes weeks to ask for a change
better over-engineer it when designing it !

---
Shared library that really just calls to Stored Procedure ... 
"the SDK"
variations : generated Db access code (Linq2Sql / EF Db-first)

-----------------------
Let's move the logic out of the Db !
ORMs 

- Entities are pretty much DTOs / mapping from table (actually they are generated !) + annotations ... 

Layering, hard coupling to EntityFramework ... 
Directly in controllers, like in MS Samples :P

lazy-loading, terrible performance, include ALL the things !

Database schema : everything is connected, it's hard to know where to stop ....

Let's move the logic out of controllers
-> Transaction Service + "Repository"

Repository really is a DAO + IQueryables ... 
still hard to test

------
let's make it testable
DI / IoC

Entities are still DTOs with public props + annotations 
Logic still in "services" (some are updates, some are queries, some are a mix (Request/Response))
Code first

"Repository" can be injected

"Anemic Domain Model"

Object graphs are loaded, sometimes navigation properties are filled, smetimes they are not ... 

Transaction Service ... 


--------
Aggregates

clearly cut the object graphs and avoid potential cycles in objet graphs ...
Clarify the entry point by only exposing the "official ones" in DbContext.

------
Aggregate root / proper domain model
move behavior from Transaction Script to Entities
no longer expose settable properties

----- 
Read vs Write
View-specific DTOs and projections (shared db engine, though)





# Conclusions

## Take backs
- importance of failing
- importance of feeling the friction and trying to improve

## Next ?
ES ? 



------
For each case 
- what went well
- what went wrong
- what hurt
- what was the revelation / breakthrough / the "aha" moment