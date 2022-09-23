#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: Vehicle_038 ~ Vehicle_041
@CNSBike
Feature: Check Response format after run successfully Search Vehicle service

@VehicleServices
Scenario Outline: Check Response format after run successfully Search Vehicle service	
	Given User has vehicle body
	| Property           | Value                                  |
	| VehicleRequestBody | VehicleSearchBodyCNSBike.json |
	| ApiVersion         | V2                                     |
	| ContextName        | CNSelectBikeContext                    |
	When User send Vehicle Search service normal case with <Make>
	Then Response format shown <TypeOfValidate>
	Examples: 
	 | TypeOfValidate                                       | Make  | StatusCode | Messages              |
	 | format                                               | HONDA | 200        | Get data successfully |
	 | CompareYearOfManufactors                             |       | 200        | Get data successfully |
	 | ValidateTransmissionTypesByFuelTypes                 |       | 200        | Get data successfully |
	 | VerifyYearOfManufactureFuelTypesAndTransmissionTypes |       | 200        | Get data successfully |

#Test Case ID: Vehicle_042
@VehicleServices
Scenario Outline: Check Response format after run successfully Search Vehicle service with Model and YearOfManufaturers
	Given User has vehicle body
	| Property           | Value                  |
	| VehicleRequestBody | VehicleSearchBodyWithModelAndMakeCNSBike.json |
	| ApiVersion         | V2                     |
	| ContextName        | CNSelectBikeContext    |
	When User send Vehicle Search service normal case with <Make>
	Then Response format shown <TypeOfValidate>
	Examples: 
	 | TypeOfValidate                                       | Make  | StatusCode | Messages              |
	 | format                                               | HONDA | 200        | Get data successfully |