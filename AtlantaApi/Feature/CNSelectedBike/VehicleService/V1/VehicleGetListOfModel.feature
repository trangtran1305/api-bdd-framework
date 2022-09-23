#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: ACQ-536-API-TC-05, 06, 08-> 11

@CNSBike
Feature: Vehicle Get List Of Models

@VehicleServices
Scenario: Vehicle Validate Get List Of Models
	Given User has vehicle info
	| Property    | Value               |
	| ApiVersion  | V1                  |
	| ContextName | CNSelectBikeContext |
	When User sends Get Models request using <Endpoint> and <Method> and <Token> and <ManufactureId>
	Then The <Endpoint> response should be shown: <StatusCode> and <Messages> and <IsSuccess>
	Examples: 
	 | Endpoint   | Method | Token   | ManufactureId | StatusCode | Messages              | IsSuccess |
	 | ModelList  | GET    | Valid   | HONDA         | 200        | Get data successfully | True      |
	 | ModelList  | GET    | Valid   | %26^$         | 204        | NoContent             | False     |
	 | ModelList  | POST   | Valid   | HONDA         | 404        | NotFound              | False     |
	 | ModelList1 | GET    | Valid   | HONDA         | 404        | NotFound              | False     |
	 | ModelList  | GET    | Invalid | HONDA         | 401        | Unauthorized          | False     |