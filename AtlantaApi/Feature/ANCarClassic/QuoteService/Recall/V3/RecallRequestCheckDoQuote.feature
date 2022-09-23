#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Recall quote
#Test Case ID: 

@ANCarClassic
Feature: Send a Recall request to check Do Quote
#
@QuoteService
Scenario Outline: Send a Recall request to check Do Quote with PolicyStartDate >= Today
	Given User has recall body 
	| Property          | Value                                       |
	| QuoteRequestBody  | ValidQuoteANCarClassicSuccessForRecall.json |
	| RecallRequestBody | RecallBodyANCarClassic.json                 |
	| ApiVersion        | V3                                          |
	| ContextName       | ANCarClassic                                |
	When User send recall service
	Then Recall response returns DoQuote value <Value>
	Examples: 
	  | Value |
	  | True  |

