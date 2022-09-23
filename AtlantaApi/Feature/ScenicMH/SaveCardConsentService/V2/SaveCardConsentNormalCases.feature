#SaveCardConsent_TC01
@ScenicMH
Feature: Send a save card consent normal case

@QuoteServices
Scenario Outline: Send a save card consent request successfully	
Given User has Save Card Consent body 
	| Property                   | Value                      |
	| SaveCardConsentRequestBody | SaveCardConsentBodyScenicMH.json   |
	| QuoteRequestBody           | ValidQuoteForScenicMH.json |
	| ApiVersion                 | V2                         |
	| ContextName                | ScenicMotorHome            |
	When User send Save Card Consent normal case
	Then Save Card Consent response returns <StatusCode> and <Messages>
	Examples: 
	 | StatusCode | Messages               |
	 | 200        | Save data successfully |         