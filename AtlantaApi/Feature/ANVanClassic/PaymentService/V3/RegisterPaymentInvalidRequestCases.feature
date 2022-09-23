#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Register payment
#Test Case ID: 2,3
@AutonetVan
Feature: RegisterPaymentInvalidRequestCasesV3

@PaymentServices
Scenario Outline:  Send a register payment request with invalid endpoint or method	
	When User send request with invalid endpoint <Endpoint> or method <Method> with <ApiVersion> and <Context>
	Then The service response returns <StatusCode>
	Examples: 
	| Endpoint               | Method | StatusCode | ApiVersion | Context      |
	| /api/payment/register1 | POST   | 404        | V2         | AutonetVan |
	| /api/payment/register  | GET    | 404        | V2         | AutonetVan |
