#Reference Manual Test Cases:
#File: Atlanta_API_System Test.xlsx
#Sheet: Pre -purchase
#TCID: Prepurchase_TC89,90,94,95,96,98,99
@CNSBike
Feature: Validate Save Marketing Using Invalid ID and VRN infos
@QuoteServices
Scenario Outline: Validate Save Marketing request with Invalid ID/VRN infos
	Given User has prepurchase body
	| Property               | Value                             |
	| PrepurchaseRequestBody | SaveMarketingInvalidRegInfosCNSBike.json |
	| QuoteRequestBody       | ValidQuoteForPrepurchaseCNSBike.json     |
	| ApiVersion             | V2                                |
	| ContextName            | CNSelectBikeContext               |
	When user sends request using <RegNumberId> and <RegNumberVNR>
	When User sends prepurchase requests
	Then Prepurchase response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| RegNumberId | RegNumberVNR    | StatusCode | IsSuccess | Messages                                                              |
	| 5           | GX08NNT         | 400        | false     | RegNumbers - Id must be 1 ~ 4 is invalid.                             |
	|             | GX08NNT         | 400        | false     | RegNumbers - Id is required.                                          |
	| 1           |                 | 400        | false     | RegNumbers - Vrn is required.                                         |
	| 1           | GBBD5I SM     R | 400        | false     | RegNumber - Vrn - GBBD5ISMR cannot be over 8 characters.              |
	| 1           | Q874 9FP        | 400        | false     | RegNumbers - Vrn with Q registration plate - Q8749FP is unacceptable. |
	| 1           | GX08NNT890123   | 400        | false     | RegNumber - Vrn - GX08NNT890123 cannot be over 8 characters.          |