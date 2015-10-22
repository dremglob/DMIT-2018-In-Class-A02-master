<Query Kind="Expression">
  <Connection>
    <ID>51e315b6-571d-45d5-925c-12e128eab5ed</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from eachRow in SpecialEvents
where eachRow.Active
select new
{
	Code = eachRow.EventCode,
	Description = eachRow.Description
}