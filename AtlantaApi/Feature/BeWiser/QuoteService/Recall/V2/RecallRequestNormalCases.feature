#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Recall quote
#Test Case ID: 

@BeWiser
Feature: Send a Recall request normal case

@QuoteServices
Scenario Outline:  Send a request with valid endpoint URL & method	
	Given User has recall body 
	| Property          | Value                                  |
	| QuoteRequestBody  | ValidQuoteBeWiserSuccessForRecall.json |
	| RecallRequestBody | RecallBodyBeWiser.json                 |
	| ApiVersion        | V3                                     |
	| ContextName       | BeWiser                                |
	When User send recall service
	Then Recall response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages               |
	  | 200        | Get quote successfully |