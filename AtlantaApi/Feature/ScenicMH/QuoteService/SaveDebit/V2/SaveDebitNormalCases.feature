#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_20.4.xlsx
#Sheet: Pre-purchase
#TCID: Prepurchase_TC81
@ScenicMH
Feature: Send a save debit normal case

@QuoteServices
Scenario Outline: Send a save debit request successfully	
Given User has Save Debit body 
	| Property             | Value                      |
	| SaveDebitRequestBody | SaveDebitRequestBodyScenicMH.json  |
	| QuoteRequestBody     | ValidQuoteForScenicMH.json |
	| ApiVersion           | V2                         |
	| ContextName          | ScenicMotorHome            |
	When User send Save Debit normal case
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |