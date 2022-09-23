Feature: GetIdentityServerSuccessfully	
@identityserver
Scenario: User send a GET request to get token
	Given User has valid url for get token "<ApiVersion>"
	When User send a valid request
	Then The identity service response is returned
	| Property   | Value | ApiVersion |
	| StatusCode | 200   | V0         |