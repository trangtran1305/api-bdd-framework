#Reference Manual Test Cases: 
#File: Atlanta_API_System Test_BaseLine_20.4.xlsx
#Sheet: Pre-purchase
#TCID: TC87->TC88, TC91-> TC 93, TC95, TC96, TC98->TC105, TC111
@ScenicMH
Feature: Validate Save Debit Single Field	
@QuoteServices
Scenario Outline: Validate Save Debit request with single fields
	Given User has Save Debit body 
	| Property             | Value                             |
	| SaveDebitRequestBody | SaveDebitRequestBodyScenicMH.json |
	| QuoteRequestBody     | ValidQuoteForScenicMH.json        |
	| ApiVersion           | V2                                |
	| ContextName          | ScenicMotorHome                   |
	When User send Save Debit request
	| Level2   | Value   |
	| <Level2> | <Value> |
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1 | Level2        | Value                                                                                                 | StatusCode | IsSuccess | Messages                                                     |
	| Debit  | SessionId     | null                                                                                                  | 400        | false     | SessionId is required.                                       |
	| Debit  | SessionId     | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvv                                        | 400        | false     | SessionId is invalid.                                        |
	| Debit  | AccountName   | null                                                                                                  | 200        | true      | Save data successfully                                       |
	| Debit  | AccountName   | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 435465436574658769879680 | 400        | false     | AccountName cannot be over 100 characters.                   |
	| Debit  | AccountName   | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323                                                | 200        | true      | Save data successfully                                       |
	| Debit  | AccountName   | Accountname54c484ac                                                                                   | 200        | true      | Save data successfully                                       |
	| Debit  | AccountNumber | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 435465436574658769879680 | 400        | false     | AccountNumber cannot be over 100 characters.                 |
	| Debit  | AccountNumber | 13537846                                                                                              | 200        | true      | Save data successfully                                       |
	| Debit  | SortCode      | 12345678951234567895123456789512345678951234567895123456789512345678951234567895123456789512345678951 | 400        | false     | SortCode cannot be over 100 characters. SortCode is invalid. |
	| Debit  | SortCode      | 43-54-65-43-65-74-65-87-69-87-96-80-43-54-65-43-65-74-65-87-69-87-96-80-43-54-65-43-65-74-65-87-69-8  | 400        | false     | SortCode is invalid.                                         |
	| Debit  | SortCode      | 20-51-32                                                                                              | 200        | true      | Save data successfully                                       |
	| Debit  | SortCode      | null                                                                                                  | 400        | false     | Something went wrong                                         |
	| Debit  | Card          | null                                                                                                  | 200        | true      | Save data successfully                                       |
	| Debit  | Card          | POLHDEC                                                                                               | 200        | true      | Save data successfully                                       |
	| Debit  | Email         | null                                                                                                  | 200        | true      | Save data successfully                                       |
	| Debit  | Email         | jordan   .knottautonetinsurance.co.uk                                                                 | 400        | false     | Email is invalid.                                            |
	| Debit  | Email         | jordan.knott@autonetinsurance.co.uk                                                                   | 200        | true      | Save data successfully                                       |