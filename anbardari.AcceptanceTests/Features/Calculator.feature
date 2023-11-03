Feature: Calculator
	In order to see the members
	As an admin
	I want to be able to watch, sort and filter all the members

Scenario: See latest members
	Given I am an admin
	Then I should be able to see latest 10 joined members

Scenario: Filter the list of active members with specific data and name
	Given I am an admin
	When I have following attributes
		| textbox | from   | to     | isactive |
		| ali     | oneday | twoday | true     |
	Then I should be able to see latest 10 joined members