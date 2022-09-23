#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC04
@SafeGuardMH
Feature: Validate Metadata request with normal case
@ReferenceDataServices
Scenario Outline: Validate Metadata request with normal case
Given User has Reference Data body
	| Property                 | Value                     |
	| ReferenceDataRequestBody | MetadataBodyScenicSG.json |
	| ApiVersion               | V0                        |
	| ContextName              | SafeGuardMH               |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |
