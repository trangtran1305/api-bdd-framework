#Vehicle_009
@CNBike
Feature: Verify that a error message is returned if invalid data

@VehicleServices
Scenario Outline: Verify that a error message is returned if invalid data
	Given User has search vehicle body
	| Property           | Value                                   |
	| VehicleRequestBody | VehicleSearchBodyInvalidDataCNBike.json |
	| ApiVersion         | V1                                      |
	| ContextName        | CNBikeContext                           |
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages  |
	| 204        | NoContent |
