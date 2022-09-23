#TCID: WebHook_TC28
@CNSBike
Feature: Send a request with valid endpoint URL & method for CN Selected Bike

@WebhookServices
Scenario Outline: Send a request with valid endpoint URL & method for CN Selected Bike
	Given I have wrapUp table
	| Property                   | Value                                     |
	| Uri                        | /api/V2/payment/outcome/AT//CN//CNS//MC//6258 |
	| WebHookBody                | WebHookBodyCNSBike.json                          |
	| QuoteRequestBody           | ValidQuoteForRegisterPaymentCNSBike.json         |
	| PaymentRequestBody         | RegisterPaymentRequestBodyCNSBike.json           |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyCNSBike.json             |
	| SaveDebitRequestBody       | SaveDebitRequestBodyCNSBike.json                 |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNSBike.json           |
	| ApiVersion                 | V2                                        |
	| ContextName                | CNSelectBikeContext                       |

	When User send a Register PayInFull Payment service
	And User send a WebHook service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages                                                         |
	| 200        | /mc/confirmation? |