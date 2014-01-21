Feature: MainPage
	In order to use ExampleApp
	As a WP8 user
	I want to be read the main page

Background: 
	Given my app is clean installed and running

Scenario: Main Page loads after a few seconds
	Then I wait for the text "Input" to appear
	Then I see the control "Input" contains ""
    Then I see the control "Output" contains ""
	When I enter "Hello World" into the control "Input"
	Then I see the control "Output" contains "Hello World"
	And take a picture

Scenario: Main Page loads again after a few seconds
	Then I wait for the text "Input" to appear
	Then I see the control "Input" contains ""
    Then I see the control "Output" contains ""
	Then I enter "Hello World" into the control "Input"
	Then I see the control "Output" contains "Hello World"
	And take a picture

