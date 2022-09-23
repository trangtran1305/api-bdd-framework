#TCID: WebHook_TC69

@CNSBike
Feature: PaymentOutcomeValidationMissingStartMonthAndStartYear
@WebhookServices
Scenario: PaymentOutcomeValidation
	Given I have wrapUp table
	| Property                   | Value                                         |
	| Uri                        | /api/V2/payment/outcome/AT//CN//CNS//MC//6258 |
	| WebHookBody                | WebHookBodyMissingStartMonthCNSBike.json      |
	| QuoteRequestBody           | ValidQuoteForRegisterPaymentCNSBike.json      |
	| PaymentRequestBody         | RegisterPaymentRequestBodyCNSBike.json        |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyCNSBike.json          |
	| SaveDebitRequestBody       | SaveDebitRequestBodyCNSBike.json              |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNSBike.json        |
	| ApiVersion                 | V2                                            |
	| ContextName                | CNSelectBikeContext                           |

	When User send a Register PayInFull Payment service
	And User send a WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1    | Value   | StatusCode | Messages                                                         |
		| StartYear | missing | 200        | /mc/confirmation? |
