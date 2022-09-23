#Reference Manual Test Cases: 
#File: \\Resources\QuoteService\Quotes\V2\BeWiserPartialQuoteValidation.xlsx
#Manual testcase: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Quote Service Validation/BeWiserPartialQuoteValidation.xlsx
#Sheet: sheet1
#Test Cases: Cover 163 cases

@BeWiser
Feature: PartialQuoteSingleFieldDataValidationExcel
@QuoteServices
Scenario Outline: ValiDate Partial quote API validation excel file
	Given The customer has 
	| Name         | Value1                           |
	| Url          | PartialQuote                     |
	| ApiVersion   | V3                               |
	| Context      | BeWiser                          |
	| JsonBodyFile | ValidQuoteBeWiserValidation.json |
	When The customer call quote validation with <ExcelFile>
	Examples:	
	| ExcelFile                          |
	| BeWiserPartialQuoteValidation.xlsx |
	