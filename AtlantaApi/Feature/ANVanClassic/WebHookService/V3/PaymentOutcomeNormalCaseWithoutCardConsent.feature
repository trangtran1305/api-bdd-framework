#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC79

@AutonetVan
Feature: Send a request Webhook normal case withour card consent V3

@WebhookServices
Scenario Outline: Send a Webhook request normal case without card content
	Given I have wrapUp table
	| Property                   | Value                                              |
	| Uri                        |  /api/V2/payment/outcome/A\|AN\|Autonet%20Van\|GV\|VNET |
	| WebHookBody                | WebHookBodyWithoutCardConsentAutonetVan.json     |
	| QuoteRequestBody           | ValidQuoteAutonetVanSuccess.json                 |
	| PaymentRequestBody         | RegisterPaymentRequestBodyAutonetVan.json        |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyAutonetVan.json          |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyAutonetVan.json        |
	| SaveDebitRequestBody       | SaveDebitRequestBodyAutonetVan.json              |
	| ApiVersion                 | V3                                                 |
	| ContextName                | AutonetVan                                       |

	When User send a Register PayInFull Payment service
	And User send a WebHook service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages         |
	| 200        | pc/confirmation? |