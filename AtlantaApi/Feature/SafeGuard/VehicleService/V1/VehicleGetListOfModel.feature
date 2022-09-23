#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: ACQ-536-API-TC-07, ACQ-536-API-TC-08, ACQ-536-API-TC-11, ACQ-536-API-TC-10
@SafeGuardMH
Feature: Vehicle Get List Of Models

@VehicleServices
Scenario: Vehicle Validate Get List Of Models
	Given User has search vehicle bodyjson
	| Property           | Value                |
	| VehicleRequestBody | VehicleTypeBody.json |
	| ApiVersion         | V1                   |
	| ContextName        | SafeGuardMH          |
	And User sends Get Vehicle Type request for SG
	And User sends Get Manufacturer request of SG
	When User sends Get request of SG using <Endpoint> and <Method> and <Token>
	Then The <Endpoint> response of SG should be shown: <StatusCode> and <Messages> and <IsSuccess>
	Examples: 
	 | Endpoint   | Method | Token   | StatusCode | Messages              | IsSuccess |
	 | ModelListSG| GET    | Valid   | 200        | Get data successfully | True      |
	 | ModelList  | POST   | Valid   | 404        | NotFound              | False     |
	 | ModelList  | GET    | Invalid | 401        | Unauthorized          | False     |
	 | ModelList1 | GET    | Invalid | 404        | NotFound              | False     |
#Test Case ID: ACQ-536-API-TC-09 and ACQ-536-API-TC-09!
@VehicleServices
Scenario: Vehicle Validate Get List Of Models with no content
	Given User has search vehicle bodyjson
	| Property           | Value                |
	| VehicleRequestBody | VehicleTypeBody.json |
	| ApiVersion         | V1                   |
	| ContextName        | SafeGuardMH          |
	And User sends Get Vehicle Type request for SG
	And User sends Get Manufacturer request of SG
	When User sends Get Model request of SG using <ManufacturerId> and <VehicleTypeId>
	Then The <Endpoint> response of SG should be shown: <StatusCode> and <Messages> and <IsSuccess>
	Examples: 
	 | Endpoint		| ManufacturerId	| VehicleTypeId	| Method | Token	| StatusCode | Messages     | IsSuccess | 
	 | ModelList	| -1				| 0				| GET    | Valid	| 204        | NoContent    | False		|
	 | ModelList	| 0					| -1			| GET    | Valid	| 204        | NoContent    | False		|