#Refer manual test cases: Atlanta_APi_System Test
#Sheet PrePurchase - TC105->TC107, TC129-TC131, TC108-109, TC113-123, TC126-127
#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC104
@SafeGuardMH
Feature: Validate Save Payment Info Single Field	
@QuoteServices
Scenario Outline: Validate Save Payment Info request with single fields
	Given User has Save Payment Info body for SG
	| Property                   | Value                                     |
	| SavePaymentInfoRequestBody | SavePaymentInfoSGquestBodyInstalmnts.json |
	| ApiVersion                 | V1                                        |
	| ContextName                | SafeGuardMH                               |
	And Quote Service version "V2" and Json file is "ValidQuoteForSGGetQuote1.json"                      
	When User send SG Save Payment Info request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then SG Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1            | Value                                                          | StatusCode | IsSuccess | Messages                                                                      |
	| SessionId         | null                                                           | 400        | false     | SessionId is required.                                                        |
	| SessionId         | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvv | 400        | false     | SessionId is invalid.                                                         |
	| OptionalExtrasx   | null                                                           | 200        | true      | Save data successfully                                                        |
	| PaymentMethodType | null                                                           | 400        | false     | PaymentMethodType is required.                                                |
	| PaymentMethodType | abc                                                            | 400        | false     | PaymentMethodType is invalid.                                                 |
	| PaymentMethodType | abc$%#@ 555                                                    | 400        | false     | PaymentMethodType is invalid.                                                 |
	| PaymentMethodType | PayInFull                                                      | 200        | true      | Save data successfully                                                        |
	| TotalAmountTopay  | missing                                                        | 200        | true      | Save data successfully                                                        |
	| TotalAmountTopay  | null                                                           | 400        | false     | Error converting value {null} to type 'System.Int64'. Path 'TotalAmountTopay' |
	| PaymentMethodType | abc$%#@ 555                                                    | 400        | false     | PaymentMethodType is invalid.                                                 |

   