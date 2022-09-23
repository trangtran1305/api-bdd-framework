#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: Vehicle_037 ~ Vehicle_041
@CNBike
Feature: Check Response format after run successfully Search Vehicle service

@VehicleServices
Scenario Outline: Check Response format after run successfully Search Vehicle with 2 param	
	Given User has vehicle body
	| Property           | Value                                   |
	| VehicleRequestBody | VehicleSearchBody2ParametersCNBike.json |
	| ApiVersion         | V1                                      |
	| ContextName        | CNBikeContext                           |
	When User send Vehicle Search service normal case with <Make>
	Then The Vehicle response format <TypeOfValidate>
	Examples: 
	 | TypeOfValidate    | Make  |
	 | VehicleList       |       |
	 | YearOfManufacture |       |
	 | FuelTypes         |       |
	 | Transmission      |       | 

@VehicleServices
Scenario Outline: Check Response format after run successfully Search Vehicle service	
	Given User has vehicle body
	#Given User has vehicle body
	| Property           | Value                        |
	| VehicleRequestBody | VehicleSearchBodyCNBike.json |
	| ApiVersion         | V1                           |
	| ContextName        | CNBikeContext                |
	When User send Vehicle Search service normal case with <Make>
	Then The Vehicle response format <TypeOfValidate>
	Examples: 
	 | TypeOfValidate | Make  |
	 | VehicleList    | HONDA |
