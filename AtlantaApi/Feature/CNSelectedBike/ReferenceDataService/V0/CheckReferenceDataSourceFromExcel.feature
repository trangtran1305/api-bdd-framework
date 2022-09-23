#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#TCID: ReferenceData_TC11

@CNSBike
Feature: Check Reference Data Source from excel

@ReferenceDataServices
Scenario Outline: Send metadata request which data returns from reference source not from TransformationDataRules DB
Given User has Reference Data body
	| Property                 | Value               |
	| ReferenceDataRequestBody | MetadataBodyCNSBike.json   |
	| ApiVersion               | V0                  |
	| ContextName              | CNSelectBikeContext |
	When User send metadata request with excel file <ExcelFileName>
	Examples:
	| ExcelFileName              |
	| CNSB - Reference data.xlsx |
