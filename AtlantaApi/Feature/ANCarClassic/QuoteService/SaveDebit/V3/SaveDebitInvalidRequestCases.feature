#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC82, 83

@ANCarClassic
Feature: Check Save Debit with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Debit with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then The response returns <StatusCode>
	Examples: 
	| Endpoint                  | Method | ApiVersion | ContextName  | StatusCode |
	| /api/v2/quote/save-debit  | GET    | V2         | ANCarClassic | 404        |
	| /api/v2/quote/save-debit1 | POST   | V2         | ANCarClassic | 404        |
