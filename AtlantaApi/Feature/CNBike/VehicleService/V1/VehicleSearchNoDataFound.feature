#Vehicle_010
@CNBike
Feature: Send a vehicle search no data found

@VehicleServices
Scenario Outline: Send a vehicle search no data found
	Given User has search vehicle body
	| Property           | Value                                 |
	| VehicleRequestBody | VehicleSearchBodyNoContentCNBike.json |
	| ApiVersion         | V1                                    |
	| ContextName        | CNBikeContext                         |
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages  |
	 | 204        | NoContent |
