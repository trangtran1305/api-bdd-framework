@ScenicMH
Feature: Send a request with valid endpoint URL & method for ScenicMH Instalments

@WebhookServices
Scenario Outline: Send a request with valid endpoint URL & method for ScenicMH
	Given I have wrapUp table
	| Property                   | Value                                             |
	| Uri                        | /api/V1/payment/outcome/at//sw//sc//mh//SWIN          |
	| WebHookBody                | WebHookBodyScenicMH.json                          |
	| QuoteRequestBody           | ValidQuoteForScenicMHWebHook.json                 |
	| PaymentRequestBody         | RegisterPaymentRequestBodyScenicMH.json           |
	| SaveDebitRequestBody       | SaveDebitRequestBodyScenicMH.json                 |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyScenicMH.json             |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyInstalmntsScenicMH.json |
	| SaveCardConsentBody        | SaveCardConsentBodyScenicMH.json                  |
	| ApiVersion                 | V2                                                |
	| ContextName                | ScenicMotorHome                                   |

	When User send a Register Instalments Payment service
	And User send a WebHook service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages                 |
	| 200        | /mh/newbus/confirmation? |