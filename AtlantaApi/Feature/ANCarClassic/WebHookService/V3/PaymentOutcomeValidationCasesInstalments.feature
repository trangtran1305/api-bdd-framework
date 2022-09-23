#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC19,25

@ANCarClassic
Feature: PaymentOutcomeValidationCasesInstalments V3
@WebhookServices
Scenario: Payment Outcome Validation Cases Instalments 19
	Given I have wrapUp table
	| Property                   | Value                                                  |
	| Uri                        | /api/V2/payment/outcome/A\|AN\|Autonet%20Car\|PC\|SCAR |
	| WebHookBody                | WebHookBodyANCarClassic.json                           |
	| QuoteRequestBody           | ValidQuoteANCarClassicSuccess.json                     |
	| PaymentRequestBody         | RegisterPaymentRequestBodyANCarClassic.json            |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyANCarClassic.json              |
	| SaveDebitRequestBody       | SaveDebitRequestBodyANCarClassic.json                  |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyInstalmntsANCarClassic.json  |
	| ApiVersion                 | V3                                                     |
	| ContextName                | ANCarClassic                                           |
	When User send a Register Instalments Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1               | Value         | StatusCode | Messages                |
		| NavigationStatus     | BACK          | 200        | /pc/direct-debit?       |

@webhook
Scenario: Payment Outcome Validation Invalid Cases Instalments 25
	Given I have wrapUp table
	| Property                   | Value                                                 |
	| Uri                        | /api/V2/payment/outcome/A\|AN\|Autonet%20Car\|PC\|SCAR    |
	| WebHookBody                | WebHookBodyNavigationStatusTIMEOUTANCarClassic.json   |
	| QuoteRequestBody           | ValidQuoteANCarClassicSuccess.json                    |
	| PaymentRequestBody         | RegisterPaymentRequestBodyANCarClassic.json           |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyANCarClassic.json             |
	| SaveDebitRequestBody       | SaveDebitRequestBodyANCarClassic.json                 |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyInstalmntsANCarClassic.json |
	| ApiVersion                 | V3                                                    |
	| ContextName                | ANCarClassic                                          |
	When User send a Register Instalments Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1               | Value         | StatusCode | Messages                |
		| PaymentStatus        | UNKNOWN       | 200        | /pc/error-card-payment? |