#Cover 471 cases
@CNSBike
Feature: QuoteSingleFieldDataValidationCasesPart4

@QuoteServices
Scenario Outline: ValiDate quote API on each field
	Given The customer has 
	| Name         | Value1               |
	| Url          | QuoteApi             |
	| ApiVersion   | V2                   |
	| Context      | CNSelectBikeContext  |
	| JsonBodyFile | ValidQuotePart4CNSBike.json |
	When The customer call quote API
		| Level1   | Level2   | Level3   | Level4   | Level5   | Level6   | Level7   | Value   |
		| <Level1> | <Level2> | <Level3> | <Level4> | <Level5> | <Level6> | <Level7> | <Value> |
	Then The message should be shown <StatusCode>,<IsSuccess>,"<Message>"
	Examples:	
	| Level1 | Level2   | Level3     | Level4            | Level5     | Level6       | Level7 | Value   | StatusCode | IsSuccess | Message                                                                   |
	| Risk   | Proposer | Employment | EmployerCode      |            |              |        | missing | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Proposer | Employment | EmployerCode      |            |              |        | null    | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Proposer | Employment | EmployerCode      |            |              |        | ""      | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Product  | Vehicle    | AdditionalDrivers | Employment | EmployerCode |        | missing | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Product  | Vehicle    | AdditionalDrivers | Employment | EmployerCode |        | null    | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Product  | Vehicle    | AdditionalDrivers | Employment | EmployerCode |        | ""      | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Proposer | Employment | EmployerCode      |            |              |        | missing | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Proposer | Employment | EmployerCode      |            |              |        | null    | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |
	| Risk   | Proposer | Employment | EmployerCode      |            |              |        | ""      | 400        | FALSE     | Employment - EmployerCode is required with EmploymentCode # R, U, H, FTE. |