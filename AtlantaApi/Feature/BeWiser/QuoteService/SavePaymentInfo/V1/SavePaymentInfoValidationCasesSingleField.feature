#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC05, 06, 09->14, 17

@BeWiser
Feature: Validate Save Payment Info Single Field	
@QuoteServices
Scenario Outline: Validate Save Payment Info request with single fields
	Given User has Save Payment Info body 
	| Property                   | Value                                  |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyBeWiser.json |
	| QuoteRequestBody           | ValidQuoteBeWiserSuccess.json          |
	| ApiVersion                 | V3                                     |
	| ContextName                | BeWiser                                |
	When User send Save Payment Info request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1            | Value                                                          | StatusCode | IsSuccess | Messages                         |
	| SessionId         | null                                                           | 400        | false     | SessionId is required.           |
	| SessionId         | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvv | 400        | false     | SessionId is invalid.            |
	| OptionalExtras    | null                                                           | 200        | true      | Save data successfully           |
	| OptionalExtras    | IK                                                             | 400        | false     | OptionalExtras - Code is invalid |
	| OptionalExtras    | T2                                                             | 200        | true      | Save data successfully           |
	| PaymentMethodType | null                                                           | 400        | false     | PaymentMethodType is required.   |
	| PaymentMethodType | abc                                                            | 400        | false     | PaymentMethodType is invalid.    |
	| PaymentMethodType | abc$%#@ 555                                                    | 400        | false     | PaymentMethodType is invalid.    |
	| PaymentMethodType | payinfull                                                      | 200        | true      | Save data successfully           |

   