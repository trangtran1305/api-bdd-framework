#Cover 471 cases
@CNSBike
Feature:GetPartialQuoteNormalCase

@QuoteServices
Scenario Outline: ValiDate quote API on each field
	Given The customer has 
	| Name         | Value1              |
	| Url          | PartialQuote        |
	| ApiVersion   | V2                  |
	| Context      | CNSelectBikeContext |
	| JsonBodyFile | ValidQuoteCNSBike.json     |
	When The customer call quote API normal case
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
		 | StatusCode | IsSuccess | Message                          |
		 | 200        | TRUE      | Store partial quote successfully |
