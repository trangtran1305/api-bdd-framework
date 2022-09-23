#Refer manual test cases: Atlanta_APi_System Test
#Sheet Branding
#Refer file: Atlanta_API_System Test.xlsx
#Sheet Branding; TCID: Branding_001
@AutonetVan
Feature: Get Branding with open hours

@BrandingServices
Scenario Outline: Get Branding with open hours
	Given User has Reference Branding Data body
	 | Property    | Value        |
	 | ApiVersion  | V1           |
	 | ContextName | AutonetVan |
	When User sends get branding request using <AppUrl>
	Then Branding response should returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| AppUrl                      |  StatusCode | IsSuccess | Messages                    |
	| /api/v1/branding/open-hours |  200        | true      | Get Open Hours successfully |