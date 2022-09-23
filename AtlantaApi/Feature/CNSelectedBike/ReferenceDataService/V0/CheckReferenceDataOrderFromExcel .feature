#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet ReferrenData
#TCID: ReferenceData_TC05

@CNSBike
Feature: Check the order of data return on Response

@ReferenceDataServices
Scenario Outline: Check the order of data return on Response
Given User has Reference Data body
	| Property                 | Value               |
	| ReferenceDataRequestBody | MetadataBodyCNSBike.json   |
	| ApiVersion               | V0                  |
	| ContextName              | CNSelectBikeContext |
	When User send metadata request to order data with excel file <ExcelFileName>
	Examples:
	| ExcelFileName               |
	| CNSB - Reference data.xlsx |