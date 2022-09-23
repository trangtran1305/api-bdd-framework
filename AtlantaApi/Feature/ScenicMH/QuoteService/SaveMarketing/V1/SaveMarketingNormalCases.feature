#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Prepurchase
#Test Case ID: Prepurchase_TC36

@ScenicMH
Feature: Send a save marketing normal request

@QuoteServices
Scenario Outline: Send a save marketing request successfully	
Given User has Save Marketing body 
	| Property                 | Value                         |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyScenicMH.json |
	| QuoteRequestBody         | ValidQuoteForScenicMH.json    |
	| ApiVersion               | V2                            |
	| ContextName              | ScenicMotorHome               |
	When User send Save Marketing normal case
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages                |
	 | 200        | true      | Save data successfully  |