#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@ScenicMH
Feature: Send a Register Payment request normal case Instalment

@QuoteServices
Scenario Outline:  Send a Register Payment request with valid endpoint URL & method	
	Given User has payment body 
	| Property                   | Value                                             |
	| QuoteRequestBody           | ValidQuoteForScenicMH.json                        |
	| PaymentRequestBody         | RegisterPaymentRequestBodyScenicMH.json           |
	| SaveMarketingRequestBody   | SaveMarketingRequestBodyScenicMH.json             |
	| SaveDebitRequestBody       | SaveDebitRequestBodyScenicMH.json                 |
	| SaveCardConsentBody        | SaveCardConsentBodyScenicMH.json                  |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyInstalmntsScenicMH.json |
	| ApiVersion                 | V2                                                |
	| ContextName                | ScenicMotorHome                                   |
	When User send a Register Payment service request with data change
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Payment response returns <StatusCode> and <Messages>
	Examples: 
	  | Level1    | Value                                | StatusCode | Messages              |
	  | SessionId | null                                 | 400        | SessionId is required |
	  | SessionId | 520402c6-5ada-4e4a-a690-f9b66invalid | 400        | SessionId is invalid  |