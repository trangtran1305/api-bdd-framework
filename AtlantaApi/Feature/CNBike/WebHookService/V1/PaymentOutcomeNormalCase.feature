#Webhook_TC04
@CNBike
Feature: Send a request with valid endpoint URL & method for CN Bike

@WebhookServices
Scenario Outline: Send a request with valid endpoint URL & method for CN Bike
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
	And User send a WebHook service
	Then Payment response returns <StatusCode> and <Message>
	Examples: 
	| StatusCode | Message          |
	| 200        | /mc/confirmation |