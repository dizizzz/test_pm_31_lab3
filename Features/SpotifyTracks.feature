@setup_feature
Feature: SpotifyTracks

Scenario: Get details of a valid track
    Given I have a valid Spotify API token and trackId of an existing track
    When I send a GET request to the "/tracks/{id}" endpoint
    Then the response status code should be 200

Scenario: Get details of an invalid track
    Given I have a valid Spotify API token and and trackId
    When I send a GET request to the "/tracks/{id}" endpoint with invalid id
    Then I receive a 400 status code for with test