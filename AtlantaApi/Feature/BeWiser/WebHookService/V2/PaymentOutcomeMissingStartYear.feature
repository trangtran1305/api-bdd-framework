#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC69

@BeWiser
Feature: PaymentOutcomeValidationMissingStartMonthAndStartYear
@WebhookServices
Scenario: PaymentOutcomeValidation
	Given I have wrapUp table
	| Property                   | Value                                              |
	| Uri                        | /api/V2/payment/outcome/A\|AN\|Bewiser%20Car\|PC\|SCAR |
	| WebHookBody                | WebHookBodyMissingStartMonthBeWiser.json           |
	| QuoteRequestBody           | ValidQuoteBeWiserSuccess.json                      |
	| PaymentRequestBody         | RegisterPaymentRequestBodyBeWiser.json             |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyBeWiser.json               |
	| SaveDebitRequestBody       | SaveDebitRequestBodyBeWiser.json                   |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyBeWiser.json             |
	| ApiVersion                 | V3                                                 |
	| ContextName                | BeWiser                                            |

	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1    | Value   | StatusCode | Messages         |
		| StartYear | missing | 200        | pc/confirmation? |
