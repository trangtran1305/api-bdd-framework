#Cover 471 cases
@CNSBike
Feature: PartialQuoteSingleFieldDataValidationCasesGenderF

@QuoteServices
Scenario Outline: ValiDate Partial quote API on each field4
	Given The customer has 
	| Name         | Value1                    |
	| Url          | PartialQuote              |
	| ApiVersion   | V2                        |
	| Context      | CNSelectBikeContext       |
	| JsonBodyFile | ValidQuoteForGenderFCNSBike.json |
	When The customer call quote API
		| Level1   | Level2   | Level3   | Level4   | Level5   | Level6   | Level7   | Value   |
		| <Level1> | <Level2> | <Level3> | <Level4> | <Level5> | <Level6> | <Level7> | <Value> |
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| Level1 | Level2   | Level3  | Level4            | Level5 | Level6 | Level7 | Value | StatusCode | IsSuccess | Message                                    |
	| Risk   | Proposer | Gender  |                   |        |        |        | F     | 400        | FALSE     | Gender must be Male if title is Mr or Sir. |
	| Risk   | Product  | Vehicle | AdditionalDrivers | Gender |        |        | F     | 400        | FALSE     | Gender must be Male if title is Mr or Sir. |