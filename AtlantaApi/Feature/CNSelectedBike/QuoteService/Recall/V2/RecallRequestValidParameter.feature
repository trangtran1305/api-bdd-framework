#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

Feature: Recall a quote when webReference is valid, Postcode & DateOfBirth are valid and matched the quote of requested webReference

@QuoteServices
Scenario Outline: Recall a quote when webReference is valid, Postcode & DateOfBirth are valid and matched the quote of requested webReference
	Given User has recall body 
	| Property          | Value                    |
	| QuoteRequestBody  | ValidQuoteForRecall.json |
	| RecallRequestBody | RecallBody.json          |
	| ApiVersion        | V2                       |
	| ContextName       | CNSelectBikeContext      |
	When User send recall service
	Then Recall response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages               |
	  | 200        | Get quote successfully |