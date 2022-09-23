@SafeGuardMH
Feature: PaymentOutcomeValidation
@WebhookServices
Scenario: PaymentOutcomeValidation
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
	And User send a SG WebHook service with 
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then SG Payment response returns <StatusCode> and <Messages>
	Examples: 
		| Level1           | Value      | StatusCode | Messages                 |
		| MerchantID       | 123        | 200        | /mh/newbus/confirmation? |
		| NavigationStatus | COMPLETED  | 200        | /mh/newbus/confirmation? |
		| PaymentType      | ""         | 200        | /mh/newbus/confirmation? |
		| CardTypeValue    | missing    | 200        | /mh/newbus/confirmation? |
		| CardTypeValue    | Mastercard | 200        | /mh/newbus/confirmation? |
		| CardHolderName   | Test       | 200        | /mh/newbus/confirmation? |
		| ExpiryMonth      | 1          | 200        | /mh/newbus/confirmation? |
		| IIN              | missing    | 200        | /mh/newbus/confirmation? |
		| IIN              | 545454     | 200        | /mh/newbus/confirmation? |
		| IssueNumber      | 556        | 200        | /mh/newbus/confirmation? |
		| MaskedCardNumber | 1234       | 200        | /mh/newbus/confirmation? |
		| StartMonth       | 2          | 200        | /mh/newbus/confirmation? |
		| StartYear        | 2019       | 200        | /mh/newbus/confirmation? |