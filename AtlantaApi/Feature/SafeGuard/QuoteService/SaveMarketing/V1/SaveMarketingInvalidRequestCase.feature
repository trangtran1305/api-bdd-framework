#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet: Prepurchase
#Test Case ID: Prepurchase_TC37, Prepurchase_TC38
@SafeGuardMH
Feature: Check Save Marketing with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Marketing with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then The response returns <StatusCode>
	Examples: 
	| Endpoint                      | Method | ApiVersion | ContextName | StatusCode |
	| /api/V1/quote/save-marketing  | GET    | 1          | SafeGuardMH | 404        |
	| /api/V1/quote/save-marketing1 | POST   | 1          | SafeGuardMH | 404        |