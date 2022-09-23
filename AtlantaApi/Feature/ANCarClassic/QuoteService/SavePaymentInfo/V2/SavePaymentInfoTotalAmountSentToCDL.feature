#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC18->25
@ANCarClassic
Feature: Validate Save Payment Info Single Field In Case Call To CDL using TotalAmount

@QuoteServices
Scenario Outline: Validate Save Payment Info With TotalAmount caculated sent to CDL
	Given User has prepurchase body 
	| Property               | Value                                                    |
	| PrepurchaseRequestBody | SavePaymentInfoRequestBodyPaymentMethodANCarClassic.json |
	| QuoteRequestBody       | ValidQuoteANCarClassicSuccess.json                       |
	| ApiVersion             | V3                                                       |
	| ContextName            | ANCarClassic                                             |

	When User sends save payment info request with PaymentMethod <PaymnetMethod> and OptionalExtras <OptionalExtras> and <TotalAmountToPay>
	Then Prepurchase response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| PaymnetMethod | OptionalExtras | TotalAmountToPay |  StatusCode | IsSuccess | Messages                                   |
	| payinfull     | Yes            | Yes              |  200        | true      | Save data successfully                     |
	| payinfull     | No             | Yes              |  200        | true      | Save data successfully                     |
	| payinfull     | No             | No               |  400        | false     | TotalAmountToPay is incorrectly calculated |
	| payinfull     | yes            | No               |  400        | false     | TotalAmountToPay is incorrectly calculated |
	| Instalmnts    | Yes            | Yes              |  200        | true      | Save data successfully                     |
	| Instalmnts    | No             | Yes              |  200        | true      | Save data successfully                     |
	| Instalmnts    | No             | No               |  400        | false     | TotalAmountToPay is incorrectly calculated |
	| Instalmnts    | yes            | No               |  400        | false     | TotalAmountToPay is incorrectly calculated |