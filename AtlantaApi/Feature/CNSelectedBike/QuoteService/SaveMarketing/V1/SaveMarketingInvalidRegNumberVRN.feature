#Reference Manual Test Cases:
#File: Atlanta_API_System Test.xlsx
#Sheet: Pre -purchase
#TCID: Prepurchase_TC89,90,94,95,96,98,99
@CNSBike
Feature: Validate Save Marketing Using Invalid ID and VRN
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
	Then Save Marketing response returns <StatusCode>
	Examples:
	| RegNumberId | RegNumberVNR    | StatusCode |                                                        
	| 1           | GX^#%$#         | 400        |                                        
