#TCID: Vehicle_13,20,22->36

@CNSBike
Feature: VehicleSearchValidate

@VehicleServices
Scenario Outline: Validate Search API on each field with valid
 Given User has search vehicle bodyjson
	| Property           | Value                  |
	| VehicleRequestBody | VehicleSearchBodyCNSBike.json |
	| ApiVersion         | V2                     |
	| ContextName        | CNSelectBikeContext    |

	When The customer call vehicle search API using <Key>
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then The Vehicle response should be shown <StatusCode> and <Message> and <Key>

	Examples:
		| Level1            | Value   | StatusCode | Message                                  | Key                        |
		| Make              | null    | 400        | Make is required.                        | ValidateSearchCNSBikeAPI1  |
		| YearOfManufacture | 1899    | 400        | YearOfManufacture is invalid.            | ValidateSearchCNSBikeAPI2  |
		| YearOfManufacture | 2020    | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI3  |
		| FuelType          | K       | 400        | FuelType is invalid.                     | ValidateSearchCNSBikeAPI4  |
		| FuelType          | k       | 400        | FuelType is invalid.                     | ValidateSearchCNSBikeAPI5  |
		| FuelType          | null    | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI6  |
		| FuelType          | P       | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI7  |
		| FuelType          | \b P \b | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI8  |
		| Transmission      | X       | 400        | Transmission is invalid.                 | ValidateSearchCNSBikeAPI9  |
		| Transmission      | A       | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI0  |
		| Transmission      | null    | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI11 |
		| EngineCC          | -1      | 400        | EngineCC must be a number greater than 0 | ValidateSearchCNSBikeAPI12 |
		| EngineCC          | 3.14    | 400        | EngineCC must be a number greater than 0 | ValidateSearchCNSBikeAPI13 |
		| EngineCC          | 420     | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI14 |
		| EngineCC          | null    | 200        | Get data successfully                    | ValidateSearchCNSBikeAPI15 |