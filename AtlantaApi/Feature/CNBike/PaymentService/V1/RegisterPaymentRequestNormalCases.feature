#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@CNBike
Feature: Send a Register Payment request normal case

@PaymentServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	
	Given User has payment body 
	| Property                   | Value                                   |
	| QuoteRequestBody           | ValidQuoteForRegisterPaymentCNBike.json |
	| PaymentRequestBody         | RegisterPaymentRequestBodyCNBike.json   |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyCNBike.json     |
	| SaveDebitRequestBody       | SaveDebitRequestBodyCNBike.json         |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNBike.json   |
	| ApiVersion                 | V1                                      |
	| ContextName                | CNBikeContext                           |
	When User send a Register PayInFull Payment service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                      |
	  | 200        | Register payment successfully |