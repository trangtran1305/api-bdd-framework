@CNSBike
Feature: PaymentOutcomeValidation
@WebhookServices
Scenario: PaymentOutcomeValidation
	Given I have wrapUp table
	| Property                   | Value                                         |
	| Uri                        | /api/V2/payment/outcome/AT//CN//CNS//MC//6258 |
	| WebHookBody                | WebHookBodyCNSBike.json                       |
	| QuoteRequestBody           | ValidQuoteForRegisterPaymentCNSBike.json      |
	| PaymentRequestBody         | RegisterPaymentRequestBodyCNSBike.json        |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyCNSBike.json          |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNSBike.json        |
	| SaveDebitRequestBody       | SaveDebitRequestBodyCNSBike.json              |
	| ApiVersion                 | V2                                            |
	| ContextName                | CNSelectBikeContext                           |

	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1                  | Value      | StatusCode | Messages                                                      |
		| AmountPaid              | 302        | 200        | /mc/confirmation? |
		| PaymentType             | ""         | 200        | /mc/confirmation? |
		| CardTypeCode            | 2          | 200        | /mc/confirmation? |
		| CardTypeValue           | missing    | 200        | /mc/confirmation? |
		| CardTypeValue           | Mastercard | 200        | /mc/confirmation? |
		| CardFee                 | missing    | 200        | /mc/confirmation? |
		| CardFee                 | 50000      | 200        | /mc/confirmation? |
		| CardHolderName          | Test       | 200        | /mc/confirmation? |
		| ExpiryMonth             | 1          | 200        | /mc/confirmation? |
		| ExpiryYear              | 2040       | 200        | /mc/confirmation? |
		| IIN                     | missing    | 200        | /mc/confirmation? |
		| IIN                     | 545454     | 200        | /mc/confirmation? |
		| IssueNumber             | 556        | 200        | /mc/confirmation? |
		| MaskedCardNumber        | 1234       | 200        | /mc/confirmation? |
		| PreviousTransactionDate | missing    | 200        | /mc/confirmation? |
		| PreviousTransactionId   | missing    | 200        | /mc/confirmation? |
		| StartMonth              | 2          | 200        | /mc/confirmation? |
		| StartYear               | 2019       | 200        | /mc/confirmation? |