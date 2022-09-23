#SaveCardConsent_TC01
@ScenicMH
Feature: Send a save card consent missing sessionId

@QuoteServices
Scenario Outline: Send a save card consent request successfully	
Given User has Save Card Consent body 
	| Property                   | Value                                    |
	| SaveCardConsentRequestBody | SaveCardConsentBodyMissingSessionIdScenicMH.json |
	| QuoteRequestBody           | ValidQuoteForScenicMH.json               |
	| ApiVersion                 | V2                                       |
	| ContextName                | ScenicMotorHome                          |
	When User send Save Card Consent Read Body File
	Then Save Card Consent response returns <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages               |
	 | 400        | SessionId is required. |    