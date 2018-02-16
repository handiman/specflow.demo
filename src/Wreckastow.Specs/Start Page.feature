Feature: Start Page
	As the owner of WreckaStow
	I want the front page to list the latest records
	So that someone might want to make a purchase

	As a customer
	I expect the front page to show some records
	Or I'll take my business elsewhere

Background:
	Given these albums are available:
	| Title            | Artist                  | Date Available |
	| Purple Rain      | Prince & The Revolution | 2017-12-24     |
	| Lovesexy         | Prince                  | 2018-02-12     |
	| Plectrumelectrum | 3rdeyegirl              | 2018-01-02     |

Scenario: Show Available Records
	When someone visits the start page
	Then they see these albums:
	| Title            | 
	| Purple Rain      | 
	| Lovesexy         | 
	| Plectrumelectrum | 

Scenario: Show Newest Records First
	When someone visits the start page
	Then they see these albums in this order:
	| Title            |
	| Lovesexy         |
	| Plectrumelectrum |
	| Purple Rain      |
	
	
