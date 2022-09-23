#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Vehicle
#Test Case ID: Vehicle_013, 20, 22-> 29, 31, 33-> 36

@BeWiser
Feature: VehicleSearchValidate

@VehicleServices
Scenario Outline: Validate Search API on each field with valid
 Given User has search vehicle body
	| Property           | Value                              |
	| VehicleRequestBody | VehicleSearchBodyBeWiser.json |
	| ApiVersion         | V2                                 |
	| ContextName        | BeWiser                       |
	When User send Vehicle Search data change
		| Level1   | Value   |
		| <Level1> | <Value> |
	Then The Vehicle response should show <StatusCode> and <Message>
	Examples:
		| Level1			| Value   | StatusCode | Message                                  |
		| Make              | null    | 400        | Make is required.                        |
		| YearOfManufacture | 1899    | 400        | YearOfManufacture is invalid.            |
		| YearOfManufacture | 2020    | 200        | Get data successfully			          |
		| FuelType          | K       | 400        | FuelType is invalid.                     |
		| FuelType          | k       | 400        | FuelType is invalid.                     |
		| FuelType          | null    | 200        | Get data successfully			          |
		| FuelType          | P       | 200        | Get data successfully			          |
		| FuelType          | \bP\b   | 200        | Get data successfully			          |
		| Transmission      | X       | 400        | Transmission is invalid.                 |
		| Transmission      | A       | 200        | Get data successfully			          |
		| Transmission      | null    | 200        | Get data successfully			          |
		| EngineCC          | -1      | 400        | EngineCC must be a number greater than 0 |
		| EngineCC          | 3.14    | 400        | EngineCC must be a number greater than 0 |
		| EngineCC          | 1498    | 200        | Get data successfully			          |
		| EngineCC          | null    | 200        | Get data successfully			          |
