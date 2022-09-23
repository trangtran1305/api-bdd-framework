#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC46,TC47, TC49->TC53
@ScenicMH
Feature: Validate Metadata By Key Word request with validate field
@ReferenceDataServices
Scenario Outline: Validate Metadata By Key Word request with validate field
Given User has Reference Data body
	| Property                 | Value                           |
	| ReferenceDataRequestBody | ReferenceDataByKeyWordBody.json |
	| ApiVersion               | V0                              |
	| ContextName              | ScenicMotorHome             |
	When User send Reference Data Metadata request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| Level1        | Value           | StatusCode | Message                    |
	| ReferenceType | missing         | 400        | ReferenceType is required. |
	| SearchKeyWord | missing         | 400        | SearchKeyWord is required. |
	| ReferenceType | conviction1     | 204        | NoContent                  |
	| SearchKeyWord | a               | 200        | Get successfully           |
	| SearchKeyWord | Driving         | 200        | Get successfully           |
	| SearchKeyWord | Driving without | 200        | Get successfully           |
	| SearchKeyWord | abdkahfk        | 204        | NoContent                  |

