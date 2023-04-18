select * from city;

select * from Address;

select * from Client;

select * from Ticket;

insert into Ticket (OriginIdAddress, DestinationIdAddress, IdClient, DtTicket, Value) values
 (2, 2, 2, CURRENT_TIMESTAMP, 4000.10);

 select t.Id, t.OriginIdAddress, t.DestinationIdAddress, t.Value, c.Name from Ticket t, Client c where t.IdClient = c.Id