select * from package;
--delete from package;
insert into Package (Hotel, Ticket, DtCadastre, Value, Client) values 
                    (@Hotel, @Ticket, @DtCadastre, @Value, @Client)

select p.id as IdPacote, p.Value as ValorPacote, 
				h.Name as NomeHotel, 
				t.OriginIdAddress as IdOrigem, ci.Description as CidadeOrigem,
				t.DestinationIdAddress as IdDestino, ci1.Description as CidadeDestino,
				c.Name  
                from Package p 
				join Ticket t on p.Ticket = t.Id 
                join Hotel h on p.Hotel = h.id 
                join Client c on p.Client = c.Id  
				join Address a on t.OriginIdAddress = a.Id
				join Address a1 on t.DestinationIdAddress = a1.Id
				join City ci on a.idCity = ci.Id
				join City ci1 on a1.idCity = ci1.Id

update Package set Hotel = @Hotel, Ticket = @Ticket, 
					dtCadastre = @DtCadastre, 
					Value = Value, Client = Client
				where id = @Id




select * from hotel;
--delete from hotel;

select * from Ticket;
delete from Ticket where id = 1012;
select t.Id as IdTicket, 
       t.OriginIdAddress as IdOrigem, 
	   t.Value as ValorTicket, 
	   a.Stret as RuaOrigem, 
	   a.Neighborhood as BairroOrigem, 
	   a.Number as NumeroOrigem, 
	   a.ZipCode as CepOrigem, 
	   a.Complement as ComplementoOrigem,
	   ci.Description as CidadeOrigem,
       t.DestinationIdAddress as IdDestino,
	   a.
	   a.Stret as RuaDestino, a.Neighborhood, a.Number, a.ZipCode, a.Complement, ci.Description,
	   c.Name, c.Fone, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, ci.Description 
	from Ticket t
	join Client c on t.IdClient = c.Id
	join Address a on t.OriginIdAddress = a.Id
	join City ci on a.idCity = ci.Id


select t.Id, t.Value,
		t.OriginIdAddress, ci.Description as CidadeOrigem, 
		t.DestinationIdAddress,  ci1.Description as CidadeDestino,  
		c.Name
				from Ticket t
				join Client c on t.IdClient = c.Id
				join Address a on t.OriginIdAddress = a.Id
				join Address a1 on t.DestinationIdAddress = a1.Id
				join City ci on a.idCity = ci.Id
				join City ci1 on a1.idCity = ci1.Id
				

select * from client;
--delete from client;

select * from Address;
--delete from Address;
select a.Id, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, a.DtCadastre, c.Description 
	from Address a, City c Where c.Id = a.idCity;


select * from City;
--delete from city;

insert into City (Description, DtCadastro) values ('Brotas - SP', CURRENT_TIMESTAMP)

update City set Description = 'Araraquara' where Id = 1065;

select p.id, h.Name, t.OriginIdAddress, ci.Description, t.DestinationIdAddress, ci.Description, p.Value, c.Name  from Package p 
	join Hotel h on p.Hotel = h.id 
	join Ticket t on p.Ticket = t.Id
	join Client c on p.Client = c.Id
--	join Address a on h.Address = a.Id
	join Address a on a.idCity = ci.Id
	join City ci on a.idCity = ci.Id