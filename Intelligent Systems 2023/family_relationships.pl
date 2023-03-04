female(emily). female(victoria). female(anna). female(kim).
male(kris). male(alex). male(daniel). male(bob).

parent(emily, bob). parent(emily, kim). parent(kris, kim). parent(kris, bob).
parent(alex, victoria). parent(alex, daniel). parent(anna, victoria). parent(anna, daniel).

mother(X, Y) :- female(X), parent(X, Y).
father(X, Y) :- male(Y), parent(X, Y).
brother(X, Y) :- male(X), parent(Z, X), parent(Z, Y), X \= Y. 
sister(X, Y) :- female(X), parent(Z, X), parent(Z, Y), X \= Y.
