
-执行用时170 ms
select FirstName, LastName, ad.City, ad.State from Person as pe left join Address as ad on pe.PersonId = ad.PersonId;