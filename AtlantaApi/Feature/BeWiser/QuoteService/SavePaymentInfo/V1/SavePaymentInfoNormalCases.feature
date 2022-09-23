#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC01

@BeWiser
Feature: Send a  save payment info normal case

@QuoteServices
Scenario Outline: Send a valid save payment info request successfully	
Given User has Save Payment Info body 
	| Property                   | Value                                       |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyBeWiser.json |
	| QuoteRequestBody           | ValidQuoteBeWiserSuccess.json          |
	| ApiVersion                 | V3                                          |
	| ContextName                | BeWiser                                |
	When User send Save Payment Info Normal Case
	Then Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |