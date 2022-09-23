#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: API Quote
#Test Case ID: Quote_TC05, Quote_TC06

@BeWiser
Feature: Get Partial Quote invalid request cases

@QuoteServices
Scenario Outline: Get Partial Quote with invalid request param
	Given The customer has 
	| Name         | Value1                             |
	| Url          | PartialQuote                       |
	| ApiVersion   | V3                                 |
	| Context      | ContextInvalid                     |
	| JsonBodyFile | ValidQuoteBeWiserSuccess.json |
	When The customer call quote API validate <Endpoint> and <Method>
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| Endpoint                           | Method | IsSuccess | StatusCode | Message  |
	| /api/v2/quote/store-partial-quote  | GET    | False     | 404        | NotFound |
	| /api/v2/quote/store-partial-quote1 | POST   | False     | 404        | NotFound |