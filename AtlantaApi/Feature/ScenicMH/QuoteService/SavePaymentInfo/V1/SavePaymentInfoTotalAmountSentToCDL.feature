#Refer manual test cases: Atlanta_APi_System Test
#Sheet PrePurchase
#Refer file: Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC46-53
@ScenicMH
Feature: Validate Save Payment Info Single Field In Case Call To CDL using TotalAmount

@QuoteServices
Scenario Outline: Validate Save Payment Info With TotalAmount caculated sent to CDL
	Given User has prepurchase body 
	| Property               | Value                                   |
	| PrepurchaseRequestBody | SavePaymentInfoRequestBodyScenicMH.json |
	| QuoteRequestBody       | ValidQuoteForScenicMH.json              |
	| ApiVersion             | V2                                      |
	| ContextName            | ScenicMotorHome                         |

	When User sends save payment info request with PaymentMethod <PaymnetMethod> and OptionalExtras <OptionalExtras> and <TotalAmountToPay>
	Then Prepurchase response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| PaymnetMethod | OptionalExtras | TotalAmountToPay | StatusCode | IsSuccess | Messages               |
	| payinfull     | Yes            | Yes              | 200        | true      | Save data successfully |
	| payinfull     | No             | Yes              | 200        | true      | Save data successfully |
	| payinfull     | No             | No               | 200        | true      | Save data successfully |
	| payinfull     | yes            | No               | 200        | true      | Save data successfully |
	| Instalmnts    | Yes            | Yes              | 200        | true      | Save data successfully |
	| Instalmnts    | No             | Yes              | 200        | true      | Save data successfully |
	| Instalmnts    | No             | No               | 200        | true      | Save data successfully |
	| Instalmnts    | yes            | No               | 200        | true      | Save data successfully |