#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Register payment
#Test Case ID: 1

@ANCarClassic
Feature: Send a Register Payment request normal case V3

@PaymentServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	
	Given User has payment body 
	| Property                   | Value                                       |
	| QuoteRequestBody           | ValidQuoteANCarClassicSuccess.json          |
	| PaymentRequestBody         | RegisterPaymentRequestBodyANCarClassic.json |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyANCarClassic.json   |
	| SaveDebitRequestBody       | SaveDebitRequestBodyANCarClassic.json       |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyANCarClassic.json |
	| ApiVersion                 | V3                                          |
	| ContextName                | ANCarClassic                                |
	When User send a Register PayInFull Payment service
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | StatusCode | Messages                      |
	  | 200        | Register payment successfully |