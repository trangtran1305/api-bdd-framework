#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 
@SafeGuardMH
Feature: Send a Register Payment request normal case payinfull

@QuoteServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	payinfull
	Given User has payment body for SG
	| Property                   | Value                                   |
	| QuoteRequestBody           | ValidQuoteForSGGetQuote1.json           |
	| PaymentRequestBody         | RegisterPaymentRequestBodyScenicMH.json |
	| SaveMarketingRequestBody   | SaveMarketingRequestBody.json           |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyScenicMH.json |
	| SaveCardConsentBody        | SaveCardConsentBody.json                |
	| ApiVersion0                | V0                                      |
	| ApiVersion1                | V1                                      |
	| ApiVersion2                | V2                                      |
	| ContextName                | SafeGuardMH                             |
	When User send a SG Resister Payment service
	Then SG Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                      |
	  | 200        | Register payment successfully |