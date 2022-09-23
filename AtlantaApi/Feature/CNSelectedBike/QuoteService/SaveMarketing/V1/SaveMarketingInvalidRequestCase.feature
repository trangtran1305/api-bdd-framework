#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
# TCID: Prepurchase_TC105 and Prepurchase_TC106
@CNSBike
Feature: Check Save Marketing with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Marketing with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then Response returns <StatusCode> and <Message>
	Examples: 
	| Endpoint                      | Method | ApiVersion | ContextName         | StatusCode | Message  |
	| /api/V1/quote/save-marketing  | GET    | 1          | CNSelectBikeContext | 404        | NotFound |
	| /api/V1/quote/save-marketing1 | POST   | 1          | CNSelectBikeContext | 404        | NotFound |