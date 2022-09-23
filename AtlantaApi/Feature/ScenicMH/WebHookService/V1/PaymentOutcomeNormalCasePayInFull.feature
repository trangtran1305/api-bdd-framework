@ScenicMH
Feature: Send a request with valid endpoint URL & method for ScenicMH

@WebhookServices
Scenario Outline: Send a request with valid endpoint URL & method for ScenicMH
	Given I have wrapUp table
	| Property                   | Value                                    |
	| Uri                        | /api/V1/payment/outcome/at//sw//sc//mh//SWIN  |
	| WebHookBody                | WebHookBodyScenicMH.json                 |
	| QuoteRequestBody           | ValidQuoteForScenicMHWebHook.json        |
	| PaymentRequestBody         | RegisterPaymentRequestBodyScenicMH.json  |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyScenicMH.json    |
	| SaveDebitRequestBody       | SaveDebitRequestBodyScenicMH.json        |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyScenicMH.json  |
	| SaveCardConsentBody        | SaveCardConsentBodyScenicMH.json         |
	| ApiVersion                 | V2                                       |
	| ContextName                | ScenicMotorHome                          |

	When User send a Register PayInFull Payment service
	And User send a WebHook service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages                                                           |
	| 200        | /mh/newbus/confirmation? |