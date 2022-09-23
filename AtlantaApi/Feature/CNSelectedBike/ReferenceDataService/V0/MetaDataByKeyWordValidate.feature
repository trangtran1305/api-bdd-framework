#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID: ReferrenData-TC46,47,49->53

@CNSBike
Feature: Validate Metadata By Key Word request with validate field
@ReferenceDataServices
Scenario Outline: Validate Metadata By Key Word request with validate field
Given User has Reference Data body
	| Property                 | Value                           |
	| ReferenceDataRequestBody | ReferenceDataByKeyWordBodyCNSBike.json |
	| ApiVersion               | V0                              |
	| ContextName              | CNSelectBikeContext             |
	When User send Reference Data Metadata request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| Level1        | Value                   | StatusCode | Message                    |
	| ReferenceType | missing                    | 400        | ReferenceType is required. |
	| SearchKeyWord | missing                    | 400        | SearchKeyWord is required. |
	| ReferenceType | Employer1               | 204        | NoContent                  |
	| SearchKeyWord | A                       | 200        | Get successfully           |
	| SearchKeyWord | AJS                     | 200        | Get successfully           |
	| SearchKeyWord | Moto Morini Riders Club | 200        | Get successfully           |
	| SearchKeyWord | abdkahfk                | 204        | NoContent                  |

