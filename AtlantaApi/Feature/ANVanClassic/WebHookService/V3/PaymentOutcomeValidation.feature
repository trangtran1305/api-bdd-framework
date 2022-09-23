#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Webhook
#Test Case ID: WebHook_TC14,16,28,37,40,41,43,47,48,50,53,56,57,59,60,62,63,64,68,72

@AutonetVan
Feature: PaymentOutcomeValidation V3
@WebhookServices
Scenario: Payment Outcome Validation
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
		| Level1                  | Value      | StatusCode | Messages          |
		| AmountPaid              | 302        | 200        | /pc/confirmation? |
		| MerchantID              | 123        | 200        | /pc/confirmation? |
		| NavigationStatus        | COMPLETED  | 200        | /pc/confirmation? |
		| PaymentType             | ""         | 200        | /pc/confirmation? |
		| CardTypeCode            | 2          | 200        | /pc/confirmation? |
		| CardTypeValue           | missing    | 200        | /pc/confirmation? |
		| CardTypeValue           | Mastercard | 200        | /pc/confirmation? |
		| CardFee                 | missing    | 200        | /pc/confirmation? |
		| CardFee                 | 50000      | 200        | /pc/confirmation? |
		| CardHolderName          | Test       | 200        | /pc/confirmation? |
		| ExpiryMonth             | 1          | 200        | /pc/confirmation? |
		| ExpiryYear              | 2040       | 200        | /pc/confirmation? |
		| IIN                     | missing    | 200        | /pc/confirmation? |
		| IIN                     | 545454     | 200        | /pc/confirmation? |
		| IssueNumber             | 556        | 200        | /pc/confirmation? |
		| MaskedCardNumber        | 1234       | 200        | /pc/confirmation? |
		| PreviousTransactionDate | missing    | 200        | /pc/confirmation? |
		| PreviousTransactionId   | missing    | 200        | /pc/confirmation? |
		| StartMonth              | 2          | 200        | /pc/confirmation? |
		| StartYear               | 2019       | 200        | /pc/confirmation? |