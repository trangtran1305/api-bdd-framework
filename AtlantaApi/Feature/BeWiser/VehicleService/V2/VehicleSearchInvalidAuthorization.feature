#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Vehicle
#Test Case ID: Vehicle_012

@BeWiser
Feature: Check API return error when invalid authorized token

@VehicleServices
Scenario Outline: Check API return error when invalid authorized token	
	Given User has search vehicle body
	| Property           | Value                              |
	| VehicleRequestBody | VehicleSearchBodyBeWiser.json |
	| ApiVersion         | V2                                 |
	| ContextName        | BeWiser                       |
	When User send Vehicle Search service invalid token
	Then The Vehicle response should show <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages     |
	 | 401        | Unauthorized |
