Feature: SingleItemJoin
	

Scenario: Lose without bidding
	When an auction is selling an item
		And an Auction Sniper has started to bid in that auction
	Then the auction will receive a Join request from the Auction Sniper
	When an auction announces that it is Closed
	Then the Auction Sniper will show that it lost the auction
