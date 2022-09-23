#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID: ReferrenData-TC04

@BeWiser
Feature: Validate Metadata request normal case
@ReferenceDataServices
Scenario Outline: Validate Metadata request normal case
Given User has Reference Data body
	| Property                 | Value                         |
	| ReferenceDataRequestBody | MetadataBodyBeWiser.json |
	| ApiVersion               | V0                            |
	| ContextName              | BeWiser                  |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |

@ReferenceDataServices
Scenario Outline: Validate Metadata request normal case with multi reference type
Given User has Reference Data body
	| Property                 | Value                                      |
	| ReferenceDataRequestBody | MetadataBodyMultiRefTypesBeWiser.json |
	| ApiVersion               | V0                                         |
	| ContextName              | BeWiser                               |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |
