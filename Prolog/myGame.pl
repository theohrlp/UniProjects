:- dynamic at/2, on/2, i_am_at/1.   /* Needed to be dynamic so that they can change values on the fly  */

:- retractall(at(_, _)), retractall(i_am_at(_)).

/* The different paths the user can take */
path(car, street) :- on(car_door, interacted).

path(car, street) :- 
        write("You must first open the car_door."), nl,
        !, fail.

path(street, gas_station_out).

path(gas_station_out, gas_station_in) :- on(gas_station_door, interacted).

path(gas_station_out, gas_station_in) :-
        write("You must first open the gas_station_door."), nl,
        !, fail.

path(gas_station_in, gas_station_out).

path(gas_station_out, street).

path(street, car).

/* Starting location */
i_am_at(car).

/* The various objects and items */
on(gas_station_door, gas_station_out).
on(car_door, car).
at(soda, gas_station_in).
at(newspaper, gas_station_in).


/* Introduces to the user the different commands  */
instructions :-
        nl,
        write('Enter commands using standard Prolog syntax.'), nl,
        write('Available commands are:'), nl,
        write('interact(Object).        -- to open a door for example.'), nl,
        write('go(Destination).         -- to go to that destination.'), nl,
        write('take(Item).              -- to take an item.'), nl,
        write('instructions.            -- to see this message again.'), nl,
        write('look.                    -- to look around you again.'), nl,
        write('halt.                    -- to end the game and quit.'), nl,
        nl.

start   :-
	instructions,
        look.
/* Informs the user for his surroundings, i.e. Place, items and onjects he can interact */
look    :-
        nl,
        i_am_at(Place),
        describe(Place),
        nl,
        notice_objects_at(Place),
        notice_items_at(Place),
        nl.


/* Interacts with the doors */
interact(X) :-
        on(X, interacted),
        write("You already did that"),
        nl, !.


interact(X) :-
        i_am_at(Place),
        on(X, Place),
        retract(on(X, Place)),
        assert(on(X, interacted)),
        write("OK"), nl,
        nl, !.


interact(_) :-
        write('No can do.'),
        nl.

take(X) :-
        at(X, in_hand),
        write('You''re already holding it!'),
        nl, !.

/* Interacts with the items */
take(X) :-
        i_am_at(Place),
        at(X, Place),
        retract(at(X, Place)),
        assert(at(X, in_hand)),
        write('OK.'),
        nl, !.

take(_) :-
        write('I don''t see it here.'),
        nl.

/* Informs the user for any items in the area */
notice_objects_at(Place) :-
        at(X, Place),
        write('There is a '), write(X), write(' here.'), nl,
        fail.


notice_objects_at(_).

notice_items_at(Place) :-
        on(X, Place),
        write('There is a '), write(X), write(' here.'), nl,
        fail.


notice_items_at(_).

go(Destination) :-
        i_am_at(Place),
        path(Place, Destination),
        retract(i_am_at(Place)),
        assert(i_am_at(Destination)),
        look, !.



go(_) :-
        write('You can''t go that way.').

/* Declares what to do upon finishing the game */
finish :-
        nl,
        write('The game is over. Please enter the   halt.   command.'),
        nl, !.


/* Describes the different areas */
describe(car) :-
        at(soda, in_hand),
        at(newspaper, in_hand),
        write('You now have your soda and newspaper.'), nl,
        write('You WIN!!!'), nl,
        finish, !.

describe(car) :-
        write('You are in your car and feel a bit thirsty.'), nl,
        write('You also need a newspaper.'), nl,
        write('To your left is the car_door.'), nl,
        write('You see a gas_station across the street.'), nl,
        write('And you decide to go get a soda.'), nl,
        nl.

describe(street) :-
        write("You are now on the street"), nl,
        write('You see the gas_station_out across the street.'), nl,
        nl.

describe(gas_station_out) :-
        write("You are now in front of the gas station"), nl,
        nl.

describe(gas_station_in) :-
        write("You are now inside of the gas station"), nl,
        nl.
