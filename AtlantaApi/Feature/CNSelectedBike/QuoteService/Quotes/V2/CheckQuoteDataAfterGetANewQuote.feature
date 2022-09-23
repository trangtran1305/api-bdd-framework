Feature: CheckQuoteDataAfterGetANewQuote

@QuoteServices
Scenario: Check Quote data table in DB after get a new quote
	Given User has quote body
	| Property         | Value                         |
	| QuoteRequestBody | ValidQuoteForPrepurchase.json |
	When User send a quote request <ApiVersion> and <ContextName>
	Then The PerchaseDetails should have the following values with <Path> and <Value>
	Examples: 
	| Path | Value | ApiVersion | ContextName         |
	|      | null  | V2         | CNSelectBikeContext |


	@QuoteServices
Scenario: Check Quote data table in DB after update a quote
	Given User has quote body
	| Property         | Value                         |
	| QuoteRequestBody | ValidQuoteForPrepurchase.json |
	When User update a quote request <ApiVersion> and <ContextName>
	Then The PerchaseDetails should have the following values with <Path> and <Value>
	Examples: 
	| Path | Value | ApiVersion | ContextName         |
	|      | null  | V2         | CNSelectBikeContext |
