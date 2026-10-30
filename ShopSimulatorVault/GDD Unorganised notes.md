Charity Shop Simulator
Player is the manager of a charity shop
Customers come in, donate items, buy stock
The player take the donations, chooses whether to clean them, puts them out in the shop
When the customer is buying, the player has to complete a minigame:  
- bar with moving indicator
- when the indicator is over green section, the player needs to press space
- the better the player does, the more the item sells for
3D PC game
first person
unity with C# because thats what ive learned in college
day system that gets more difficult each day
i want a leaderboard system (total days before failure) that uses the inbuilt unity game service
every night the player pulls a card that has a challenge ie sell 3 plates, make 100€, rent increases by 150€, decorations were damaged (customers are less patient, need to spend money the following day to replace)
failure is when the player fails these challenges or fails to pay the weekly rent.
every night the player can choose to buy things for the shop ie decorations (to boost customer patience, shelves (to add more storage for donations), cleaning supplies for donations
each item has a baseline price, cleaning increases this baseline price
cleaning is scored between 1 and 2. this score is then used as a multiplier for baseline price. ie if the player scores 1.7, the baseline price is multiplied by 1.7. this means the highest score doubles the price.
you are the manager for a new location for a chain or charity shops.
no explicit win state, beat others high scores for most days 'survived'
4 diffent donation types
3 customer temprements (patient, normail, impatient)
2 decorations
1 shelves type
the selling minigame is a haggling system 
- the multiplier goes between 0.5x and 2.5x 
- the final score is baseline x cleaning x selling x patience
4 donation types:
- plates - base 5€
- books - base 1€
- t-shirts - base 7€
- balls - base 3€
Customers:
- each customer has a patience score 
- multiplier between 1.5x and 0.5x based on how long the player took to see them
- impatient customers time goes down fastest
- some customers put donations in a donation bin and then they buy something, not all customers donate
Decoration:
- plant - patience score lower bounds is increased by 0.05 ie 2 plants make score between 1.5x and 0.6x. this caps when lower bounds reach 1x
- statue - patience score waits 4 seconds before decreasing from 1.5x multiplier
Shelves
- can hold 12 more items
the shop floor is split into a grid where, inthe morning before opening, the player can place down decorations and shelves
Cards
- Selling cards
	- ie sell [[[number]]] [[[optional: clean/dirty]]] [[[donation type]]] 
	- number between 2 and 5
	- clean/dirthy/either has a 1/3 split
	- donation is random
- Rent cards
	- ie rent is increased by€ 10 - €45
Starting money  = 0
start with 8 uses of cleaning supplies
7 days in a week
no. customers increase every day 
- start at 4 
- every third day no. cust increases by 2
rent starts at €920 increased by €50 per week
cleaning product is 15€ per 5 uses
cards are drawn on day 2 and 4
cards are judged at the end of the week
day ends when all customers are served
layout starts with 1 shelf
no time limit per day
player can only move during the decorating process, otherwise fixed camera view
player has to sort through donation box (donation or rubbish) 
