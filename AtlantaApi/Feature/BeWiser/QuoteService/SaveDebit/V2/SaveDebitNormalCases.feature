#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC81

@BeWiser
Feature: Send a save debit normal case

@QuoteServices
Scenario Outline: Send a save debit request successfully	
Given User has Save Debit body 
	| Property             | Value                                 |
	| SaveDebitRequestBody | SaveDebitRequestBodyBeWiser.json |
	| QuoteRequestBody     | ValidQuoteBeWiserSuccess.json    |
	| ApiVersion           | V3                                    |
	| ContextName          | BeWiser                          |
	When User send Save Debit normal case
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |