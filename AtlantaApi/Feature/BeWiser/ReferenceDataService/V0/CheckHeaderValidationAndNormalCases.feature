#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID: ReferrenData-TC01,TC02,TC44;TC45;TC55,TC56

@BeWiser
Feature: CheckHeaderValidationAndNormalCases

@ReferenceDataServices
Scenario Outline: Send reference data request with header
Given User has Reference Data body
	| Property                 | Value                         |
	| ReferenceDataRequestBody | MetadataBodyBeWiser.json |
	| ApiVersion               | V0                            |
	| ContextName              | BeWiser                  |
	When User send invalid metadata request with <Endpoint> and <ContextName>
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples: 
	| Endpoint                               | ContextName         | StatusCode | Message                 |
	| /api/reference-data/metadata           | ContextNull         | 400        | Tenant is not supported |
	| /api/reference-data/metadata           | ContextInvalid      | 400        | Tenant is not supported |
	| /api/reference-data/metadata-bykeyword | ContextNull         | 400        | Tenant is not supported |
	| /api/reference-data/metadata-bykeyword | ContextInvalid      | 400        | Tenant is not supported |
	| /api/reference-data/metadata-by-value  | ContextNull         | 400        | Tenant is not supported |
	| /api/reference-data/metadata-by-value  | ContextInvalid      | 400        | Tenant is not supported |
