#Cover 471 cases
@CNSBike
Feature: PartialQuoteSingleFieldDataValidationCasesPart4

@QuoteServices
Scenario Outline: ValiDate Partial quote API on each field4
	Given The customer has 
	| Name         | Value1                      |
	| Url          | PartialQuote                |
	| ApiVersion   | V2                          |
	| Context      | CNSelectBikeContext         |
	| JsonBodyFile | ValidPartialQuotePart4CNSBike.json |
	When The customer call quote API
		| Level1   | Level2   | Level3   | Level4   | Level5   | Level6   | Level7   | Value   |
		| <Level1> | <Level2> | <Level3> | <Level4> | <Level5> | <Level6> | <Level7> | <Value> |
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| Level1 | Level2  | Level3  | Level4            | Level5     | Level6       | Level7 | Value   | StatusCode | IsSuccess | Message                                                                   |
	| Risk   | Product | Vehicle | AdditionalDrivers | Employment | EmployerCode |        | missing | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Product | Vehicle | AdditionalDrivers | Employment | EmployerCode |        | null    | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Product | Vehicle | AdditionalDrivers | Employment | EmployerCode |        | ""      | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |