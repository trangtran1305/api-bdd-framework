#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC52, 53, 56->58, 60

@ANCarClassic
Feature: Save Marketing RegNumber Validation
@QuoteServices
	
	Scenario Outline: Validate Save Marketing request with single fields part 1
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
	| Level1     | Level2 | Value         | StatusCode | IsSuccess | Messages                                                              |
	| RegNumbers | Id     | null          | 400        | false     | RegNumbers - Id is required.                                          |
	| RegNumbers | Id     | 5             | 400        | false     | RegNumbers - Id must be 1 ~ 4 is invalid.                             |
	| RegNumbers | VRN    | null          | 400        | false     | RegNumbers - Vrn is required.                                         |
	| RegNumbers | VRN    | false         | 200        | true      | Save data successfully                                                |
	| RegNumbers | VRN    | Q874 9FP      | 400        | false     | RegNumbers - Vrn with Q registration plate - Q8749FP is unacceptable. |
	| RegNumbers | VRN    | GX08NNT890123 | 400        | false     | RegNumber - Vrn - GX08NNT890123 cannot be over 8 characters           |
	