#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Vehicle
#Test Case ID: Vehicle_005

@BeWiser
Feature: Send a vehicle search normal request

@VehicleServices
Scenario Outline: Send a vehicle search request successfully	
	Given User has search vehicle body
	| Property           | Value                              |
	| VehicleRequestBody | VehicleSearchBodyBeWiser.json |
	| ApiVersion         | V2                                 |
	| ContextName        | BeWiser                       |
	When User send Vehicle Search service normal case
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | ApiVersion | ContextName  | StatusCode | Messages              |
	 | V2         | BeWiser | 200        | Get data successfully |
