#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

Feature: Send a Recall request to check Do Quote False

@QuoteServices
Scenario Outline: Send a Recall request to check Do Quote PolicyStartDate < Today
	Given User has recall body 
	| Property          | Value                    |
	| QuoteRequestBody  | ValidQuoteForRecall.json |
	| RecallRequestBody | RecallBody.json          |
	| ApiVersion        | V2                       |
	| ContextName       | CNSelectBikeContext      |
	Then Check Data in Tracking Database <CompanyCode> <PolicyType>
	Examples: 
	| CompanyCode | PolicyType |
	| CN          | MC         |
