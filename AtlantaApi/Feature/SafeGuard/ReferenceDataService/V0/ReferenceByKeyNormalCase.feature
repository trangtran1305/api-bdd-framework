@SafeGuardMH
Feature: Get reference meta data by value

@ReferenceDataServices
Scenario: Get Reference meta data by value
	Given User has Reference Meta Data body
	| Property                 | Value                      |
	| ReferenceDataRequestBody | MetadataBodyByValueSG.json |
	| ApiVersion               | V0                         |
	| ContextName              | SafeGuardMH                |
	When User sends reference request by key
	Then The Reference Meta Data response should be shown <Message> and <StatusCode>
	Examples:
	  | Message          | StatusCode |
	  | Get successfully | 200        |