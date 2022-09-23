#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Prepurchase
#Test Case ID: Prepurchase_TC36
@SafeGuardMH
Feature: Send a save marketing normal request

@QuoteServices
Scenario Outline: Send a save marketing request successfully	
Given User has Save Marketing body 
	| Property                 | Value                         |
	| SaveMarketingRequestBody | SaveMarketingRequestBody.json |
	| QuoteRequestBody         | ValidQuoteForSGGetQuote1.json |
	| ApiVersion               | V2                            |
	| ContextName              | SafeGuardMH                   |
	When User send Save Marketing normal case
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages                |
	 | 200        | true      | Save data successfully  |