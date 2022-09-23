#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC03,TC07,TC10, TC57->TC63
@ScenicMH
Feature: Validate Metadata request with missing and valid field
@ReferenceDataServices
Scenario Outline: Validate Metadata request with missing and valid field
Given User has Reference Data body
	| Property                 | Value                     |
	| ReferenceDataRequestBody | MetadataBodyScenicMH.json |
	| ApiVersion               | V0                        |
	| ContextName              | ScenicMotorHome           |
	When User send Reference Data Metadata request
	| Level1   | Level2   | Value   |
	| <Level1> | <Level2> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| Level1           | Level2        | Value            | StatusCode | Message                    |
	| GetMetadataModel | ReferenceType | missing          | 400        | ReferenceType is required. |
	| GetMetadataModel | ReferenceType | employer         | 200        | Get successfully           |
	| GetMetadataModel | ReferenceType | studentstatus123 | 204        | NoContent                  | 

