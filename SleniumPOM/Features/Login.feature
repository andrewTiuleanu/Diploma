Feature: Login

A short summary of the feature

@login
Scenario: Login to the Advance application site
	Given I launch Advance Application
	And I click login button
	And I enter following email
	And I click submit button
	And I enter following password
	And I click next button
	And I agree i want to stay in system
	Then Dashboard page appears
