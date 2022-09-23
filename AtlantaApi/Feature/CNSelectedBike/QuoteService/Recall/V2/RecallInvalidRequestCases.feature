#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@CNSBike
Feature: RecallInvalidRequestCases
	Check recall quote with abnormal cases (Invalid request cases)

@QuoteServices
Scenario Outline:  Send recall request with invalid endpoint or method		
	When User send request with invalid endpoint <Endpoint> or method <Method> with <ApiVersion> and <Context>
	Then The service response returns <StatusCode>
	Examples: 
	| Endpoint              | Method | StatusCode | ApiVersion | Context             |
	| /api/v2/quote/recall1 | POST   | 404        | V2         | CNSelectBikeContext |
	| /api/v2/quote/recall  | GET    | 404        | V2         | CNSelectBikeContext |