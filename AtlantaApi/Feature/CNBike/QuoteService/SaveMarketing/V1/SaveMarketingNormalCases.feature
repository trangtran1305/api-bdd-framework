
#Prepurchase_TC36
@CNBike
Feature: Send a save marketing normal request

@QuoteServices
Scenario Outline: Send a save marketing request successfully	
Given User has Save Marketing body 
	| Property                 | Value                               |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyCNBike.json |
	| QuoteRequestBody         | ValidQuoteForPrepurchaseCNBike.json |
	| ApiVersion               | V1                                  |
	| ContextName              | CNBikeContext                       |
	When User send Save Marketing normal case
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | StatusCode | IsSuccess | Messages               |
	 | 200        | true      | Save data successfully |
