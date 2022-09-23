#Reference Manual Test Cases: 
#File: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Atlanta_API_System Test_BaseLine.xlsx
#Sheet: Pre-purchase
#Test Case ID: Prepurchase_TC87 ,88, 91->105

@BeWiser
Feature: Validate Save Debit Single Field	
@QuoteServices
Scenario Outline: Validate Save Debit request with single fields
	Given User has Save Debit body 
	| Property             | Value                                 |
	| SaveDebitRequestBody | SaveDebitRequestBodyBeWiser.json |
	| QuoteRequestBody     | ValidQuoteBeWiserSuccess.json    |
	| ApiVersion           | V3                                    |
	| ContextName          | BeWiser                          |
	When User send Save Debit request
	| Level2   | Value   |
	| <Level2> | <Value> |
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1 | Level2        | Value                                                                                                            | StatusCode | IsSuccess | Messages                                                     |
	| Debit  | SessionId     | null                                                                                                             | 400        | false     | SessionId is required.                                       |
	| Debit  | SessionId     | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvv                                                   | 400        | false     | SessionId is invalid.                                        |
	| Debit  | AccountName   | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| Debit  | AccountName   | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 4354654365746587698796800           | 400        | false     | AccountName cannot be over 100 characters.                   |
	| Debit  | AccountName   | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 43546543657465876987968             | 200        | true      | Save data successfully                                       |
	| Debit  | AccountNumber | null                                                                                                         | 200        | true      | Save data successfully                                       |
	| Debit  | AccountNumber | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 4354654365746587698796800           | 400        | false     | AccountNumber cannot be over 100 characters.                 |
	| Debit  | AccountNumber | 13537846                                                                                                         | 200        | true      | Save data successfully                                       |
	| Debit  | SortCode      | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| Debit  | SortCode      | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 4354654365746587698796800hhjjvjhhjgvjhmcghcgcg | 400        | false     | SortCode cannot be over 100 characters. SortCode is invalid. |
	| Debit  | SortCode      | 43-54-65-43-65-74-65-87-69-87-96-80-43-54-65-43-65-74-65-87-69-87-96-80-43-54-65-43-65-74-65-87-69-8             | 400        | false     | SortCode is invalid.                                         |
	| Debit  | SortCode      | 20-51-32                                                                                                         | 200        | true      | Save data successfully                                       |
	| Debit  | Card          | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| Debit  | Card          | POLHDEC                                                                                                          | 200        | true      | Save data successfully                                       |
	| Debit  | Email         | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| Debit  | Email         | jordan   .knottautonetinsurance.co.uk                                                                            | 400        | false     | Email is invalid.                                            |
	| Debit  | Email         | jordan.knott@autonetinsurance.co.uk                                                                              | 200        | true      | Save data successfully                                       |