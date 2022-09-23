#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet ReferrenData-TC01; TC02; TC44;TC45;TC55,TC56
@SafeGuardMH
Feature: CheckInvalidHeader

@ReferenceDataServices
Scenario Outline: Send metadata request with invalid header
Given User has Reference Data body
	| Property                 | Value                     |
	| ReferenceDataRequestBody | MetadataBodyScenicMH.json |
	| ApiVersion               | V0                        |
	| ContextName              | SafeGuardMH               |           
	When User send invalid metadata request with <Endpoint> and <ContextName>
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples: 
	| Endpoint                               | ContextName     | StatusCode | Message                 |
	| /api/reference-data/metadata           | ContextNull     | 400        | Tenant is not supported |
	| /api/reference-data/metadata           | ContextInvalid  | 400        | Tenant is not supported |
	| /api/reference-data/metadata           | ScenicMotorHome | 200        | Get successfully        |
	| /api/reference-data/metadata-bykeyword | ContextNull     | 400        | Tenant is not supported |
	| /api/reference-data/metadata-bykeyword | ContextInvalid  | 400        | Tenant is not supported |
	| /api/reference-data/metadata-by-value  | ContextNull     | 400        | Tenant is not supported |
	| /api/reference-data/metadata-by-value  | ContextInvalid  | 400        | Tenant is not supported |
