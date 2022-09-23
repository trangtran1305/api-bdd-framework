#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_20.4.xlsx
#Sheet: Pre-purchase
#TCID: Prepurchase_TC81
@SafeGuardMH
Feature: Send a save debit normal case

@QuoteServices
Scenario Outline: Send a save debit request successfully	
Given User has Save Debit body 
	| Property             | Value                         |
	| SaveDebitRequestBody | SaveDebitRequestBodySG.json   |
	| QuoteRequestBody     | ValidQuoteForSGGetQuote1.json |
	| ApiVersion           | V2                            |
	| ContextName          | SafeGuardMH                   |
	When User send Save Debit normal case
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |