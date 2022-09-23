#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: API Partial Quote
#Test Case ID: Quote_TC03

@BeWiser
Feature:Get Partial Quote Normal Case

@QuoteServices
Scenario Outline: ValiDate partial quote API normal case
	Given The customer has 
	| Name         | Value1                             |
	| Url          | PartialQuote                       |
	| ApiVersion   | V3                                 |
	| Context      | BeWiser                       |
	| JsonBodyFile | ValidQuoteBeWiserSuccess.json |
	When The customer call quote API normal case
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
		 | StatusCode | IsSuccess | Message                          |
		 | 200        | TRUE      | Store partial quote successfully |
