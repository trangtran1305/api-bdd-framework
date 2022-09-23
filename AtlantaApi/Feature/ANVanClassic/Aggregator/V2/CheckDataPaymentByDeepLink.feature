#TCID: ACQ-2325-FUNC-TC-01, ACQ-2325-FUNC-TC-01
Feature: CheckDataAfterPaymentByDeepLinks

@TrackingServices

Scenario: Check Data after Payment By Deep Links annual
	Given User has wrapUp table
	| Property                   | Value                                                  |
	| Uri                        | /api/V2/payment/outcome/A//AN//Autonet%20Car//PC//SCAR |
	| WebHookBody                | WebHookBodyAutonetVan.json                           |
	| QuoteRequestBody           | ValidQuoteAutonetVanAggSite.json                     |
	| PaymentRequestBody         | RegisterPaymentRequestBodyAutonetVan.json            |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyAutonetVan.json              |
	| SaveDebitRequestBody       | SaveDebitRequestBodyAutonetVan.json                  |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyAutonetVan.json            |
	| ApiVersion                 | V2                                                     |
	| ContextName                | AutonetVan                                           |
	| PaymentMethod              | Annual                                                 |
	When User perform payment after DeepLink
	  | Level1 | Level2   | Level3      | Level4   | Level5 | Level6 | Level7 | Value      | Description |
	  | risk   | proposer | address     | postCode |        |        |        | SW81TF     | pcd         |
	  | risk   | proposer | dateOfBirth |          |        |        |        | 1980-02-01 | brd         |
	  | risk   | affinity |             |          |        |        |        | MCAR       | affinity    |

	And User send WebHook request
	Then Webhook response returns <StatusCode> and <Messages>
	And Result in Quote request is recorded successfully in Tracking Database <QuoteResults>
	And Result in Buy request is recorded successfully in Tracking Database <BuyResults>
	And SchemeCode in Quote response is recorded successfully in Tracking Database
	Examples: 
		| StatusCode | Messages         | QuoteResults | BuyResults |
		| 200        | pc/confirmation? | 25           | 25         |

Scenario: Check Data after Payment By Deep Links monthly
	Given User has wrapUp table
	| Property                   | Value                                                  |
	| Uri                        | /api/V2/payment/outcome/A//AN//Autonet%20Car//PC//SCAR |
	| WebHookBody                | WebHookBodyAutonetVan.json                           |
	| QuoteRequestBody           | ValidQuoteAutonetVanAggSite.json                     |
	| PaymentRequestBody         | RegisterPaymentRequestBodyAutonetVan.json            |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyAutonetVan.json              |
	| SaveDebitRequestBody       | SaveDebitRequestBodyAutonetVan.json                  |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyAutonetVan.json            |
	| ApiVersion                 | V2                                                     |
	| ContextName                | AutonetVan                                           |
	| PaymentMethod              | Monthly                                                |
	When User perform payment after DeepLink
	  | Level1 | Level2   | Level3      | Level4   | Level5 | Level6 | Level7 | Value      | Description |
	  | risk   | proposer | address     | postCode |        |        |        | SW81TF     | pcd         |
	  | risk   | proposer | dateOfBirth |          |        |        |        | 1980-02-01 | brd         |
	  | risk   | affinity |             |          |        |        |        | MCAR       | affinity    |

	And User send WebHook request
	Then Webhook response returns <StatusCode> and <Messages>
	And Result in Quote request is recorded successfully in Tracking Database <QuoteResults>
	And Result in Buy request is recorded successfully in Tracking Database <BuyResults>
	And SchemeCode in Quote response is recorded successfully in Tracking Database
	Examples: 
		| StatusCode | Messages         | QuoteResults | BuyResults |
		| 200        | pc/confirmation? | 25           | 25         |

