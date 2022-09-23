#WebHook_TC28,37,41,43,47,48,50,53,57,59,60,62,64
@CNBike
Feature: PaymentOutcomeValidation
@WebhookServices
Scenario: PaymentOutcomeValidation
	Given I have wrapUp table
	| Property                   | Value                                                                         |
	| Uri                        | /api/V1/payment/outcome/atlantaBrandCode//Carolenash//Carolenash//motorbike//6270 |
	| WebHookBody                | WebHookBodyCNBike.json                                                        |
	| QuoteRequestBody           | ValidQuoteForRegisterPaymentCNBike.json                                       |
	| PaymentRequestBody         | RegisterPaymentRequestBodyCNBike.json                                         |
	| SaveDebitRequestBody       | SaveDebitRequestBodyCNBike.json                                               |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyCNBike.json                                           |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNBike.json                                         |
	| ApiVersion                 | V1                                                                            |
	| ContextName                | CNBikeContext                                                                 |

	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Message>
	Examples: 
		| Level1                  | Value      | StatusCode | Message          |
		| AmountPaid              | 302        | 200        | /mc/confirmation |
		| PaymentType             | ""         | 200        | /mc/confirmation |
		| CardTypeCode            | 2          | 200        | /mc/confirmation |
		| CardTypeValue           | missing    | 200        | /mc/confirmation |
		| CardTypeValue           | Mastercard | 200        | /mc/confirmation |
		| CardFee                 | missing    | 200        | /mc/confirmation |
		| CardFee                 | 50000      | 200        | /mc/confirmation |
		| CardHolderName          | Test       | 200        | /mc/confirmation |
		| ExpiryMonth             | 1          | 200        | /mc/confirmation |
		| ExpiryYear              | 2040       | 200        | /mc/confirmation |
		| IIN                     | missing    | 200        | /mc/confirmation |
		| IIN                     | 545454     | 200        | /mc/confirmation |
		| IssueNumber             | 556        | 200        | /mc/confirmation |
		| MaskedCardNumber        | 1234       | 200        | /mc/confirmation |
		| PreviousTransactionDate | missing    | 200        | /mc/confirmation |
		| PreviousTransactionId   | missing    | 200        | /mc/confirmation |
		| StartMonth              | 2          | 200        | /mc/confirmation |
		| StartYear               | 2019       | 200        | /mc/confirmation |

@WebhookServices
Scenario: PaymentOutcomeValidationsStartYear
	Given I have wrapUp table
	| Property                   | Value                                                                         |
	| Uri                        | /api/V1/payment/outcome/atlantaBrandCode//Carolenash//Carolenash//motorbike//6270 |
	| WebHookBody                | WebHookBodyMissingStartMonthCNBike.json                                       |
	| QuoteRequestBody           | ValidQuoteForRegisterPaymentCNBike.json                                       |
	| PaymentRequestBody         | RegisterPaymentRequestBodyCNBike.json                                         |
	| SaveDebitRequestBody       | SaveDebitRequestBodyCNBike.json                                               |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyCNBike.json                                           |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNBike.json                                         |
	| ApiVersion                 | V1                                                                            |
	| ContextName                | CNBikeContext                                                                 |

	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Message>
	Examples: 
		| Level1    | Value   | StatusCode | Message          |
		| StartYear | missing | 200        | /mc/confirmation |