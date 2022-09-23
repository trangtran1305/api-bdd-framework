#Refer manual test cases: Atlanta_APi_System Test
#Sheet PrePurchase - TC105->TC107, TC129-TC131, TC108-109, TC113-123, TC126-127
#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC104
@CNSBike
Feature: Validate Save Payment Info Single Field In Case Call To CDL	
@QuoteServices
Scenario Outline: Validate Save Payment Info request with single fields
	Given User has Save Payment Info body 
	| Property                   | Value                           |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNSBike.json |
	| QuoteRequestBody           | ValidQuoteForPrepurchaseCNSBike.json   |
	| ApiVersion                 | V2                              |
	| ContextName                | CNSelectBikeContext             |
	When User send Save Payment Info request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1            | Value       | StatusCode | IsSuccess | Messages                                                                      |
	| TotalAmountTopay  | missing     | 400        | false     | TotalAmountToPay is incorrectly calculated                                    |
	| TotalAmountTopay  | null        | 400        | false     | Error converting value {null} to type 'System.Int64'. Path 'TotalAmountTopay' |
	| PaymentMethodType | abc$%#@ 555 | 400        | false     | PaymentMethodType is invalid.                                                 |
   