
@CNBike
Feature: PartialQuoteNormalCase

@QuoteServices
Scenario Outline:QuoteNormalCase
	Given The customer has 
	| Name         | Value1                          |
	| Url          | PartialQuote                    |
	| ApiVersion   | V1                              |
	| Context      | CNBikeContext                   |
	| JsonBodyFile | ValidPartialQuoteForCNBike.json |
	When The customer call quote API normal case
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| StatusCode | IsSuccess | Message                          |
	| 200        | TRUE      | Store partial quote successfully |