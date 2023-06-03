Feature: AuditsAddSection

@section
Scenario: Successfully Add Feature
	Given I am on the Advance application audits page
	When I click section tab
	And I click Add Section button
	Then Add Section Form is displayed
	When I fill data with Tiuleanu Title New 5, 1, Description
	And I Click save bytton
	Then Audit Section is Saved
	