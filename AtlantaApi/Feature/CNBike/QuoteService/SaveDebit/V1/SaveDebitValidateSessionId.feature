#Prepurchase_TC81

@CNBike
Feature: Send a save debit request with session ID

@QuoteServices
Scenario Outline: Send a save debit request successfully	
Given User has Save Debit body 
	| Property             | Value                               |
	| SaveDebitRequestBody | SaveDebitRequestBodyCNBike.json     |
	| QuoteRequestBody     | ValidQuoteForPrepurchaseCNBike.json |
	| ApiVersion           | V1                                  |
	| ContextName          | CNBikeContext                       |  
	When User send Save Debit request with <SessionId>
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	| SessionId | StatusCode | IsSuccess | Messages               |
	| Old       | 200        | true      | Save data successfully |
