#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC69

@ANCarClassic
Feature: PaymentOutcomeValidationMissingStartMonthAndStartYear V3
@WebhookServices
Scenario: PaymentOutcomeValidation
	Given I have wrapUp table
	| Property                   | Value                                              |
	| Uri                        | /api/V2/payment/outcome/A\|AN\|Autonet%20Car\|PC\|SCAR |
	| WebHookBody                | WebHookBodyMissingStartMonthANCarClassic.json       |
	| QuoteRequestBody           | ValidQuoteANCarClassicSuccess.json                 |
	| PaymentRequestBody         | RegisterPaymentRequestBodyANCarClassic.json        |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyANCarClassic.json          |
	| SaveDebitRequestBody       | SaveDebitRequestBodyANCarClassic.json              |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyANCarClassic.json        |
	| ApiVersion                 | V3                                                 |
	| ContextName                | ANCarClassic                                       |

	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1    | Value   | StatusCode | Messages         |
		| StartYear | missing | 200        | pc/confirmation? |
