@SafeGuardMH
Feature: Send a request with valid endpoint URL & method for SafeGuard

@WebhookServices
Scenario Outline: Send a request with valid endpoint URL & method for SafeGuard
	Given I have wrapUp table for SG
	| Property                   | Value                                    |
	| Uri                        | /api/V1/payment/outcome/at-sw-sc-mh-SWIN |
	| WebHookBody                | WebHookBodyScenicSG.json                 |
	| QuoteRequestBody           | ValidQuoteForSGGetQuote1.json            |
	| PaymentRequestBody         | RegisterPaymentRequestBodyScenicMH.json  |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyScenicMH.json    |
	| SavePaymentInfoRequestBody | SavePaymentInfoSGquestBodyPayInFull.json |
	| SaveCardConsentBody        | SaveCardConsentBodyForSG.json            |
	| ApiVersion0                | V0                                       |
	| ApiVersion1                | V1                                       |
	| ApiVersion2                | V2                                       |
	| ContextName                | SafeGuardMH                              |

	When User send a SG Resister Payment service
	And User send a SG WebHook service
	Then SG Payment response returns <StatusCode> and <Messages>
	Examples: 
	| StatusCode | Messages                 |
	| 200        | /mh/newbus/confirmation? |
