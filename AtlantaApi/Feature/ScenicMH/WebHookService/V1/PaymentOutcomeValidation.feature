@ScenicMH
Feature: PaymentOutcomeValidation
@WebhookServices
Scenario: PaymentOutcomeValidation
	Given I have wrapUp table
	| Property                   | Value                                    |
	| Uri                        | /api/V1/payment/outcome/at//sw//sc//mh//SWIN |
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
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1                  | Value      | StatusCode | Messages                                                           |
		| AmountPaid              | 302        | 200        | /mh/newbus/confirmation? |
		| PaymentType             | ""         | 200        | /mh/newbus/confirmation? |
		| CardTypeCode            | 2          | 200        | /mh/newbus/confirmation? |
		| CardTypeValue           | missing    | 200        | /mh/newbus/confirmation? |
		| CardTypeValue           | Mastercard | 200        | /mh/newbus/confirmation? |
		| CardFee                 | missing    | 200        | /mh/newbus/confirmation? |
		| CardFee                 | 50000      | 200        | /mh/newbus/confirmation? |
		| CardHolderName          | Test       | 200        | /mh/newbus/confirmation? |
		| ExpiryMonth             | 1          | 200        | /mh/newbus/confirmation? |
		| ExpiryYear              | 2040       | 200        | /mh/newbus/confirmation? |
		| IIN                     | missing    | 200        | /mh/newbus/confirmation? |
		| IIN                     | 545454     | 200        | /mh/newbus/confirmation? |
		| IssueNumber             | 556        | 200        | /mh/newbus/confirmation? |
		| MaskedCardNumber        | 1234       | 200        | /mh/newbus/confirmation? |
		| PreviousTransactionDate | missing    | 200        | /mh/newbus/confirmation? |
		| PreviousTransactionId   | missing    | 200        | /mh/newbus/confirmation? |
		| StartMonth              | 2          | 200        | /mh/newbus/confirmation? |
		| StartYear               | 2019       | 200        | /mh/newbus/confirmation? |