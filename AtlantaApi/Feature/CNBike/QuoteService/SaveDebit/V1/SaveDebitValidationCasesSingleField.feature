#Refer manual test cases: Atlanta_APi_System Test
#Sheet PrePurchase - TC105->TC107, TC129-TC131, TC108-109, TC113-123, TC126-127
#Refer file https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Atlanta_API_System Test.xlsx
#Sheet Prepurchase; TCID: Prepurchase_TC87,88,91->105
@CNBike
Feature: Validate Save Debit Single Field	
@QuoteServices
Scenario Outline: Validate Save Debit request with single fields
	Given User has Save Debit body 
	| Property             | Value                               |
	| SaveDebitRequestBody | SaveDebitRequestBodyCNBike.json     |
	| QuoteRequestBody     | ValidQuoteForPrepurchaseCNBike.json |
	| ApiVersion           | V1                                  |
	| ContextName          | CNBikeContext                       |
	When User send Save Debit request
	| Level1   | Value   |
	| <Level1> | <Value> |
	Then Save Debit response returns <StatusCode> and <IsSuccess> and <Messages>
	Examples:
	| Level1        | Value                                                                                                            | StatusCode | IsSuccess | Messages                                                     |
	| SessionId     | null                                                                                                             | 400        | false     | SessionId is required.                                       |
	| SessionId     | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvv                                                   | 400        | false     | SessionId is invalid.                                        |
	| AccountName   | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| AccountName   | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 4354654365746587698796800           | 400        | false     | AccountName cannot be over 100 characters.                   |
	| AccountName   | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 43546543657465876987968             | 200        | true      | Save data successfully                                       |
	| AccountNumber | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| AccountNumber | Accountname54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 4354654365746587698796800           | 400        | false     | AccountNumber cannot be over 100 characters.                 |
	| AccountNumber | 13537846                                                                                                         | 200        | true      | Save data successfully                                       |
	| SortCode      | 54c484ac-303e-4119-ade3-7b83d026725a1232323vvvvvvvvvvvvvvvvvvvddd 4354654365746587698796800hhjjvjhhjgvjhmcghcgcg | 400        | false     | SortCode cannot be over 100 characters. SortCode is invalid. |
	| SortCode      | 43-54-65-43-65-74-65-87-69-87-96-80-43-54-65-43-65-74-65-87-69-87-96-80-43-54-65-43-65-74-65-87-69-8             | 400        | false     | SortCode is invalid.                                         |
	| SortCode      | 20-51-32                                                                                                         | 200        | true      | Save data successfully                                       |
	| SortCode      | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| Card          | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| Card          | POLHDEC                                                                                                          | 200        | true      | Save data successfully                                       |
	| Email         | null                                                                                                             | 200        | true      | Save data successfully                                       |
	| Email         | jordan   .knottautonetinsurance.co.uk                                                                            | 400        | false     | Email is invalid.                                            |
	| Email         | jordan.knott@autonetinsurance.co.uk                                                                              | 200        | true      | Save data successfully                                       |