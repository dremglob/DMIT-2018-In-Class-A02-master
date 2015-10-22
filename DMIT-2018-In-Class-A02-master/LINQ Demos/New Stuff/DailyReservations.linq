<Query Kind="Statements">
  <Connection>
    <ID>51e315b6-571d-45d5-925c-12e128eab5ed</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var step1 = from eachRow in Reservations
where eachRow.ReservationStatus == 'B' // Use "B" in Visual Studio
	// TBA - && eachRow has the correct EventCode...
orderby eachRow.ReservationDate
group eachRow by new { eachRow.ReservationDate.Month, eachRow.ReservationDate.Day };

var result = from dailyReservation in step1.ToList()
select new // DailyReservation() // Create a DTO class called DailyReservation
{
	Month = dailyReservation.Key.Month,
	Day = dailyReservation.Key.Day,
	Reservations =  from booking in dailyReservation
					select new // Booking() // Create a Booking POCO Class
					{
						Name = booking.CustomerName,
						Time = booking.ReservationDate.TimeOfDay,
						NumberInParty = booking.NumberInParty,
						Phone = booking.ContactPhone,
						Event = booking.SpecialEvents == null
								? (string)null
								: booking.SpecialEvents.Description
					}
};
result.Dump();