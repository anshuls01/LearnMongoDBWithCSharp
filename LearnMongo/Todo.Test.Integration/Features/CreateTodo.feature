Feature: Create a new Todo Item

A short summary of the feature

@tag1
Scenario: Sucessfully creating a Todo
	Given I have a todo with title "clear backlogs"
	When I send a Post request to "/api/todo"
	Then the response should be sucessful
	And the todo should exist in the database

Scenario: Failing to create a todo item with empty title
	Given I have a todo with title ""
	When I send a Post request to "/api/todo"
	Then the response should be bad request
	And the todo should contain error "Title is required"