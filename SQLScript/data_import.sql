use Registration;
GO

INSERT INTO dbo.Priority (priority_name)
VALUES ('Tief'),
('Standard'),
('Express');
GO

INSERT INTO dbo.Service(service_name)
VALUES ('Kleiner-Service'),
('Grosser-Service'),
('Rennski-Service'),
('Bindung-montieren-und-einstellen'),
('Fell-zuschneiden'),
('Heisswachsen');
GO

INSERT INTO dbo.Status(status_name)
VALUES ('Offen'),
('InArbeit'),
('abgeschlossen');
GO

INSERT INTO dbo.Users (username, password, counter)
VALUES ('alex', 'test123', 0);
GO

select * from dbo.Status;
GO

select * from dbo.Priority;
GO

select * from dbo.Service;
GO

select * from dbo.Registrations;
GO

select * from dbo.Users;
GO