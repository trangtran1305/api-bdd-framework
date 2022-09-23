#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: ACQ-536-API-TC-08, ACQ-536-API-TC-11, ACQ-536-API-TC-10

@ScenicMH
Feature: Vehicle Get List Of Models

@VehicleServices
Scenario: Vehicle Validate Get List Of Models
	Given User has vehicle info
	| Property           | Value                  |
	| VehicleRequestBody | VehicleTypeBody.json   |
	| ApiVersion         | V1                     |
	| ContextName        | ScenicMotorHome        |
	And User sends Get Vehicle Type request
	And User sends Get Manufacturer request
	When User sends Get request using <Endpoint> and <Method> and <Token>
	Then The <Endpoint> response should be shown: <StatusCode> and <Messages> and <IsSuccess>
	Examples: 
	 | Endpoint   | Method | Token   | StatusCode | Messages     | IsSuccess |
	 | ModelList  | POST   | Valid   | 404        | NotFound     | False     |
	 | ModelList  | GET    | Invalid | 401        | Unauthorized | False     |
	 | ModelList1 | GET    | Invalid | 404        | NotFound     | False     |

#Test Case ID: ACQ-536-API-TC-09
@VehicleServices
Scenario: Vehicle Validate Get List Of Models with no content
	Given User has vehicle info
	| Property           | Value                  |
	#| VehicleRequestBody | VehicleTypeBody.json   |
	| ApiVersion         | V1                     |
	| ContextName        | ScenicMotorHome        |
	And User sends Get Vehicle Type request
	And User sends Get Manufacturer request
	When User sends Get Model request using <ManufacturerId> and <VehicleTypeId>
	Then The <Endpoint> response should be shown: <StatusCode> and <Messages> and <IsSuccess>
	Examples: 
	 | Endpoint		| ManufacturerId	| VehicleTypeId	| Method | Token	| StatusCode | Messages     | IsSuccess | 
	 | ModelList	| -1				| 0				| GET    | Valid	| 204        | NoContent    | False		|