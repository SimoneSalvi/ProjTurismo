select * from city;

select * from Address;

select * from Client;

select * from Ticket;

update Address set Stret = @stret, Neighborhood = @Neighborhood,
         Number = @Number, ZipCode = @ZipCode, Complement = @Complement, DtCadastre = @DtCadastre, 
         idCity = idCity
         where Id = @Id

update Address set Stret = 'A', Neighborhood = 'A',
         Number = 3, ZipCode = 'A', Complement = 'A', DtCadastre = CURRENT_TIMESTAMP, 
         idCity = 1093
         where Id = 1085

select c.Id, c.Name, c.Fone, a.Stret, a.Neighborhood, a.Number, a.ZipCode, a.Complement, a.DtCadastre, ci.Description, c.DtCadstre from Client c, Address a, City ci where a.Id = c.IdAddress and ci.Id = a.idCity



