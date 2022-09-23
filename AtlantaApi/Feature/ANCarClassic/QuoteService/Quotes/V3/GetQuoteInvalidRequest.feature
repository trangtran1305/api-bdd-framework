#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: API Quote
#Test Case ID: Quote_TC05, Quote_TC06

@ANCarClassic
Feature: Get Quote invalid request cases

@QuoteServices
Scenario Outline: Get Quote with invalid request param
	Given The customer has 
	| Name         | Value1                             |
	| Url          | QuoteApi                           |
	| ApiVersion   | V3                                 |
	| Context      | ContextInvalid                     |
	| JsonBodyFile | ValidQuoteANCarClassicSuccess.json |
	When The customer call quote API validate <Endpoint> and <Method>
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| Endpoint              | Method | IsSuccess | StatusCode | Message  |
	| /api/v3/quote/quotes  | GET    | False     | 404        | NotFound |
	| /api/v3/quote/quotes1 | POST   | False     | 404        | NotFound |