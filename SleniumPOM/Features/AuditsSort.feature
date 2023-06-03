Feature: AuditsSort

@Sort
Scenario: Sort Audits Sections Records By Section Title
 
	Given I am on the Advance application audits page
	When I click section tab
	And I click Section Title sorting option
	Then Records are sorted by Section Title

@Sort
Scenario: Sort Audits Sections records by Audit type
	Given I am on the Advance application audits page
	When I click section tab
	And I click Audit type sorting option
	Then Records are sorted by Audit type

@Sort
Scenario: Sort Audits Sections Records By Description
	Given I am on the Advance application audits page
	When I click section tab
	And I click Description sorting option
	Then Records are sorted by Description

@Sort
Scenario: Sort Audits Sections Records By Created By
	Given I am on the Advance application audits page
	When I click section tab
	And I click Created By sorting option
	Then Records are sorted by Created By

@Sort
Scenario: Sort Audits Sections Records By Created At
	Given I am on the Advance application audits page
	When I click section tab
	And I click Created At sorting option
	Then Records are sorted by Created At
