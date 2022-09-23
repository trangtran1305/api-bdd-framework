@ScenicMH
Feature: Send a  save payment info with old sessionId

@QuoteServices
Scenario Outline: Send a valid save payment info request with old sessionId	
Given User has Save Payment Info body 
	| Property                   | Value                                   |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyScenicMH.json |
	| QuoteRequestBody           | ValidQuoteForScenicMH.json              |
	| ApiVersion                 | V2                                      |
	| ContextName                | ScenicMotorHome                         |
	When User send Save Payment Info with old sessionId
	When User send Save Payment Info Normal Case
	Then Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |