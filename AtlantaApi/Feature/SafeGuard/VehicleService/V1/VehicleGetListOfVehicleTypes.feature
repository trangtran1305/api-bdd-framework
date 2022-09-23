#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: SMQ-302-API-TC-02
@SafeGuardMH
Feature: Vehicle Get List Of Vehicle Types

@VehicleServices
Scenario: Vehicle Validate Get List Of Vehicle Types
	Given User has search vehicle bodyjson
	| Property           | Value                |
	| VehicleRequestBody | VehicleTypeBody.json |
	| ApiVersion         | V1                   |
	| ContextName        | SafeGuardMH          |
	When User sends Get request of SG using <Endpoint> and <Method> and <Token>
	Then  The <Endpoint> response of SG should be shown: <StatusCode> and <Messages> and <IsSuccess>
	Examples: 
	 | Endpoint		| Method | Token	| StatusCode | Messages                 | IsSuccess | 
	 | VehicleTypes	| GET    | Valid	| 200        | Get data successfully    | True		|