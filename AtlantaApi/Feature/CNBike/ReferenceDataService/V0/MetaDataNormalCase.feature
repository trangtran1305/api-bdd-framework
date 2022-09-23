#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC04
@CNBike
Feature: Validate Metadata request with normal case
@ReferenceDataServices
Scenario Outline: Validate Metadata request with normal case
Given User has Reference Data body
	| Property                 | Value                   |
	| ReferenceDataRequestBody | MetadataBodyCNBike.json |
	| ApiVersion               | V0                      |
	| ContextName              | CNBikeContext           |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |

@ReferenceDataServices
Scenario Outline: Validate Metadata request with normal case with multi ref type
Given User has Reference Data body
	| Property                 | Value                                |
	| ReferenceDataRequestBody | MetadataBodyMultiRefTypesCNBike.json |
	| ApiVersion               | V0                                   |
	| ContextName              | CNBikeContext                        |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |
