#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC54, 59
@ScenicMH
Feature: Validate Save Marketing Duplicate Field	
@QuoteServices
Scenario Outline: Validate Save Marketing Duplicate Field
	Given User has Save Marketing body
	| Property                 | Value                         |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyScenicMH.json |
	| QuoteRequestBody         | ValidQuoteForScenicMH.json    |
	| ApiVersion               | V2                            |
	| ContextName              | ScenicMotorHome               |
	When User send Save Marketing request
	| Level1   | Level2   | Value   |
	| <Level1> | <Level2> | <Value> |
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1    | Level2 | Value                                | StatusCode | IsSuccess | Messages                              |
	| RegNumber | Id     | File: SaveMarketingDuplicateId.json  | 400        | false     | RegNumbers - Id has duplicate items.  |
	| RegNumber | VRN    | File: SaveMarketingDuplicateVRN.json | 400        | false     | RegNumbers - Vrn has duplicate items. |
	