#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Register payment
#Test Case ID: 1

@BeWiser
Feature: Send a Register Payment request normal case

@PaymentServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	
	Given User has payment body 
	| Property                   | Value                                       |
	| QuoteRequestBody           | ValidQuoteBeWiserSuccess.json          |
	| PaymentRequestBody         | RegisterPaymentRequestBodyBeWiser.json |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyBeWiser.json   |
	| SaveDebitRequestBody       | SaveDebitRequestBodyBeWiser.json       |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyBeWiser.json |
	| ApiVersion                 | V3                                          |
	| ContextName                | BeWiser                                |
	When User send a Register PayInFull Payment service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                      |
	  | 200        | Register payment successfully |