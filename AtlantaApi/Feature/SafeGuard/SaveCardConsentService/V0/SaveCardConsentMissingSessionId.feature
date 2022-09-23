#SaveCardConsent_TC01
@SafeGuardMH
Feature: Send a save card consent missing sessionId

@QuoteServices
Scenario Outline: Send a save card consent request successfully	
Given User has Save Card Consent body for SG 
	| Property                   | Value                                      |
	| SaveCardConsentRequestBody | SaveCardConsentBodyMissingSessionIdSG.json |
	| QuoteRequestBody           | ValidQuoteForScenicMH.json                 |
	| QuoteApiVersion            | V2                                         |
	| CardConsentApiVersion      | V0                                         |
	| ContextName                | SafeGuardMH                                |
	When User send Save Card Consent Read Body File for SG
	Then Save Card Consent response returns <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages               |
	 | 400        | SessionId is required. |    