#Refer manual test cases: ID#29~33
@CNBike
Feature: Check Reference Data Source from excel

@ReferenceDataServices
Scenario Outline: Send metadata request which data returns from reference source not from TransformationDataRules DB
Given User has Reference Data body
	| Property                 | Value                   |
	| ReferenceDataRequestBody | MetadataBodyCNBike.json |
	| ApiVersion               | V0                      |
	| ContextName              | CNBikeContext           |
	When User send metadata request with excel file <ExcelFileName>
	Examples:
	| ExcelFileName              |
	| CNBike - Reference data.xlsx |
