#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC08

@BeWiser
Feature: Send a save payment info with old sessionId

@QuoteServices
Scenario Outline: Send a valid save payment info with old sessionId
Given User has Save Payment Info body 
	| Property                   | Value                                       |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyBeWiser.json |
	| QuoteRequestBody           | ValidQuoteBeWiserSuccess.json          |
#Take apiVersion of Quote service as base, apiVersion is defined for each api on ../Utils/ServiceVersionsManagement
	| ApiVersion                 | V3                                 |
	| ContextName                | BeWiser                       |
	When User send Save Payment Info with old sessionId
	Then Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |