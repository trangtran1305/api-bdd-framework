#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Register payment
#Test Case ID: 1

@ANCarClassic
Feature: Send a Register Payment request validation cases V3

@PaymentServices
Scenario Outline:  Send a Register Payment request validation case
	Given User has payment body 
	| Property                   | Value                                       |
	| QuoteRequestBody           | ValidQuoteANCarClassicSuccess.json          |
	| PaymentRequestBody         | RegisterPaymentRequestBodyANCarClassic.json |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyANCarClassic.json   |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyANCarClassic.json |
	| SaveDebitRequestBody       | SaveDebitRequestBodyANCarClassic.json       |
	| ApiVersion                 | V3                                          |
	| ContextName                | ANCarClassic                                |
	When User send a Register Payment service request with data change
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | Level1    | Value                                | StatusCode | Messages              |
	  | SessionId | null                                 | 400        | SessionId is required |
	  | SessionId | 520402c6-5ada-4e4a-a690-f9b66invalid | 400        | SessionId is invalid  |