#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@CNSBike
Feature: Send a Recall request normal case

@QuoteServices
Scenario Outline:  Send a request with valid endpoint URL & method	
	Given User has recall body 
	| Property          | Value                    |
	| QuoteRequestBody  | ValidQuoteForRecallCNSBike.json |
	| RecallRequestBody | RecallBodyCNSBike.json          |
	| ApiVersion        | V2                       |
	| ContextName       | CNSelectBikeContext      |
	When User send recall service
	Then Recall response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages               |
	  | 200        | Get quote successfully |