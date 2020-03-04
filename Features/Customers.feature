Feature: Customers
	In order to manage Customers
	As a Tern up portal Admin
	I would like to create, edit, view, and delete Customer Records

@mytag
Scenario: I'd like to add Customer using valid details
	Given I log In to TurnUp portal
	And I navigate to Customer Page
	Then I should be able to create Customer record with valid information

	Scenario: I'd like to update an existing Customer record with new information
	Given I log In to TurnUp portal
	And I navigate to Customer Page
	Then I should be able to edit Customer record with updated information

	Scenario: I'd like to Delete an existing Customer record 
	Given I log In to TurnUp portal
	And I navigate to Customer Page
	Then I should be able to Delete Customer record 
