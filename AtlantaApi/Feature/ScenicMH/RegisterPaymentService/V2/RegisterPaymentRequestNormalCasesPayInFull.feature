#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@ScenicMH
Feature: Send a Register Payment request normal case payinfull

@QuoteServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	payinfull
	Given User has payment body
	| Property                   | Value                                   |
	| QuoteRequestBody           | ValidQuoteForScenicMH.json              |
	| PaymentRequestBody         | RegisterPaymentRequestBodyScenicMH.json |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyScenicMH.json   |
	| SaveDebitRequestBody       | SaveDebitRequestBodyScenicMH.json       |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyScenicMH.json |
	| SaveCardConsentBody        | SaveCardConsentBodyScenicMH.json        |
	| ApiVersion                 | V2                                      |
	| ContextName                | ScenicMotorHome                         |
	When User send a Register PayInFull Payment service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                      |
	  | 200        | Register payment successfully |