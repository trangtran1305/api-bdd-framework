#Reference Manual Test Cases:
#File: Atlanta_API_System Test.xlsx
#Sheet: Pre -purchase
#TCID: Prepurchase_TC52, 53, 56, 58, 60, 57, 55, 61
@SafeGuardMH
Feature: Validate Save Marketing Using Reg Number infos
@QuoteServices
Scenario Outline: Validate Save Marketing request with ID/VRN infos
	Given User has prepurchase body for SG
	| Property               | Value                             |
	| PrepurchaseRequestBody | SaveMarketingInvalidRegInfos.json |
	| QuoteRequestBody       | ValidQuoteForSGGetQuote1.json     |
	| ApiVersionPrepurchase  | V1                                |
	| ApiVersionQuote        | V2                                |
	| ContextName            | SafeGuardMH                       |
	When user sends SG request using <RegNumberId> and <RegNumberVNR>
	When User sends SG prepurchase requests
	Then Prepurchase SG response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| RegNumberId | RegNumberVNR    | StatusCode | IsSuccess | Messages           |
	| 5           | GX08NNT         | 400        | false     | RegNumbers - Id must be 1 ~ 4 is invalid.                             |
	|             | GX08NNT         | 400        | false     | RegNumbers - Id is required.                                          |
	| 1           |                 | 400        | false     | RegNumbers - Vrn is required.                                         |
	| 1           | GBBD5I SM     R | 400        | false     | RegNumber - Vrn - GBBD5ISMR cannot be over 8 characters.              |
	| 1           | Q874 9FP        | 400        | false     | RegNumbers - Vrn with Q registration plate - Q8749FP is unacceptable. |                                              
	| 1           | GX^#%$#         | 400        | false	 | RegNumbers - Vrn - GX^#%$# is incorrect. |                                              
	| 4           | GX08NNT         | 200        | true		 | Save data successfully |                                              
	| 1           | GX08NNT         | 200        | true		 | Save data successfully |