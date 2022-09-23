#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#TCID: ReferenceData_TC05

@BeWiser
Feature: Check the order of data return on Response

@ReferenceDataServices
Scenario Outline: Check the order of data return on Response
Given User has Reference Data body
	| Property                 | Value                         |
	| ReferenceDataRequestBody | MetadataBodyBeWiser.json |
	| ApiVersion               | V0                            |
	| ContextName              | BeWiser                  |
	When User send metadata request to order data with excel file <ExcelFileName>
	Examples:
	| ExcelFileName               |
	| BeWiser_Reference data.xlsx |