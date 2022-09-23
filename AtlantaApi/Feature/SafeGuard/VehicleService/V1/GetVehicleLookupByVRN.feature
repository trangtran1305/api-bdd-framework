@SafeGuardMH
Feature: GetVehicleLookupByVRN
	Vehicle lookup by VRN

Background: 
	Given A request vehicle lookup by VRN has
	  | Properties | Value            |
	  | Context    | SafeGuardMH      |
	  | APIVersion | V1               |
	  | Endpoint   | VehicleLookupVRN |

@VehicleServices
Scenario Outline: Get vehicle lookup by VRN Succesffully
		The VRN is valid value
	When An user sends the request with Reg Number is "<VRN>"
	Then The response should have <StatusCode>, "<Message>", "<Make>", "<Model>", "<Engine>", "<FromToYear>", "<ManufactureDate>", "<Fuel>", "<Transmission>", "<AbiCode>", "<CdlCode>", "<RegistrationDate>"
	 Examples: 
	 | VRN     | StatusCode | Message          | Make | Model           | Engine | FromToYear | ManufactureDate | Fuel | Transmission | AbiCode  | CdlCode | RegistrationDate |
	 | PX05JNO | 200        | Get successfully | FORD | TRANSIT 260 SWB | 1998   | 2001-2006  | 2005-05-01      | D    | M            | 90309975 | FO4650  | 2005-05-01       |

@VehicleServices
Scenario Outline: Get vehicle lookup by VRN Invalid
		1. The VRN is empty
		2. The VRN is not existing value
	When An user sends the request with Reg Number is "<VRN>"
	Then The response should have <StatusCode>, "<Message>"
	Examples: 
	  | VRN     | StatusCode | Message                                    |
	  |         | 400        | RegistrationNumber is required.            |
	  | PX05JNK | 500        | Value cannot be null. (Parameter 'source') |
