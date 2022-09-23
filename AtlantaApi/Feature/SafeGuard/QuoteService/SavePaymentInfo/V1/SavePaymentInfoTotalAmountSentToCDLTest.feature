#Refer manual test cases: Atlanta_APi_System Test
#Sheet PrePurchase
#Refer file: Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC46-53
@SafeGuardMH
Feature: Validate Save Payment Info Single Field In Case Call To CDL using TotalAmount Test

@QuoteServices
Scenario Outline: Validate Save Payment Info With TotalAmount caculated sent to CDL
	Given User has prepurchase body for SG
	| Property               | Value                                   |
	| PrepurchaseRequestBody | SavePaymentInfoRequestBodyScenicMH.json |
	| QuoteRequestBody       | ValidQuoteForSGGetQuote1.json           |
	| ApiVersionPrepurchase  | V1                                      |
	| ApiVersionQuote        | V2                                      |
	| ContextName            | SafeGuardMH                             |                        

	When User sends SG save payment info request with PaymentMethod <PaymnetMethod> and OptionalExtras <OptionalExtras> and <TotalAmountToPay>
	Then Prepurchase SG response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| PaymnetMethod | OptionalExtras | TotalAmountToPay |  StatusCode | IsSuccess | Messages                                   |
	| payinfull     | Yes            | Yes              |  200        | true      | Save data successfully                     |
