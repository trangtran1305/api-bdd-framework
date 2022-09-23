#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC15, 16

@ANCarClassic
Feature: Validate Save Payment Info Single Field In Case Call To CDL	
@QuoteServices
Scenario Outline: Validate Save Payment Info request with single fields
	Given User has Save Payment Info body 
	| Property                   | Value                                       |
	| SavePaymentInfoRequestBody | SavePaymentInfoRequestBodyANCarClassic.json |
	| QuoteRequestBody           | ValidQuoteANCarClassicSuccess.json          |
	| ApiVersion                 | V3                                          |
	| ContextName                | ANCarClassic                                |
	When User send Save Payment Info request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Save Payment Info response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1            | Value       | StatusCode | IsSuccess | Messages                                                                      |
	| TotalAmountTopay  | missing     | 400        | false     | TotalAmountToPay is incorrectly calculated                                    |
	| TotalAmountTopay  | null        | 400        | false     | Error converting value {null} to type 'System.Int64'. Path 'TotalAmountTopay' |
   