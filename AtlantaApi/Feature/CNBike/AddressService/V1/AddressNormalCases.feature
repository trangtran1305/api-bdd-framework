#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Address
#Test Case ID: Address_004
@CNBike
Feature: AddressNormalCase
	Check address service with normal cases (Happy cases)

@AddressServices
Scenario Outline: Send address request successfully	
	When User send address service with <postCode> and <houseNumber> and <ApiVersion> and <Context>
	Then The service response returns <StatusCode> and <Message>
	And The response body is displayed successfully <ResponseBodyFile>
	Examples: 
	| postCode | houseNumber | ApiVersion | Context       | StatusCode | Message                    | ResponseBodyFile         |
	| S74 0LJ  | 1           | V1         | CNBikeContext | 200        | Get addresses successfully | AddressResponseBody.json |