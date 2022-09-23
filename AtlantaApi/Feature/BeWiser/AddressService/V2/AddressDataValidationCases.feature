#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Address
#Test Case ID: Address_013 -> Address_021
@BeWiser
Feature: AddressDataValidationCases
	Check address service with abnormal cases (invalid params)

@AddressServices
Scenario Outline: Send address request with invalid params	
	When User send address service with <postCode> and <houseNumber> and <ApiVersion> and <Context>
	Then The service response returns <StatusCode> and <ErrorMessage>
	Examples: 
	| postCode | houseNumber | ApiVersion | Context | StatusCode | ErrorMessage               |
	| missing  | 1           | V2         | BeWiser | 400        | PostCode is required       |
	| GIRb 0AA | 1           | V2         | BeWiser | 400        | PostCode is invalid        |
	| SE78QJ   | 1           | V2         | BeWiser | 200        | Get addresses successfully |
	| se7 8qj  | 1           | V2         | BeWiser | 200        | Get addresses successfully |
	| SE7 8QJ  | 1           | V2         | BeWiser | 200        | Get addresses successfully |
	| bs981TL  | 1           | V2         | BeWiser | 204        | NoContent                  |
	| SE7 8QJ  | missing     | V2         | BeWiser | 200        | Get addresses successfully |
	| SE7 8QJ  | 2           | V2         | BeWiser | 200        | Get addresses successfully |
	| SE7 8QJ  | test        | V2         | BeWiser | 200        | Get addresses successfully |
	
	