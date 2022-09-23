@CNBike
Feature: Check the order of data return on Response

@ReferenceDataServices
Scenario Outline: Check the order of data return on Response
Given User has Reference Data body
	| Property                 | Value                   |
	| ReferenceDataRequestBody | MetadataBodyCNBike.json |
	| ApiVersion               | V0                      |
	| ContextName              | CNBikeContext           |
	When User send metadata request to order data with excel file <ExcelFileName>
	Examples:
	| ExcelFileName               |
	| CNBike - Reference data.xlsx |
