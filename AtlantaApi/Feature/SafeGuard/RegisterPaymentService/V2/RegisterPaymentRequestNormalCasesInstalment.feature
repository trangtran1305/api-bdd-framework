#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 
@SafeGuardMH
Feature: Send a Register Payment request normal case Instalment

@QuoteServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	
	Given User has payment body for SG
	| Property                   | Value                                       |
	| QuoteRequestBody           | ValidQuoteForSGGetQuote1.json               |
	| PaymentRequestBody         | RegisterPaymentRequestBodySG.json           |
	| SaveMarketingRequestBody   | SaveMarketingRequestBody.json               |
	| SaveDirectDebitBody        | SaveDebitRequestBodySG.json                 |
	| SaveCardConsentBody        | SaveCardConsentBody.json                    |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyInstalmntsSG.json |
	| ApiVersion0                | V0                                          |
	| ApiVersion1                | V1                                          |
	| ApiVersion2                | V2                                          |
	| ContextName                | SafeGuardMH                                 |
	When User send a SG Resister Payment service
	Then SG Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                      |
	  | 200        | Register payment successfully |