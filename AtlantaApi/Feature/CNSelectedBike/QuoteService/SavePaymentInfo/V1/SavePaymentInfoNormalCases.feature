@CNSBike
Feature: Send a  save payment info normal case

@QuoteServices
Scenario Outline: Send a valid save payment info request successfully	
Given User has Save Payment Info body 
	| Property                   | Value                           |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyCNSBike.json |
	| QuoteRequestBody           | ValidQuoteForPrepurchaseCNSBike.json   |
	| ApiVersion                 | V2                              |
	| ContextName                | CNSelectBikeContext             |
	When User send Save Payment Info Normal Case
	Then Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |