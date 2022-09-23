#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: Vehicle_001-> Vehicle_003
@SafeGuardMH
Feature: Vehicle Get List Of Manufacturer

@VehicleServices
Scenario: Vehicle Validate Get List Of Manufacturer
	Given User has search vehicle bodyjson
	| Property           | Value                |
	| VehicleRequestBody | VehicleTypeBody.json |
	| ApiVersion         | V1                   |
	| ContextName        | SafeGuardMH          |
	And User sends Get Vehicle Type request for SG
	When User sends SG Get request using <Endpoint> and <Method> and <Token>
	Then The <Endpoint> response of SG should be shown: <StatusCode> and <Messages> and <IsSuccess>
	Examples: 
	 | Endpoint			| Method | Token	| StatusCode | Messages                 | IsSuccess | 
	 | ManufacturesList	| GET    | Valid	| 200        | Get data successfully    | True		|
	 | ManufacturesList	| POST   | Valid	| 404        | NotFound					| False		|
	 | ManufacturesList	| GET    | Invalid	| 401        | Unauthorized			    | False		|