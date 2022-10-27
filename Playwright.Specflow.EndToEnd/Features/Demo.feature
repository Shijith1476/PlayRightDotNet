Feature: Demo Features


@regression
Scenario: Naviagte to Demo Application and Submit the user details
	Given I enter following User details
	    | FullName  | Email        | CurrentAddress | PermanentAddress |
	    | Test Name | as@gmail.com | Test Address   | Test Address 2   |
	Then Submit the Form and verify the details
	| FullName  | Email        | CurrentAddress | PermanentAddress |
	    | Test Name | as@gmail.com | Test Address   | Test Address 2   |

@regression
Scenario: Naviagte to Demo Application and Verify the Checkbox
	Given I click the Home checkbox option
	Then Verify the details 'You have selected'