#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

@CNSBike
Feature: RegisterPaymentInvalidRequestCasesV2

@PaymentServices
Scenario Outline:  Send a register payment request with invalid endpoint or methodV2	
	When User send request with invalid endpoint <Endpoint> or method <Method> with <ApiVersion> and <Context>
	Then The service response returns <StatusCode>
	Examples: 
	| Endpoint               | Method | StatusCode | ApiVersion | Context             |
	| /api/payment/register1 | POST   | 404        | V2         | CNSelectBikeContext |
	| /api/payment/register  | GET    | 404        | V2         | CNSelectBikeContext |