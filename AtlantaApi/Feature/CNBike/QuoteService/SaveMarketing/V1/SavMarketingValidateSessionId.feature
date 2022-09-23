#Prepurchase_TC81

@CNBike
Feature: Send a save marketing request with session ID

@QuoteServices
Scenario Outline: Send a save marketing request successfully	
Given User has Save Marketing body 
	| Property                 | Value                               |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyCNBike.json |
	| QuoteRequestBody         | ValidQuoteForPrepurchaseCNBike.json |
	| ApiVersion               | V1                                  |
	| ContextName              | CNBikeContext                       |
	When User send Save Marketing request with <SessionId>
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples: 
	 | SessionId | StatusCode | IsSuccess | Messages               |
	 | Old       | 200        | true      | Save data successfully |

