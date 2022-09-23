#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Vehicle


@BeWiser
Feature: Send a vehicle search no data is returned from CDL Strata

#Test Case ID: Vehicle_009
@VehicleServices
Scenario Outline: Send a vehicle search invalid data
	Given User has search vehicle body
	| Property           | Value                             |
	| VehicleRequestBody | VehicleSearchBodyInvalidData.json |
	| ApiVersion         | V2                                |
	| ContextName        | BeWiser                      |
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages	|
	 | 204        |  NoContent	|

#Test Case ID: Vehicle_010
@VehicleServices
Scenario Outline: Send a vehicle search no data returned
	Given User has search vehicle body
	| Property           | Value                                       |
	| VehicleRequestBody | VehicleSearchBodyNoContentBeWiser.json |
	| ApiVersion         | V2                                          |
	| ContextName        | BeWiser                                |
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages	|
	 | 204        |  NoContent	|
