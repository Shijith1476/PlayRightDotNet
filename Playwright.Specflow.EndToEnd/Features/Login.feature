Feature: Demo Features


@regression
Scenario: Naviagte to Demo Application and Submit the user details
	Given I navigate to Demo Application
	 When I enter following details
	    | FullName  | Email        | CurrentAddress | PermanentAddress |
	    | Test Name | as@gmail.com | Test Address   | Test Address 2   |
	Then Submit the Form