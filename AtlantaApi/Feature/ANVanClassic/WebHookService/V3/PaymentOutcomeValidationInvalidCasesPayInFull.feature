#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC14,16,18,26->28,37,40,41,43,47,48,50

@AutonetVan
Feature: PaymentOutcomeValidationInvalidCasesPayInFull V3
@WebhookServices
Scenario: Payment Outcome Validation Invalid Cases PayInFull
	Given I have wrapUp table
	| Property                   | Value                                              |
	| Uri                        |  /api/V2/payment/outcome/A\|AN\|Autonet%20Van\|GV\|VNET |
	| WebHookBody                | WebHookBodyAutonetVan.json                       |
	| QuoteRequestBody           | ValidQuoteAutonetVanSuccess.json                 |
	| PaymentRequestBody         | RegisterPaymentRequestBodyAutonetVan.json        |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyAutonetVan.json          |
	| SaveDebitRequestBody       | SaveDebitRequestBodyAutonetVan.json              |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyAutonetVan.json        |
	| ApiVersion                 | V3                                                 |
	| ContextName                | AutonetVan                                       |
	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1               | Value         | StatusCode | Messages                |
		| AmountPaid           |               | 200        | /pc/error-technical?    |
		| AmountPaid           | -20           | 200        | /pc/error-technical?    |
		| AmountPaid           | Test          | 200        | /pc/error-technical?    |
		| MerchantID           |               | 200        | /pc/error-technical?    |
		| NavigationStatus     | BACK          | 200        | /pc/quote-review?       |
		| NavigationStatus     | PAYMENT_ERROR | 200        | /pc/error-card-payment? |
		| NavigationStatus     | QUIT          | 200        | ?webref=                |
		| NavigationStatus     | TIMEOUT       | 200        | /pc/error-card-payment? |
		| PaymentStatus        | UNKNOWN       | 200        | /pc/error-card-payment? |
		| PaymentStatus        | CANCELLED     | 200        | /pc/error-card-payment  |
		| SessionID            |               | 200        | /pc/error-technical?    |
		| WebReference         |               | 200        | /pc/error-payment?      |
		| WebReference         | 123456789     | 200        | /pc/error-technical?    |
		| PaymentStatus        | missing       | 200        | /pc/error-technical?    |
		| PaymentStatus        | Test 123      | 200        | /pc/error-technical?    |
		| PaymentTransactionID | missing       | 200        | /pc/error-technical?    |
		| CardTypeCode         | missing       | 200        | /pc/error-technical?    |
		| CardTypeCode         | 5             | 200        | /pc/error-technical?    |
		| CardTypeCode         | 1             | 200        | /pc/error-technical?    |
		| CardFee              | test          | 200        | /pc/error-technical?    |
		| CardFee              | 10000000      | 200        | /pc/error-technical?    |
		| CardFee              | -200          | 200        | /pc/error-technical?    |
		| CardHolderName       | missing       | 200        | /pc/error-technical?    |
		| ExpiryMonth          | missing       | 200        | /pc/error-technical?    |
		| ExpiryMonth          | 13            | 200        | /pc/error-technical?    |
		| ExpiryYear           | missing       | 200        | /pc/error-technical?    |
		| ExpiryYear           | <CurrentYear  | 200        | /pc/error-technical?    |
		| IIN                  | Test          | 200        | /pc/error-technical?    |
		| MaskedCardNumber     | missing       | 200        | /pc/error-technical?    |
		| StartMonth           | null          | 200        | /pc/error-technical?    |
		| StartMonth           | 13            | 200        | /pc/error-technical?    |
		| StartMonth           | test          | 200        | /pc/error-technical?    |
		| StartYear            | >CurrentYear  | 200        | /pc/error-technical?    |
		| StartYear            | test          | 200        | /pc/error-technical?    |
		| PaymentStatus        | DECLINED      | 200        | /pc/error-card-payment  |
# WebHook_TC24
@WebhookServices
Scenario: Payment Outcome Validation Invalid Cases
	Given I have wrapUp table
	| Property                   | Value                                               |
	| Uri                        |  /api/V2/payment/outcome/A\|AN\|Autonet%20Van\|GV\|VNET |
	| WebHookBody                | WebHookBodyNavigationStatusTIMEOUTAutonetVan.json |
	| QuoteRequestBody           | ValidQuoteAutonetVanSuccess.json                  |
	| PaymentRequestBody         | RegisterPaymentRequestBodyAutonetVan.json         |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyAutonetVan.json           |
	| SaveDebitRequestBody       | SaveDebitRequestBodyAutonetVan.json               |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyAutonetVan.json         |
	| ApiVersion                 | V3                                                 |
	| ContextName                | AutonetVan                                        |
	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1               | Value         | StatusCode | Messages                |
		| PaymentStatus        | UNKNOWN       | 200        | /pc/error-card-payment? |