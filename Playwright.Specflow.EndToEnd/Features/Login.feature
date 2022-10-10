Feature: Login

@regression
Scenario: Login to Bazar Application
	Given I navigate to Seller Portal Application
	When I enter following login details
	    |Email                         |Password    |
		|amitha.ma+1@experionglobal.com|Password@123|
	Then I see the May Bazar Dashboard
