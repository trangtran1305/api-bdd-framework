#TCID: Vehicle_005

@CNSBike
Feature: Send a vehicle search normal request

@VehicleServices
Scenario Outline: Send a vehicle search request successfully	
	Given User has search vehicle body
	| Property           | Value                  |
	| VehicleRequestBody | VehicleSearchBodyCNSBike.json |
	| ApiVersion         | V2                     |
	| ContextName        | CNSelectBikeContext    |
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | ApiVersion | ContextName         | StatusCode | Messages              |
	 | V2         | CNSelectBikeContext | 200        | Get data successfully |
