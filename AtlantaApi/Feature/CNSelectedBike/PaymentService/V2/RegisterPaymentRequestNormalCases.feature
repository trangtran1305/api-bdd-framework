#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@CNSBike
Feature: Send a Register Payment request normal cases

@PaymentServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	
	Given User has payment body 
	| Property                   | Value                             |
	| QuoteRequestBody           | ValidQuoteForRegisterPaymentCNSBike.json |
	| PaymentRequestBody         | RegisterPaymentRequestBodyCNSBike.json   |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyCNSBike.json     |
	| SaveDebitRequestBody       | SaveDebitRequestBodyCNSBike.json                 |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNSBike.json   |
	| ApiVersion                 | V2                                |
	| ContextName                | CNSelectBikeContext               |
	When User send a Register PayInFull Payment service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                      |
	  | 200        | Register payment successfully |