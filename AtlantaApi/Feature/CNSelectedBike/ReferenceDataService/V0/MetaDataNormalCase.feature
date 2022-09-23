#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID: ReferrenData-TC04

@CNSBike
Feature: Validate Metadata request normal case
@ReferenceDataServices
Scenario Outline: Validate Metadata request normal case
Given User has Reference Data body
	| Property                 | Value               |
	| ReferenceDataRequestBody | MetadataBodyCNSBike.json   |
	| ApiVersion               | V0                  |
	| ContextName              | CNSelectBikeContext |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |

Scenario Outline: Validate Metadata request normal case with multi reference type
Given User has Reference Data body
	| Property                 | Value                          |
	| ReferenceDataRequestBody | MetadataBodyMultiRefTypesCNSBike.json |
	| ApiVersion               | V0                             |
	| ContextName              | CNSelectBikeContext            |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |
