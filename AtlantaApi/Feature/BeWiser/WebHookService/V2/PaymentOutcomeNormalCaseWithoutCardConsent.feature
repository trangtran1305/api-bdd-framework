#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC79

@BeWiser
Feature: Send a request Webhook normal case withour card consent

@WebhookServices
Scenario Outline: Send a Webhook request normal case without card content
	Given I have wrapUp table
	| Property                   | Value                                              |
	| Uri                        | /api/V2/payment/outcome/A\|AN\|Bewiser%20Car\|PC\|SCAR |
	| WebHookBody                | WebHookBodyWithoutCardConsentBeWiser.json          |
	| QuoteRequestBody           | ValidQuoteBeWiserSuccess.json                      |
	| PaymentRequestBody         | RegisterPaymentRequestBodyBeWiser.json             |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyBeWiser.json               |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyBeWiser.json             |
	| SaveDebitRequestBody       | SaveDebitRequestBodyBeWiser.json                   |
	| ApiVersion                 | V3                                                 |
	| ContextName                | BeWiser                                            |

	When User send a Register PayInFull Payment service
	And User send a WebHook service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages         |
	| 200        | pc/confirmation? |