#Cover 471 cases
@CNSBike
Feature: QuoteSingleFieldDataValidationCaseMultiBikeAndMultiRiders

@QuoteServices
Scenario Outline: ValiDate quote API on each field
	Given The customer has 
	| Name         | Value1                                     |
	| Url          | QuoteApi                                   |
	| ApiVersion   | V2                                         |
	| Context      | CNSelectBikeContext                        |
	| JsonBodyFile | CannotQuoteForBothMultiBikeMultiRiderCNSBike.json |
	When The customer call quote API
		| Level1   | Level2   | Level3   | Level4   | Level5   | Level6   | Level7   | Value   |
		| <Level1> | <Level2> | <Level3> | <Level4> | <Level5> | <Level6> | <Level7> | <Value> |
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| Level1 | Level2  | Level3  | Level4        | Level5 | Level6 | Level7 | Value                               | StatusCode | IsSuccess | Message                                           |
	| Risk   | Product | Vehicle | VehicleDetail |        |        |        | File: VehicleVehicleDetail1323CNSBike.json | 400        | FALSE     | Cannot quote for both multi-bike and multi-rider. |