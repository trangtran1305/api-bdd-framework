@SafeGuardMH
Feature: Get Branding phone
	To get the phone number display for Safeguard

@BrandingServices
Scenario Outline: Get branding of the phone number
	Given User has Reference Branding data body
	  | Property    | Value         |
	  | ApiVersion  | V1            |
	  | ContextName | SafeGuardMH   |
	  | URL         | BrandingPhone |
	When User send branding request to get phone number
	Then Branding respond should return  <StatusCode> and <IsSuccess> and <Message>
	Examples: 
      | StatusCode | IsSuccess | Message                                 |
      | 200        | true      | Get Aggregator information successfully |