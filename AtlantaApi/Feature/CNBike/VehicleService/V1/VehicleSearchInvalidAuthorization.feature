#Vehicle_012
@CNBike
Feature: Check API return error when invalid authorized token

@VehicleServices
Scenario Outline: Check API return error when invalid authorized token	
	Given User has search vehicle body
	| Property           | Value                                 |
	| VehicleRequestBody | VehicleSearchBodyNoContentCNBike.json |
	| ApiVersion         | V1                                    |
	| ContextName        | CNBikeContext                         |
	When User send Vehicle Search service invalid token
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages     |
	 | 401        | Unauthorized |
