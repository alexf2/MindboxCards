declare @purchase as table (
	salesid int not null, 
	productid int not null, 
	dt datetime not null, 
	customerid int not null 
);

insert into @purchase (salesid, productid, dt, customerid) values 
	(1, 5, '2015-05-01 10:23:05', 7), --5
	(2, 1, '2015-05-02 10:23:05', 2), --1
	(3, 11, '2015-05-03 10:23:05', 5), --11
	(4, 5, '2015-05-04 10:23:05', 4), --5
	(5, 5, '2015-05-05 10:23:05', 3), --5
	(6, 12, '2015-05-06 10:23:05', 11),--12
	(7, 7, '2015-05-07 10:23:05', 77), --7
	(8, 10, '2015-05-08 10:23:05', 4),
	(9, 11, '2015-05-09 10:23:05', 5),
	(10, 17, '2015-05-10 10:23:05', 2),
	(11, 20, '2015-05-11 10:23:05', 7),
	(12, 1, '2015-05-12 10:23:05', 3),
	(13, 11, '2015-05-13 10:23:05', 2),
	(14, 5, '2015-05-14 10:23:05', 5),
	(15, 12, '2015-05-15 10:23:05', 11),
	(16, 19, '2015-05-16 10:23:05', 11),
	(17, 19, '2015-05-17 10:23:05', 7),  --product 19
	(17, 11, '2015-05-18 10:23:05', 7),
	(17, 11, '2015-05-19 10:23:05', 2),
	(17, 11, '2015-05-20 10:23:05', 5);



select productid, count(*) [count] from
	(select customerid, productid, row_number() over(partition by customerid order by dt) rn 
		from @purchase) tmp
		where rn = 1
		group by productid
			order by [count] desc
	


