#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Address
#Test Case ID: Address_005,Address_006
@BeWiser
Feature: AddressInvalidRequestCases
	Check address service with abnormal cases (Invalid request cases)

@AddressServices
Scenario Outline:  Send address request with invalid endpoint or method		
	When User send request with invalid endpoint <Endpoint> or method <Method> with <ApiVersion> and <Context>
	Then The service response returns <StatusCode>
	Examples: 
	| Endpoint                                               | Method | StatusCode | ApiVersion | Context |
	| /api/v2/address1/search?postcode=S74 0LP&houseNumber=1 | GET    | 404        | V2         | BeWiser |
	| /api/v2/address/search?postcode=S74 0LP&houseNumber=1  | POST   | 404        | V2         | BeWiser |
