#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@ScenicMH
Feature: Send a Recall request normal case

@QuoteServices
Scenario Outline:  Send a request with valid endpoint URL & method	
	Given User has recall body 
	| Property          | Value                            |
	| QuoteRequestBody  | ValidQuoteForRecallScenicMH.json |
	| RecallRequestBody | RecallBodyScenicMH.json          |
	| ApiVersion        | V2                               |
	| ContextName       | ScenicMotorHome                  |
	When User send recall service
	Then Recall response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                  |
	  | 200        | Recall quote successfully |