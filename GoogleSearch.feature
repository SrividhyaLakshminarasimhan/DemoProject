Feature: GoogleSearch
	Feature to test google search functionality
	Here we will test auto-search as well as navigating to search result


#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120
@SmokeTest
Scenario Outline: Google search for Specflow tutorial
Given I have navigated to google page
And I see the google page fully loaded
When I type the search keyword as
| SearchText           |
| Selenium Tutorial |
Then I should see result for keyword
| SearchText           |
| Selenium Tutorial |