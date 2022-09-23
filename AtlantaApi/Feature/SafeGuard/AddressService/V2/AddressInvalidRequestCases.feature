#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_20.4.xlsx
#Sheet: Address
#Test Case ID: Address_005,Address_006

@SafeGuardMH
Feature: AddressInvalidRequestCases
	Check address service with abnormal cases (Invalid request cases)

@AddressServices
Scenario Outline:  Send address request with invalid endpoint or method		
	When User send request with invalid endpoint <Endpoint> or method <Method> with <ApiVersion> and <Context>
	Then The service response returns <StatusCode>
	Examples: 
	| Endpoint                                               | Method | StatusCode | ApiVersion | Context     |
	| /api/v2/address1/search?postcode=S74 0LP&houseNumber=1 | GET    | 404        | V2         | SafeGuardMH |
	| /api/v2/address/search?postcode=S74 0LP&houseNumber=1  | POST   | 404        | V2         | SafeGuardMH |