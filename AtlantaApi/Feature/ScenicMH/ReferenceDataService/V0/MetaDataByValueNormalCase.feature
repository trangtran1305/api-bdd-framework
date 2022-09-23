#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC59
@ScenicMH
Feature:  Metadata by value request Normal Case
@ReferenceDataServices
Scenario Outline:  Metadata by value request Normal Case
Given User has Reference Data body
	| Property                 | Value                    |
	| ReferenceDataRequestBody | MetadataBodyByValue.json |
	| ApiVersion               | V0                       |
	| ContextName              | ScenicMotorHome          |
	When User send Reference Data Metadata request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
		| Level1        | Value    | StatusCode | Message          |
		| ReferenceType | Employer | 200        | Get successfully |

