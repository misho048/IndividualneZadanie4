create Database CompanyOrganization
go
use CompanyOrganization

create table Department(
Id int Identity(1,1) not null primary key,
Name varchar(50) not null,
Code varchar (20) not null unique,
DepartmentType varchar (20) not null,
SuperiorDepartmentId int foreign key references Department(Id))


create table Employee
( Id int Identity(1,1) primary key,
Title varchar(4),
Name varchar(20) not null,
Surname varchar(20) not null,
PhoneNumber varchar(15),
Mail varchar(50) not null,
DepartmentId int  foreign key references Department(Id) 
)

alter table Department
add ManagerEmployeeId int  foreign key  references Employee(Id)      
	                            
                           