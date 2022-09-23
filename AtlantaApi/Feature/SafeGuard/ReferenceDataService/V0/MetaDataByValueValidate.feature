#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID: ReferrenData-TC557,58,TC62,TC63
@SafeGuardMH
Feature: Metadata by value request with missing and valid field
@ReferenceDataServices
Scenario Outline: Validate Metadata by value request with missing and valid field
Given User has Reference Data body
	| Property                 | Value                      |
	| ReferenceDataRequestBody | MetadataBodyByValueSG.json |
	| ApiVersion               | V0                         |
	| ContextName              | ScenicMotorHome            |
	When User send Reference Data Metadata request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
		| Level1        | Value    | StatusCode | Message                    |
		| ReferenceType | missing  | 400        | ReferenceType is required. |
		| SearchName    | missing  | 400        | SearchName is required.    |
		| ReferenceType | bdhalfna | 204        | NoContent                  |
		| SearchName    | sp30     | 200        | Get successfully           |


