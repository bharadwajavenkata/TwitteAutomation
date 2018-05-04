Feature: To Automate Twitter Application

@Twitter_login
Scenario: Login to Twitter
	Given I open Twitter application
	When I Enter valid Username as "bharadwaja6111993@gmail.com"
	And I Enter valid Password as "bharadwaja!@#$%^&"
	And I click on Login button
    Then I verify login is successfull
	When I Enter Tweet as "Test Tweet 6"
	And Click Tweet
	Then I verify tweet "Test Tweet 6" is posted
	
