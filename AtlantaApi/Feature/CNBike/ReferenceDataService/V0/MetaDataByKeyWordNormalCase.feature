#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#ID: ReferrenData-TC48

@CNBike
Feature: Validate Metadata Key Word request with normal case
@ReferenceDataServices
Scenario Outline: Validate Metadata By Key Word request with normal case
Given User has Reference Data body
	| Property                 | Value                                 |
	| ReferenceDataRequestBody | ReferenceDataByKeyWordBodyCNBike.json |
	| ApiVersion               | V0                                    |
	| ContextName              | CNBikeContext                         |
	When User send Reference Data Metadata request with normal case
	Then The Reference Data response should be shown <StatusCode> and <Message>
	Examples:
	| StatusCode | Message          |
	| 200        | Get successfully |
