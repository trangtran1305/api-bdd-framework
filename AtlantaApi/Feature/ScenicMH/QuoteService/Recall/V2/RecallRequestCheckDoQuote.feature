#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@ScenicMH
Feature: Send a Recall request to check Do Quote
#
@QuoteServices
Scenario Outline: Send a Recall request to check Do Quote with PolicyStartDate >= Today
	Given User has recall body 
	| Property          | Value                            |
	| QuoteRequestBody  | ValidQuoteForRecallScenicMH.json |
	| RecallRequestBody | RecallBodyScenicMH.json          |
	| ApiVersion        | V2                               |
	| ContextName       | ScenicMotorHome                  |
	When User send recall service
	Then Recall response returns DoQuote value <Value>
	Examples: 
	  | Value |
	  | True  |

