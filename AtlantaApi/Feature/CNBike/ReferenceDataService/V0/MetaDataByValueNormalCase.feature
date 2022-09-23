#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID: ReferrenData-TC59

@CNBike
Feature:  Metadata by value request Normal Case
@ReferenceDataServices
Scenario Outline:  Metadata by value request Normal Case
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
		| Level1        | Value            | StatusCode | Message          |
		| ReferenceType | BusinessTypeList | 200        | Get successfully |

