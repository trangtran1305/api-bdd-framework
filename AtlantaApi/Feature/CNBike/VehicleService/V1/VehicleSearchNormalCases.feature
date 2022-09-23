#ID: Vechicle_005
@CNBike
Feature: Send a vehicle search normal request

@VehicleServices
Scenario Outline: Send a vehicle search request successfully	
	Given User has search vehicle body
	| Property           | Value                        |
	| VehicleRequestBody | VehicleSearchBodyCNBike.json |
	| ApiVersion         | V1                           |
	| ContextName        | CNBikeContext                |
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages                     |
	| 200        | Search vehicle successfully. |
