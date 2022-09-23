#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC79

@ANCarClassic
Feature: Send a request Webhook normal case withour card consent V3

@WebhookServices
Scenario Outline: Send a Webhook request normal case without card content
	Given I have wrapUp table
	| Property                   | Value                                              |
	| Uri                        | /api/V2/payment/outcome/A\|AN\|Autonet%20Car\|PC\|SCAR |
	| WebHookBody                | WebHookBodyWithoutCardConsentANCarClassic.json     |
	| QuoteRequestBody           | ValidQuoteANCarClassicSuccess.json                 |
	| PaymentRequestBody         | RegisterPaymentRequestBodyANCarClassic.json        |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyANCarClassic.json          |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyANCarClassic.json        |
	| SaveDebitRequestBody       | SaveDebitRequestBodyANCarClassic.json              |
	| ApiVersion                 | V3                                                 |
	| ContextName                | ANCarClassic                                       |

	When User send a Register PayInFull Payment service
	And User send a WebHook service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages         |
	| 200        | pc/confirmation? |