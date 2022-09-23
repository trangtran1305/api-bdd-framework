#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Vehicle
#Test Case ID: Vehicle_006, Vehicle_011

@BeWiser
Feature: Check Vehicle Search with invalid endpoint or method

@VehicleServices
Scenario Outline: Check Vehicle Search with invalid endpoint or method
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then Response returns <StatusCode> and <Message>
	Examples: 
	| Endpoint                 | Method | ApiVersion | ContextName  | StatusCode | Message  |
	| /api/v2/vehicles/search  | GET    | V2         | BeWiser | 404        | NotFound |
	| /api/v2/vehicles/search1 | POST   | V2         | BeWiser | 404        | NotFound |
