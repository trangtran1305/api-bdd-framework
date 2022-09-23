#Reference Manual Test Cases: 
#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test_BaseLine_5.6UpdateTC.xlsx
#Sheet: Vehicle

@BeWiser
Feature: Check Response format after run successfully Search Vehicle service

#Test Case ID: Vehicle_038 ~ Vehicle_041
@VehicleServices
Scenario Outline: Check Response format after run successfully Search Vehicle service
	Given User has vehicle body
	| Property           | Value                  |
	| VehicleRequestBody | VehicleSearchBody.json |
	| ApiVersion         | V2                     |
	| ContextName        | BeWiser           |
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
	| VehicleRequestBody | VehicleSearchBodyWithModelAndYear.json |
	| ApiVersion         | V2                     |
	| ContextName        | BeWiser			  |
	When User send Vehicle Search service normal case with <Make>
	Then Response format shown <TypeOfValidate>
	Examples: 
	 | TypeOfValidate                                       | Make  | StatusCode | Messages              |
	 | format                                               | HONDA | 200        | Get data successfully |