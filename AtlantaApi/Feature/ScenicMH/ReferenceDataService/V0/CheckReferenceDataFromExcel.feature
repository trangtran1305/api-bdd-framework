@ScenicMH
Feature: Check the data return on Response

@ReferenceDataServices
Scenario Outline: Check the data return on Response
Given User has Reference Data body
	| Property                 | Value                     |
	| ReferenceDataRequestBody | MetadataBodyScenicMH.json |
	| ApiVersion               | V0                        |
	| ContextName              | ScenicMotorHome           |
	When User send metadata request with excel file <ExcelFileName>
	Examples:
	| ExcelFileName                |
	| Senic MH_Reference data.xlsx |
