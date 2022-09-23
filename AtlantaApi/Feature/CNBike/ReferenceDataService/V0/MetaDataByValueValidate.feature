#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC03,07
@CNBike
Feature: Metadata by value request with missing and valid field
@ReferenceDataServices
Scenario Outline: Validate Metadata by value request with missing and valid field
Given User has Reference Data body
	| Property                 | Value                          |
	| ReferenceDataRequestBody | MetadataBodyByValueCNBike.json |
	| ApiVersion               | V0                             |
	| ContextName              | CNBikeContext                  |
	When User send Reference Data Metadata request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
		| Level1        | Value     | StatusCode | Message                    |
		| ReferenceType | missing   | 400        | ReferenceType is required. |
		| ReferenceType | fsasfasdf | 204        | NoContent                  |
		| SearchName    | missing   | 400        | SearchName is required.    |
		| SearchName    | 025       | 200        | Get successfully           |


