#Vehicle_013,020,022,023, 024, 025, 026, 027, 028, 029, 033, 034, 035, 036
@CNBike
Feature: VehicleSearchValidate

@VehicleServices
Scenario Outline: Validate Search API on each field with valid
 Given User has search vehicle bodyjson
	| Property           | Value                        |
	| VehicleRequestBody | VehicleSearchBodyCNBike.json |
	| ApiVersion         | V1                           |
	| ContextName        | CNBikeContext                |
	When The customer call vehicle search API using <Key>
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then The Vehicle response should be shown <StatusCode> and <Message> and <Key>
	Examples:
		| Level1            | Value   | StatusCode | Message                                  | Key                       |
		| Make              | null    | 400        | Make is required.                        | ValidateSearchCNBikeAPI1  |
		| YearOfManufacture | 1899    | 400        | YearOfManufacture is invalid.            | ValidateSearchCNBikeAPI2  |
		| YearOfManufacture | 2020    | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI3  |
		| FuelType          | K       | 400        | FuelType is invalid.                     | ValidateSearchCNBikeAPI4  |
		| FuelType          | k       | 400        | FuelType is invalid.                     | ValidateSearchCNBikeAPI5  |
		| FuelType          | null    | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI6  |
		| FuelType          | D       | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI7  |
		| FuelType          | \b D \b | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI8  |
		| Transmission      | X       | 400        | Transmission is invalid.                 | ValidateSearchCNBikeAPI9  |
		| Transmission      | A       | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI10 |
		| Transmission      | null    | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI11 |
		| EngineCC          | -1      | 400        | EngineCC must be a number greater than 0 | ValidateSearchCNBikeAPI12 |
		| EngineCC          | 3.14    | 400        | EngineCC must be a number greater than 0 | ValidateSearchCNBikeAPI13 |
		| EngineCC          | 1       | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI14 |
		| EngineCC          | null    | 200        | Search vehicle successfully.             | ValidateSearchCNBikeAPI15 |
