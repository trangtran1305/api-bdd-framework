@SafeGuardMH
Feature: QuoteNormalCase

@QuoteServices
Scenario Outline:QuoteNormalCase
	Given The customer has 
	| Name         | Value1                        |
	| Url          | QuoteApi                      |
	| ApiVersion   | V2                            |
	| Context      | SafeGuardMH                   |
	| JsonBodyFile | ValidQuoteForSGGetQuote1.json |
	When The customer call quote API normal case
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| StatusCode | IsSuccess | Message                |
	| 200        | TRUE      | Get quote successfully |