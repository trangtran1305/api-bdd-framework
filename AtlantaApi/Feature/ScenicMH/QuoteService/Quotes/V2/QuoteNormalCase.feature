
@ScenicMH
Feature: QuoteNormalCase

@QuoteServices
Scenario Outline:QuoteNormalCase
	Given The customer has 
	| Name         | Value1                             |
	| Url          | QuoteApi                           |
	| ApiVersion   | V2                                 |
	| Context      | ScenicMotorHome                    |
	| JsonBodyFile | ValidQuoteForScenicMHGetQuote.json |
	When The customer call quote API normal case
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| StatusCode | IsSuccess | Message                |
	| 200        | TRUE      | Get quote successfully |