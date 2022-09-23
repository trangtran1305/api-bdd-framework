#Reference Manual Test Cases: 
#File: \\Resources\QuoteService\Quotes\V2\ANCarClassicPartialQuoteValidation.xlsx
#Manual testcase: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Quote Service Validation/ANCarClassicPartialQuoteValidation.xlsx
#Sheet: sheet1
#Test Cases: Cover 163 cases

@AutonetVan
Feature: PartialQuoteSingleFieldDataValidationExcel V3
@QuoteServices
Scenario Outline: ValiDate Partial quote API validation excel file
	Given The customer has 
	| Name         | Value1                                |
	| Url          | PartialQuote                          |
	| ApiVersion   | V3                                    |
	| Context      | AutonetVan                          |
	| JsonBodyFile | ValidQuoteAutonetVanValidation.json |
	When The customer call quote validation with <ExcelFile>
	Examples:	
	| ExcelFile                               |
	| AutonetVanPartialQuoteValidation.xlsx |
	