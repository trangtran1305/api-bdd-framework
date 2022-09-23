@CNSBike
Feature: Send a save marketing normal request

@QuoteServices
Scenario Outline: Send a save marketing request successfully	
Given User has Save Marketing body 
	| Property                 | Value                         |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyCNSBike.json |
	| QuoteRequestBody         | ValidQuoteForPrepurchaseCNSBike.json |
	| ApiVersion               | V2                            |
	| ContextName              | CNSelectBikeContext           |
	When User send Save Marketing normal case
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | ApiVersion | Context             | StatusCode | IsSuccess | Messages                |
	 | V1         | CNSelectBikeContext | 200        | true      | Save data successfully  |
