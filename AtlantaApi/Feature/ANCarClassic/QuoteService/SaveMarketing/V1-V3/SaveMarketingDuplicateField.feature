#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC54, 59
@ANCarClassic
Feature: Validate Save Marketing Duplicate Field	
@QuoteServices
Scenario Outline: Validate Save Marketing request with single fields
	Given User has Save Marketing body
	| Property                 | Value                                     |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyANCarClassic.json |
	| QuoteRequestBody         | ValidQuoteANCarClassicSuccess.json        |
	| ApiVersion               | V3                                        |
	| ContextName              | ANCarClassic                              |
	When User send Save Marketing request
	| Level1   | Level2   | Value   |
	| <Level1> | <Level2> | <Value> |
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1    | Level2 | Value                                | StatusCode | IsSuccess | Messages                              |
	| RegNumber | Id     | File: SaveMarketingDuplicateId.json  | 400        | false     | RegNumbers - Id has duplicate items.  |
	| RegNumber | VRN    | File: SaveMarketingDuplicateVRN.json | 400        | false     | RegNumbers - Vrn has duplicate items. |
	