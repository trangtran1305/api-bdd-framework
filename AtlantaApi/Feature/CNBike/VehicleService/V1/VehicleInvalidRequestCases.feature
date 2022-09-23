#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#ID; Vehicle_006;Vehicle_011
@CNBike
Feature: Check Vehicle Search with invalid endpoint or method

@VehicleServices
Scenario Outline: Check Vehicle Search with invalid endpoint or method
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then The response returns <StatusCode>
	Examples: 
	| Endpoint                 | Method | ApiVersion | ContextName   | StatusCode |
	| /api/v1/vehicles/search  | GET    | V1         | CNBikeContext | 404        |
	| /api/v1/vehicles/search1 | POST   | V1         | CNBikeContext | 404        |