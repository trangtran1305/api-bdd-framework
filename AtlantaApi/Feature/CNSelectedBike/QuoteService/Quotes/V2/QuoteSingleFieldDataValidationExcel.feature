#Reference Manual Test Cases: 
#File: \\Resources\QuoteService\Quotes\V2\BeWiserQuoteValidation.xlsx
#Manual testcase: https://bugzilla.harveynash.vn/SD10001914/Document/Testing/Implementation & Execution/Regression Test/API System test/Quote Service Validation/BeWiserQuoteValidation.xlsx
#Sheet: sheet1
#Test Cases: Cover 163 cases

@CNSBike
Feature: QuoteSingleFieldDataValidationExcel
@QuoteServices
Scenario Outline: ValiDate quote API validation excel file
	Given The customer has 
	| Name         | Value1                           |
	| Url          | QuoteApi                         |
	| ApiVersion   | V2                              |
	| Context      | CNSelectBikeContext                      |
	| JsonBodyFile | ValidQuoteCNSBikeValidation.json |
	When The customer call quote validation with <ExcelFile>
	Examples:	
	| ExcelFile                   |
	| CNSBikeQuote.xlsx |
	