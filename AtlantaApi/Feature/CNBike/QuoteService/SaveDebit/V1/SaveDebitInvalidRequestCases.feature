#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
# TCID: Prepurchase_TC82
# and Prepurchase_TC183
@CNBike
Feature: Check Save Debit with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Debit with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then The response returns <StatusCode>
	Examples: 
	| Endpoint                  | Method | ApiVersion | ContextName   | StatusCode |
	| /api/v1/quote/save-debit  | GET    | 1          | CNBikeContext | 404        |
	| /api/v1/quote/save-debit1 | POST   | 1          | CNBikeContext | 404        |