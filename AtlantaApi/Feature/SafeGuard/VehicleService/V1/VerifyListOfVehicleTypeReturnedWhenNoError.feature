#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Vehicle
#Test Case ID: SMQ-302-API-TC-02,SMQ-302-API-TC-09,SMQ-302-API-TC-16,SMQ-327-API-TC-02
#TC run with 18088
@SafeGuardMH
Feature: Verify List Of manufacturer Type Returned When No Error Manufature

@VehicleServices
Scenario: Verify List Of Vehicle Type Returned When No Error
	Given User has Vehicle Type API Information
	| Property    | Value                                            |
	| DataFile    | Motorhome_VehicleType_Make_Model_DUQ_Matrix.xlsx |
	| ApiVersion  | V1                                               |
	| ContextName | SafeGuardMH                                      |
	When User sends get Vehicle Type request with <RequestType> and <SheetName>
	Then The response should be shown as per Data File using <RequestType>
	Examples: 
	 | RequestType     | SheetName      | StatusCode | Messages              |
	 | vehicletypes    | VehicleTypes   | 200        | Get data successfully |
	 | manufacturer    | Make_Model_DUQ | 200        | Get data successfully |
	 | basevehiclemake | BaseVehicles   | 200        | Get data successfully |
	 | model           | Make_Model_DUQ | 200        | Get data successfully |