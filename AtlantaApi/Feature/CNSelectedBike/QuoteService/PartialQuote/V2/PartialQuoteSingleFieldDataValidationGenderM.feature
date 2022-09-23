#Cover 471 cases
@CNSBike
Feature: PartialQuoteSingleFieldDataValidationCasesGenderM

@QuoteServices
Scenario Outline: ValiDate Partial quote API on each field4
	Given The customer has 
	| Name         | Value1                    |
	| Url          | PartialQuote              |
	| ApiVersion   | V2                        |
	| Context      | CNSelectBikeContext       |
	| JsonBodyFile | ValidQuoteForGenderMCNSBike.json |
	When The customer call quote API
		| Level1   | Level2   | Level3   | Level4   | Level5   | Level6   | Level7   | Value   |
		| <Level1> | <Level2> | <Level3> | <Level4> | <Level5> | <Level6> | <Level7> | <Value> |
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| Level1 | Level2   | Level3  | Level4            | Level5 | Level6 | Level7 | Value | StatusCode | IsSuccess | Message                                              |
	| Risk   | Proposer | Gender  |                   |        |        |        | M     | 400        | FALSE     | Gender must be Female if title is Miss or Mrs or Ms. |
