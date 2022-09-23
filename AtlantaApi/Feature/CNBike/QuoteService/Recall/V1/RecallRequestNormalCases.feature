#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: Recall_TC04

@CNBike
Feature: Send a Recall request normal case

@QuoteServices
Scenario Outline:  Send a request with valid endpoint URL & method	
	Given User has recall body 
	| Property          | Value                          |
	| QuoteRequestBody  | ValidQuoteForRecallCNBike.json |
	| RecallRequestBody | RecallBodyCNBike.json                |
	| ApiVersion        | V1                             |
	| ContextName       | CNBikeContext                  |
	When User send recall service
	Then Recall response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages               |
	  | 200        | Get quote successfully |