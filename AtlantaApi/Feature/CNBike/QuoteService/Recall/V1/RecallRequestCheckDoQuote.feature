#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@CNBike
Feature: Send a Recall request to check Do Quote
#
@QuoteServices
Scenario Outline: Send a Recall request to check Do Quote with PolicyStartDate >= Today
	Given User has recall body 
	| Property          | Value                          |
	| QuoteRequestBody  | ValidQuoteForRecallCNBike.json |
	| RecallRequestBody | RecallBodyCNBike.json                |
	| ApiVersion        | V1                             |
	| ContextName       | CNBikeContext                  |
	When User send recall service
	Then Recall response returns DoQuote value <Value>
	Examples: 
	  | Value |
	  | True  |

