@SafeGuardMH
Feature: Check the order of data return on Response

@ReferenceDataServices
Scenario Outline: Check the order of data return on Response
Given User has Reference Data body
	| Property                 | Value                     |
	| ReferenceDataRequestBody | MetadataBodyScenicMH.json |
	| ApiVersion               | V0                        |
	| ContextName              | SafeGuardMH               |           
	When User send metadata request to order data with excel file <ExcelFileName>
	Examples:
	| ExcelFileName                      |
	| Safeguard Reference Data v0.4.xlsx |
