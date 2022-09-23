@SafeGuardMH
Feature: Get vehicle look up

@VehicleServices
Scenario: Get vehicle look up information
	Given User has vehicle look up body as
	  | Properties  | Value                    |
	  | ApiVersion  | V2                       |
	  | Context     | SafeGuardMH              |
	  | RequestBody | VehicleSearchBodySG.json |
	When The user sends a request to get vehicle look up
	Then The respond should be <Message> and <StatusCode>
	Examples: 
	  | Message               | StatusCode |
	  | Get data successfully | 200        |
	  