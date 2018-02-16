Feature: Album Details
	As the owner of WreckaStow
	I want to have a details page for each album
	So that potential customer might be more inclined to buy a record

	As a customer
	I would probably expect there to be a details page
	Or I might think WreckaStow is unprofessional

Scenario: Display Album Details
	Given this album is available:
	| Title            | Artist                  | Date Available | Release Date |
	| Purple Rain      | Prince & The Revolution | 2017-12-24     | 1984-06-25   |

	And it has this description
	"""
	Purple Rain (the motion picture soundtrack to the movie Purple Rain) is the sixth full-length 
	studio album by Prince, and the first to be credited to Prince and the Revolution. 
	It was released worldwide in June 1984, a month before the movie, Purple Rain opened in theaters.
	"""

	When someone selects the album from the list on the start page
	Then the page that opens displays the album information
	
