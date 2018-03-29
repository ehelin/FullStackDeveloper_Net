--1) create schema 
create schema myAwesomeDatabaseLocationSchema  

--2) create location table
create table MyAwesomeDatabase.myAwesomeDatabaseLocationSchema.[location] (
	locationiId int identity(1,1),
	locationName varchar(250),
	created datetime,
	createdBy varchar(100),
	modified datetime,
	modifiedBy varchar(100)
)

--3) create location detail table
create table MyAwesomeDatabase.myAwesomeDatabaseLocationSchema.locationDetails (
	locationDetailId int identity(1,1),
	locationId int,
	weather varchar(100),
	food varchar(100),
	people varchar(100)
)

--4) insert some data
insert into MyAwesomeDatabase.myAwesomeDatabaseLocationSchema.[location]
select 'Austin TX',
	   GETUTCDATE(),
	   'eric',
	   GETUTCDATE(),
	   'eric'

insert into MyAwesomeDatabase.myAwesomeDatabaseLocationSchema.locationDetails
select (select locationiId 
		from MyAwesomeDatabase.myAwesomeDatabaseLocationSchema.[location] 
		where locationName = 'Austin TX'),
		'Warm',
		'Great', 
		'Friendly'

--5)
select *
from MyAwesomeDatabase.myAwesomeDatabaseLocationSchema.[location] l
inner join MyAwesomeDatabase.myAwesomeDatabaseLocationSchema.locationDetails ld
	on l.locationiId = ld.locationId
	