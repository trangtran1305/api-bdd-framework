#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
# TCID: Prepurchase_TC105 and Prepurchase_TC106
@ScenicMH
Feature: Check Save Card Consent with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Card Consent with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then The response returns <StatusCode>
	Examples: 
	| Endpoint                      | Method | ApiVersion | ContextName     | StatusCode |
	| /api/quote/save-card-consent  | GET    | V2         | ScenicMotorHome | 404        |
	| /api/quote/save-card-consent1 | POST   | V2         | ScenicMotorHome | 404        |