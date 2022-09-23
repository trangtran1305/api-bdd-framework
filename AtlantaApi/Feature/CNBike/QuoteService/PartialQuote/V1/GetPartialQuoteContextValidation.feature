#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: API Quote
#Test Case ID: Quote_TC01, Quote_TC02

@CNBike
Feature: Get quote context validation

@QuoteServices
Scenario Outline: ValiDate quote API invalid context
	Given The customer has 
	| Name         | Value1                   |
	| Url          | PartialQuote             |
	| ApiVersion   | V1                       |
	| Context      | ContextInvalid           |
	| JsonBodyFile | ValidQuoteForCNBike.json |
	When The customer call quote API normal case
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
		 | StatusCode | IsSuccess | Message						|
		 | 400        | False     | Tenant is not supported		|

@QuoteServices
Scenario Outline: ValiDate quote API missing context
	Given The customer has 
	| Name         | Value1                   |
	| Url          | PartialQuote             |
	| ApiVersion   | V1                       |
	| Context      | CNBikeContext            |
	| JsonBodyFile | ValidQuoteForCNBike.json |
	When The customer call quote API missing context
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
		 | StatusCode | IsSuccess | Message						|
		 | 400        | False     | Tenant is not supported		|
