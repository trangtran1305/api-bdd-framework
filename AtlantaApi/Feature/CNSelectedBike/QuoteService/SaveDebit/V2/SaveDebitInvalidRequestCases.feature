#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
# TCID: Prepurchase_TC105 and Prepurchase_TC106
@CNSBike
Feature: Check Save Debit with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Debit with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then Response returns <StatusCode> and <Message>
	Examples: 
	| Endpoint                  | Method | ApiVersion | ContextName         | StatusCode | Message  |
	| /api/v2/quote/save-debit  | GET    | V2         | CNSelectBikeContext | 404        | NotFound |
	| /api/v2/quote/save-debit1 | POST   | V2         | CNSelectBikeContext | 404        | NotFound |