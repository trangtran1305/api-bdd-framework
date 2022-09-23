#TCID: Vehicle_010
@CNSBike
Feature: Send a vehicle search no data is returned from CDL Strata

@VehicleServices
Scenario Outline: Send a vehicle search no data is returned from CDL Strata
	Given User has search vehicle body
	| Property           | Value                           |
	| VehicleRequestBody | VehicleSearchBodyNoContentCNSBike.json |
	| ApiVersion         | V2                              |
	| ContextName        | CNSelectBikeContext             | 
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages  |
	 | 204        | NoContent |
