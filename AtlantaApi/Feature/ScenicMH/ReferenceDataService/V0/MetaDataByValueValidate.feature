#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC58.59.TC62,TC63
@ScenicMH
Feature: Metadata by value request with missing and valid field
@ReferenceDataServices
Scenario Outline: Validate Metadata by value request with missing and valid field
Given User has Reference Data body
	| Property                 | Value                    |
	| ReferenceDataRequestBody | MetadataBodyByValue.json |
	| ApiVersion               | V0                       |
	| ContextName              | ScenicMotorHome      |
	When User send Reference Data Metadata request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
		| Level1        | Value    | StatusCode | Message                    |
		| ReferenceType | bdhalfna | 204        | NoContent                  |
		| ReferenceType | missing  | 400        | ReferenceType is required. |
		| SearchName    | missing  | 400        | SearchName is required.    |
		| SearchName    | 026      | 200        | Get successfully           |


