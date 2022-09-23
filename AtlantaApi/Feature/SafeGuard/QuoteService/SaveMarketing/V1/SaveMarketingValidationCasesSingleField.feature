#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC39 -> TC40, TC43 -> TC51, 62->77
@SafeGuardMH
Feature: Validate Save Marketing Single Field	
@QuoteServices
Scenario Outline: Validate Save Marketing request with single fields
	Given User has Save Marketing body
	| Property                 | Value                         |
	| SaveMarketingRequestBody | SaveMarketingRequestBody.json |
	| QuoteRequestBody         | ValidQuoteForSGGetQuote1.json |
	| ApiVersion               | V2                            |
	| ContextName              | SafeGuardMH                   |
	When User send Save Marketing request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1                  | Value                                | StatusCode | IsSuccess | Messages                                                                             |
	| SessionId               | null                                 | 400        | false     | SessionId is required.                                                               |
	| SessionId               | 123456                               | 400        | false     | SessionId is invalid.                                                                |
	| AgreementConfirmation   | missing                              | 200        | true      | Save data successfully                                                               |
	| AgreementConfirmation   | null                                 | 400        | false     | Error converting value {null} to type 'System.Boolean'. Path 'AgreementConfirmation' |
	| AgreementConfirmation   | test                                 | 400        | false     | Could not convert string to boolean: test. Path 'AgreementConfirmation'              |
	| AgreementConfirmation   | true                                 | 200        | true      | Save data successfully                                                               |
	| PreferredDeliveryMethod | null                                 | 200        | true      | Save data successfully                                                               |
	| PreferredDeliveryMethod | Get                                  | 400        | false     | PreferredDeliveryMethod is invalid.                                                  |
	| PreferredDeliveryMethod | Email                                | 200        | true      | Save data successfully                                                               |
	| RegNumbers              | null                                 | 200        | true      | Save data successfully                                                               |
	| Email                   | null                                 | 200        | true      | Save data successfully                                                               |
	| Email                   | jordan.knott@autonetinsurance.co.uk  | 200        | true      | Save data successfully                                                               |
	| Email                   | jordan   knottautonetinsurance.co.uk | 400        | false     | Email is invalid.                                                                    |
	| PhoneNumber             | null                                 | 200        | true      | Save data successfully                                                               |
	| PhoneNumber             | 078888888888888                      | 400        | false     | PhoneNumber must be from 9 ~ 14 characters.                                          |
	| PhoneNumber             | 078888888888                         | 200        | true      | Save data successfully                                                               |
	| GroupPartnerContact     | null                                 | 200        | true      | Save data successfully                                                               |
	| GroupPartnerContact     | Y                                    | 200        | true      | Save data successfully                                                               |
	| MarkTel                 | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkTel                 | string                               | 200        | true      | Save data successfully                                                               |
	| MarkSms                 | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkSms                 | string                               | 200        | true      | Save data successfully                                                               |
	| MarkEm                  | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkEm                  | string                               | 200        | true      | Save data successfully                                                               |
	| MarkP                   | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkP                   | string                               | 200        | true      | Save data successfully                                                               |
	

	
	 