#Reference Manual Test Cases: 
#File: Atlanta_API_System Test.xlsx
#Sheet: Recall quote
#Test Case ID: 

Feature: Validation Recall Quote request

@QuoteServices
Scenario Outline:  Validation Recall Quote request
	Given User has recall body 
	| Property          | Value                            |
	| QuoteRequestBody  | ValidQuoteForRecallScenicMH.json |
	| RecallRequestBody | RecallBodyScenicMH.json          |
	| ApiVersion        | V2                               |
	| ContextName       | ScenicMotorHome                  |
	When User send recall service with data change
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Recall response returns <StatusCode> and <Messages>
	Examples:
		| Level1       | Value                | StatusCode | Messages                                                                    |
		| WebReference | null                 | 400        | WebReference is required.                                                   |
		| WebReference | 58855-42814-86330faf | 400        | WebReference is invalid.                                                    |
		| WebReference | 58855-42814-86330    | 400        | WebReference is invalid.                                                    |
		| PostCode     | GIRb 0AA             | 400        | This is not a recognized UK postcode format.                                |
		| PostCode     | EC2N4AY              | 200        | Get quote successfully                                                      |
		| PostCode     | ec2n 4ay             | 200        | Get quote successfully                                                      |
		| PostCode     | ec2n 4ay             | 200        | Get quote successfully                                                      |
		| PostCode     | EC2N 4AY             | 200        | Get quote successfully                                                      |
		| PostCode     | null                 | 400        | PostCode is required.                                                       |
		| DateOfBirth  | missing              | 400        | DateOfBirth is required.                                                    |
		| DateOfBirth  | null                 | 400        | Error converting value {null} to type 'System.DateTime'. Path 'DateOfBirth' |
		| DateOfBirth  | 2008-01-10           | 400        | DateOfBirth must be between 16~125.                                         |
		| DateOfBirth  | 1894-11-14           | 400        | DateOfBirth must be between 16~125.                                         |
		| DateOfBirth  | 1959-16-16           | 400        | Could not convert string to DateTime: 1959-16-16. Path 'DateOfBirth'        |
		| DateOfBirth  | 1970-01-01           | 200        | Get quote successfully                                                      |
		| WebReference | 123-324-456          | 400        | Web Reference is invalid                                                    |
		| PostCode     | M1 1AE               | 400        | Web Reference is invalid                                                    |
		| DateOfBirth  | 1971-01-01           | 400        | Web Reference is invalid                                                    |
