#SaveCardConsent_TC01
@SafeGuardMH
Feature: Send a save card consent normal case

@QuoteServices
Scenario Outline: Send a save card consent request successfully	
Given User has Save Card Consent body for SG
	| Property                   | Value                         |
	| SaveCardConsentRequestBody | SaveCardConsentBodyForSG.json |
	| QuoteRequestBody           | ValidQuoteForSGGetQuote1.json |
	| QuoteApiVersion            | V2                            |
	| CardConsentApiVersion      | V0                            |
	| ContextName                | SafeGuardMH                   |
	When User send Save Card Consent normal case for SG
	Then Save Card Consent response returns <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages               |
	 | 200        | Save data successfully |         