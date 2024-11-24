@setup_feature
Feature: TestCRUD

Scenario: Create a new booking
    Given I have a valid booking payload
    When I send a POST request to "/booking"
    Then I receive a 200 status code

Scenario: Get the booking by ID
    Given I have the booking ID of an existing booking
    When I send a GET request to "/booking/{id}"
    Then I receive a 200 status code for get by ID

Scenario: Update the existing booking
    Given I have the booking ID of an existing booking for update
    And I have an updated booking payload
    When I send a PUT request to "/booking/{id}"
    Then I receive a 200 status code for update

Scenario: Delete the existing booking
    Given I have the booking ID of an existing booking for delete
    When I send a DELETE request to "/booking/{id}"
    Then I receive a 201 status code for delete