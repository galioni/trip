if exists (select 1 from sys.tables where name = 'Country' and schema_id = '1') drop table dbo.Country;

--Country
create table dbo.Country (
  Id int IDENTITY,
  Name varchar(80) NOT NULL,
  Code char(3) NOT NULL,
  IsActive bit NOT NULL,
  Created DateTime NOT NULL,
  Modified DateTime NOT NULL,
  CONSTRAINT PK_Person PRIMARY KEY (ID)
)

insert into dbo.Country (Name, Code, IsActive, Created, Modified) values ('Brazil', 'BRL', '1', getdate(), getdate());
insert into dbo.Country (Name, Code, IsActive, Created, Modified) values ('United Kingdom', 'GBP', '1', getdate(), getdate());
select * from dbo.Country;