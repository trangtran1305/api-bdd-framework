#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC90

@ANCarClassic
Feature: Send a save debit with old sessionId

@QuoteServices
Scenario Outline: Send a save debit request successfully with old sessionId	
Given User has Save Debit body 
	| Property             | Value                                 |
	| SaveDebitRequestBody | SaveDebitRequestBodyANCarClassic.json |
	| QuoteRequestBody     | ValidQuoteANCarClassicSuccess.json    |
	| ApiVersion           | V3                                    |
	| ContextName          | ANCarClassic                          |
	When User send Save Debit with old sessionId
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |