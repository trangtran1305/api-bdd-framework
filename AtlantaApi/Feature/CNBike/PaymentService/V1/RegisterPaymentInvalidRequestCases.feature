#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@CNBike
Feature: RegisterPaymentInvalidRequestCases

@PaymentServices
Scenario Outline:  Send a register payment request with invalid endpoint or method		
	When User send request with invalid endpoint <Endpoint> or method <Method> with <ApiVersion> and <Context>
	Then The service response returns <StatusCode>
	Examples: 
	| Endpoint               | Method | StatusCode | ApiVersion | Context       |
	| /api/payment/register1 | POST   | 404        | V1         | CNBikeContext |
	| /api/payment/register  | GET    | 404        | V1         | CNBikeContext |