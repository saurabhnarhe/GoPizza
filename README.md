# 🍕 GoPizza 
The founders of GoKloud turned out to be big time foodies and hence opted to start an alternate business in the area of their interest which is an online Pizza Store. You have to help them out with some code which can help them in this business.

## What are the expectations
- The solution to the problem could be done in any programming language of your choice, however preferably in the expertise you have i.e. Java/Scala/Nodejs/C# so on and so forth.
- The solution must adhere to clean coding principles, if not all but at least below:
    - Execution flow of the entire application should be evident
    - Objects and their collaborations/ relationships should not be too complex
    - Classes and Methods should have clear responsibilities and should be testable as unit and integration
    - Purpose of expressions and variables should be easy to understand
    - Tests are easy to understand and modify when required
    - Clear and concise public APIs(methods and definitions)
- The solution should also try to stick to SOLID design principles.
- A ReadMe file which explains the details of the project and the steps to execute/ test it against the given parameters.
- We would prefer the solution to be posted over github or shared with a .git file as we also would be interested in assessment of git usage.

## What is not expected
- The exercise does not aim to evaluate the expertise on any particular framework like spring boot/ express etc. hence we do not expect something like a web based restful API as a solution to this.

## Problem Statement
GoPizza offers a variety of pizzas to its customers with a wide set of customizations that the customers can order based on their preferences.

Below are the 5 items which they currently serve to their customers,
1. Veggie Supreme(Cheese, chicken, capsicum, onion, red paprika, mushroom) - Price 250
2. Chicken Supreme(Cheese, chicken, meatball) - Price 300
3. Double Chicken feast(Cheese, chicken, capsicum, onion, red paprika) - Price 350
4. Veg Farmhouse(Cheese, capsicum, onion, red paprika, black olives, corn) - Price 300
5. Margarita(Cheese) - Price 225

##### Toppings
- Cheese: Price 20
- Olives: Price 20
- Onion: Price 10
- Chicken: Price 25
- Cottage Cheese: Price 15

##### Bread Types

- Regular (Default)
- Thin crust: Price 20
- Cheese crust: Price 25
- Pan: Price 10

The 5 items served could be served with a default price that is tagged against each of the pizza mentioned, or a user can actually order it with added toppings mentioned in the toppings section. The price would add up in the pizza as a final price. Alternatively a user can also request to remove a topping from the default menu and the price for that particular topping would then be reduced from the default menu item.

The solution should take orders in the form of a string array something like [“Chicken Supreme, cheese, olives, Thin Crust”,“Veggie Supreme, cheese, -onion”] and should return the total value of the order.

For storing the menu options and the prices in memory objects like Map or Enum etc. could be used.

Also a user can mention the bread type the cost of which would be then calculated based on the selection.

### Examples

***1. “Chicken Supreme, cheese, olives, Thin Crust”***

So in this particular case
Default price for Chicken Supreme: 300
Price of added cheese topping: 20
Price of Thin Crust: 20
The price of this order would then become: 300+20+20+20 = 360

***2. “Veggie Supreme, cheese, -onion”***

Default price for Chicken Supreme: 250
Price of added cheese topping: 20
Price of Onion removed: 10
The price of this order would then become: (250+20)-10 = 260

*3. **“Double Chicken feast, cheese, cottage cheese, olives, Thin Crust, -onion”***

Default Price for Double Chicken feast: 350
Price of added cheese topping: 20
Price of added Cottage cheese topping: 15
Price of added olives topping: 20
Price of Thin Crust: 20
Price of Onion removed: 10
The price of this order would then become: (350+20+15+20+20)-10 = 415


## How to run the solution
Open terminal at ./GoPizza and run `dotnet run`

## How to run the tests
Open terminal at ./GoPizza.Fixture and run `dotnet test`
