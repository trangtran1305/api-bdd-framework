#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Address
#Test Case ID: Address_004
@AutonetVan
Feature: AddressNormalCase
	Check address service with normal cases (Happy cases)

@AddressServices
Scenario Outline: Send address request successfully	
	When User send address service with <postCode> and <houseNumber> and <policyType> and <ApiVersion> and <Context>
	Then The service response returns <StatusCode> and <Message>
	And The response body is displayed successfully <ResponseBodyFile> 
	Examples: 
	| postCode | houseNumber | policyType | ApiVersion | Context    | StatusCode | Message                    | ResponseBodyFile         |
	| S74 0LJ  | 1           |   PC         | V2         | AutonetVan | 200        | Get addresses successfully | AddressResponseBody.json |
	