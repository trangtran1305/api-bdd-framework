#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
# TCID: Prepurchase_TC01 and Prepurchase_TC02
@SafeGuardMH
Feature: Check Save Payment Info with invalid endpoint or method

@QuoteServices
Scenario Outline: Check Save Payment Info with invalid endpoint or method
	Given User has got token successful
	When User send request with invalid endpoint <Endpoint> or method <Method> of version <ApiVersion> with context <ContextName> 
	Then Response returns <StatusCode> and <Message>
	Examples: 
	| Endpoint                           | Method | ApiVersion | ContextName | StatusCode | Message                 |
	| /api/V1/quote/save-payment-info    | GET    | 1          | SafeGuardMH | 404        | NotFound                |
	| /api/V1/quote/save-payment-infoabc | POST   | 1          | SafeGuardMH | 404        | NotFound                |
	| /api/V1/quote/save-payment-info    | POST   | 1          |             | 400        | Tenant is not supported |