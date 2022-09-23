@SafeGuardMH
Feature: Send a  save payment info normal case Instalmnts

@QuoteServices
Scenario Outline: Send a valid save payment info request successfully	
Given User has Save Payment Info body for SG
	| Property                   | Value                                     |
	| SavePaymentInfoRequestBody | SavePaymentInfoSGquestBodyInstalmnts.json |
	| ApiVersion                 | V1                                        |
	| ContextName                | SafeGuardMH                               |
	And Quote Service version "V2" and Json file is "ValidQuoteForSGGetQuote1.json"
	When User send SG Save Payment Info Normal Case
	Then SG Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |