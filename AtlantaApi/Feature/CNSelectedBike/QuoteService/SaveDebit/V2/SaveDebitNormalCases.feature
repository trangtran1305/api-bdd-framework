@CNSBike
Feature: Send a save debit normal case

@QuoteServices
Scenario Outline: Send a save debit request successfully	
Given User has Save Debit body 
	| Property             | Value                         |
	| SaveDebitRequestBody | SaveDebitRequestBodyCNSBike.json     |
	| QuoteRequestBody     | ValidQuoteForPrepurchaseCNSBike.json |
	| ApiVersion           | V2                            |
	| ContextName          | CNSelectBikeContext           |
	When User send Save Debit normal case
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |