#Refer manual test cases: Atlanta_APi_System Test
#Sheet PrePurchase - TC105->TC107, TC129-TC131, TC108-109, TC113-123, TC126-127
#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC104
@SafeGuardMH
Feature: Validate Save Card Consent Single Field	
@QuoteServices
Scenario Outline: Validate Save Card Consent request with single fields
Given User has Save Card Consent body for SG
	| Property                   | Value                         |
	| SaveCardConsentRequestBody | SaveCardConsentBodyForSG.json |
	| QuoteRequestBody           | ValidQuoteForSGGetQuote1.json |
	| QuoteApiVersion            | V2                            |
	| CardConsentApiVersion      | V0                            |
	| ContextName                | SafeGuardMH                   |
	When User send Save Card Consent request for SG
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Save Card Consent response returns <StatusCode> and <Messages>
	Examples:
	| Level1                  | Value                                                          | StatusCode | Messages                             |
	| SessionId               | null                                                           | 400        | SessionId is required.               |
	| SessionId               | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvv | 400        | SessionId is invalid.                |
	| ProposerIsCardHolder    | missing                                                        | 400        | ProposerIsCardHolder is required.    |
	| CardAutoReuseConsent    | missing                                                        | 400        | CardAutoReuseConsent is required.    |
	| CardStoreDetailsConsent | missing                                                        | 400        | CardStoreDetailsConsent is required. |
	| ConsentToAutoRenew      | missing                                                        | 400        | ConsentToAutoRenew is required.      |