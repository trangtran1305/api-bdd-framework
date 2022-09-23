#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID ReferrenData-TC03,TC07,TC10
@CNSBike
Feature: Validate Metadata request with missing and valid field
@ReferenceDataServices
Scenario Outline: Validate Metadata request with missing and valid field
Given User has Reference Data body
	| Property                 | Value               |
	| ReferenceDataRequestBody | MetadataBodyCNSBike.json   |
	| ApiVersion               | V0                  |
	| ContextName              | CNSelectBikeContext |
	When User send Reference Data Metadata request
	| Level1   | Level2   | Value   |
	| <Level1> | <Level2> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| Level1           | Level2        | Value                       | StatusCode | Message                    |
	| GetMetadataModel | ReferenceType | missing                     | 400        | ReferenceType is required. |
	| GetMetadataModel | ReferenceType | MotoringOrganisationsListMC | 200        | Get successfully           |
	| GetMetadataModel | ReferenceType | studentstatus123            | 204        | NoContent                  |

