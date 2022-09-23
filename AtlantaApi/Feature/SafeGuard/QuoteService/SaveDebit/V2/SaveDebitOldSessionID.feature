#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_20.4.xlsx
#Sheet: Pre-purchase
#TCID: Prepurchase_TC90
@SafeGuardMH
Feature: Send a save debit with old sessionID

@QuoteServices
Scenario Outline: Send a save debit request successfully with old sessionID	
Given User has Save Debit body 
	| Property             | Value                         |
	| SaveDebitRequestBody | SaveDebitRequestBodySG.json   |
	| QuoteRequestBody     | ValidQuoteForSGGetQuote1.json |
	| ApiVersion           | V2                            |
	| ContextName          | SafeGuardMH                   |
	When User send Save Debit with old sessionID
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |