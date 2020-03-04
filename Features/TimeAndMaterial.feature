Feature: TimeAndMaterial
	In order to manage Time and Material record
	As a Tern up portal Admin
	I would like to create, edit, view, and delete tome and material records.

@mytag
Scenario: I'd like to add time using valid details
	Given I have logged In TurnUp portal
	And I navigate to Time and Material Page
	Then I should be able to create time record with valid information

	Scenario: I'd like to update an existing time record with new information
	Given I have logged In TurnUp portal
	And I navigate to Time and Material Page
	Then I should be able to edit time record with updated information

    Scenario: I'd like to Delete an existing time record
	Given I have logged In TurnUp portal
	And I navigate to Time and Material Page
	Then I should be able to Delete time record 

