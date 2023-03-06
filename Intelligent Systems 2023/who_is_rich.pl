/* База факти с данни за това кой какво има */
has(ivan,yacht).
has(ivan, car(lada,red)).
has(tanya,bank_account(200000)).
has(peter,house(plovdiv, space(160),price(48000))).
has(maria,flat(sofia,space(121),price(32000))).
has(kamen, car(renault,blue)).
has(kamen,bank_account(1005000)).
has(ivan,flat(varna,space(110),price(60000))).
has(ivan,bank_account(2200000)).
has(maria,bank_account(600000)).
has(maria,yacht).
has(elena, car(ford,red)).
has(maria,house(pleven, space(300),price(600000))).
has(maria, car(volvo,black)).
has(peter,bank_account(2000000)).

/*
1. Какво има Иван?  
2. Кой има кола?
3. Кой каква марка колa има?
4. Има ли двама с червени коли?
5. Има ли двама с еднакъв цвят коли?
6. Кой има в банковата си сметка толкова пари, колкото струва домът му?
7. 	а) Предикат, определящ кой какъв дом има (домът е цяла структура)
	b) Кой какъв дом има?
8. 	а) Предикат определят големите домове – с площ повече от 200 кв.м., и техните собственици
    b) Кой има голям дом? 
9. 	а) Предикат, задаващ кой е богат – ако има къща или апартамент на цена повече от 30000, яхта, кола и банкова сметка над 2000000. (извежда по веднъж всеки богат-one)
    b) Кой е богат? 
10. а) Предикат, определящ колко е най-голямата банкова сметка.
    b) Колко е най-голямата сметка?
*/

%1. ?- has(ivan,X).
%

%2. ?-has(X,car(_,_)), write(X), nl, fail.
%
%
%3. ?-has(X,car(Y,_)), write(X), write('  има кола с марка  '), write(Y), nl, fail.
%
%
%4. ?-has(X,car(_,red)), has(Y,car(_,red)), X\=Y, !.

%5. ?-has(X,car(_,Z)), has(Y,car(_,Z)), X\=Y, !.

%6. ?-has(X,bank_account(Y)), (has(X,flat(_,_,price(Y))); has(X,house(_,_,price(Y)))).

%7. 
home(X,Y):-has(X,Y), (Y=flat(_,_,_); Y=house(_,_,_)).
%?- home(X,Y).

%8. 
big_home(X,Y):-has(X,Y), (Y=flat(_,space(Z),_); Y=house(_,space(Z),_)), Z>200.
%?- big_home(X,_).
%
%9. 
rich(X):-has(X,yacht), has(X,car(_,_)), has(X,bank_account(Z)), Z>2000000, (has(X,house(_,_,price(Y))); has(X,flat(_,_,price(Y)))), Y>30000.
%?- rich(X).

%10. 
biggest_account(Z):- has(_,bank_account(Z)), \+ (has(_,bank_account(C)), C>Z), !.
%?- biggest_account(Z).
