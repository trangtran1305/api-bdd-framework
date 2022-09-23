#Cover 471 cases
@SafeGuardMH
Feature: PartialQuoteNormalCase

@QuoteServices
Scenario Outline:PartialQuoteNormalCase
	Given The customer has 
	| Name         | Value1                             |
	| Url          | PartialQuote                       |
	| ApiVersion   | V2                                 |
	| Context      | SafeGuardMH                        |
	| JsonBodyFile | ValidQuoteForScenicMHGetQuote.json |
	When The customer call quote API normal case
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| StatusCode | IsSuccess | Message                          |
	| 200        | TRUE      | Store partial quote successfully |