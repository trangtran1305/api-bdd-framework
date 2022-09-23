#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_20.4.xlsx
#Sheet: Pre-purchase
#TCID: Prepurchase_TC82 and Prepurchase_TC83
@SafeGuardMH
Feature: Check Save Debit with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Debit with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then The response returns <StatusCode>
	Examples: 
	| Endpoint                  | Method | ApiVersion | ContextName | StatusCode |
	| /api/v2/quote/save-debit1 | POST   | V2         | SafeGuardMH | 404        |
	| /api/v2/quote/save-debit  | GET    | V2         | SafeGuardMH | 404        |