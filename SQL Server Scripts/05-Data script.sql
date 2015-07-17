use demolibrary
go

SET IDENTITY_INSERT category ON
insert into category (id, name) values (1,'Classic novels')
insert into category (id, name) values (2,'Philosophy')
insert into category (id, name) values (3,'Science Fiction')
insert into category (id, name) values (4,'Humor')
SET IDENTITY_INSERT category OFF

SET IDENTITY_INSERT author ON
insert into author (id, name) values (1,'Dostoyevsky')
insert into author (id, name) values (2,'Henri Bergson')
insert into author (id, name) values (3,'Scott Adams')
SET IDENTITY_INSERT author OFF

insert into book (name, category, author) values ('Crime and punishment', 1, 1)
insert into book (name, category, author) values ('The Brothers Karamazov', 1, 1)
insert into book (name, category, author) values ('Matter and Memory', 2, 2)
insert into book (name, category, author) values ('Time and Free Will', 2, 2)
insert into book (name, category, author) values ('God''s Debris', 3, 3)
insert into book (name, category, author) values ('The Dilbert Future', 4, 3)

--select b.Id, b.Name, c.name [Category], a.name [Author]
--from book b 
--left join author a on b.author = a.id
--left join category c on b.category = c.id