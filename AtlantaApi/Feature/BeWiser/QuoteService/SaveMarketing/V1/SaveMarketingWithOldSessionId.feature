#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC36

@BeWiser
Feature: Send a save marketing request with old sessionId

@QuoteServices
Scenario Outline: Send a save marketing request successfully with old sessionId
Given User has Save Marketing body 
	| Property                 | Value                                |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyBeWiser.json |
	| QuoteRequestBody         | ValidQuoteBeWiserSuccess.json        |
	| ApiVersion               | V3                                   |
	| ContextName              | BeWiser                              |
	When User send Save Marketing with old sessionID
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | ApiVersion | Context | StatusCode | IsSuccess | Messages               |
	 | V1         | BeWiser | 200        | true      | Save data successfully |
