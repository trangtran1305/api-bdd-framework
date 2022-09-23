#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC43->46, 39,40, 47->53,55->58,60->77
@CNBike
Feature: Validate Save Marketing Single Field	
@QuoteServices
Scenario Outline: Validate Save Marketing request with single fields
	Given User has Save Marketing body
	| Property                 | Value                               |
	| SaveMarketingRequestBody | SaveMarketingRequestBodyCNBike.json |
	| QuoteRequestBody         | ValidQuoteForPrepurchaseCNBike.json |
	| ApiVersion               | V1                                  |
	| ContextName              | CNBikeContext                       |
	When User send Save Marketing request
	| Level1   | Level2   | Value   |
	| <Level1> | <Level2> | <Value> |
	Then Save Marketing response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1                  | Level2 | Value                                | StatusCode | IsSuccess | Messages                                                                             |
	| SessionId               |        | null                                 | 400        | false     | SessionId is required.                                                               |
	| SessionId               |        | 123456                               | 400        | false     | SessionId is invalid.                                                                |
	| AgreementConfirmation   |        | null                                 | 400        | false     | Error converting value {null} to type 'System.Boolean'. Path 'AgreementConfirmation' |
	| AgreementConfirmation   |        | test                                 | 400        | false     | Could not convert string to boolean: test. Path 'AgreementConfirmation'              |
	| AgreementConfirmation   |        | true                                 | 200        | true      | Save data successfully                                                               |
	| AgreementConfirmation   |        | missing                              | 200        | true      | Save data successfully                                                               |
	| PreferredDeliveryMethod |        | null                                 | 200        | true      | Save data successfully                                                               |
	| PreferredDeliveryMethod |        | Get                                  | 400        | false     | PreferredDeliveryMethod is invalid.                                                  |
	| PreferredDeliveryMethod |        | Email                                | 200        | true      | Save data successfully                                                               |
	| RegNumbers              |        | null                                 | 200        | true      | Save data successfully                                                               |
	| RegNumbers              |        | []                                   | 200        | true      | Save data successfully                                                               |
	| RegNumbers              | Id     | null                                 | 400        | false     | RegNumbers - Id is required                                                          |
	| RegNumbers              | Id     | 5                                    | 400        | false     | RegNumbers - Id must be 1 ~ 4 is invalid.                                            |
	| RegNumbers              | VRN    | null                                 | 400        | false     | RegNumbers - Vrn is required.                                                        |
	| RegNumbers              | VRN    | GX^#%$#                              | 400        | false     | Regnumbers - vrn - gx^#%$# is incorrect                                              |
	| RegNumbers              | VRN    | Q874 9FP                             | 400        | false     | RegNumbers - Vrn with Q registration plate - q8749fp is unacceptable.                |
	| RegNumbers              | VRN    | GX08NNTmmmmmmmm                      | 400        | false     | Regnumber - vrn - gx08nntmmmmmmmm cannot be over 8 characters                        |
	| Email                   |        | null                                 | 200        | true      | Save data successfully                                                               |
	| Email                   |        | jordan.knott@autonetinsurance.co.uk  | 200        | true      | Save data successfully                                                               |
	| Email                   |        | jordan   knottautonetinsurance.co.uk | 400        | false     | Email is invalid.                                                                    |
	| PhoneNumber             |        | null                                 | 200        | true      | Save data successfully                                                               |
	| PhoneNumber             |        | 078888888888888                      | 400        | false     | PhoneNumber must be from 9 ~ 14 characters.                                          |
	| PhoneNumber             |        | 078888888888                         | 200        | true      | Save data successfully                                                               |
	| GroupPartnerContact     |        | null                                 | 200        | true      | Save data successfully                                                               |
	| GroupPartnerContact     |        | Y                                    | 200        | true      | Save data successfully                                                               |
	| MarkTel                 |        | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkTel                 |        | string                               | 200        | true      | Save data successfully                                                               |
	| MarkSms                 |        | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkSms                 |        | string                               | 200        | true      | Save data successfully                                                               |
	| MarkEm                  |        | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkEm                  |        | string                               | 200        | true      | Save data successfully                                                               |
	| MarkP                   |        | null                                 | 200        | true      | Save data successfully                                                               |
	| MarkP                   |        | string                               | 200        | true      | Save data successfully                                                               |          

	
	 