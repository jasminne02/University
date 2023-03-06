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

Какво има Иван?
?- has(ivan,X).

2. Кой има кола?
?-has(X,car(_,_)).

3. Кой каква марка колa има?
?-has(X,car(Y,_)).

4. Има ли двама с червени
коли?
?-has(X,car(_,red)),
has(Y,car(_,red)), X\=Y, !.

5. Има ли двама с еднакъв
цвят коли?
?-has(X,car(_,Z)),
has(Y,car(_,Z)), X\=Y, !.

6. Кой има в банковата си
сметка толкова пари,
колкото струва домът му?
?-has(X,bank_account(Y)),
(has(X,flat(_,_,price(Y)));
has(X,house(_,_,price(Y)))).

7а) Предикат, определящ
кой какъв дом има (домът е
цяла структура)
?- home(X,U).
home(X,Y):-has(X,Y),
(Y=flat(_,_,_); Y=house(_,_,_)).

б) Кой какъв дом има?

8а) Предикат определят
големите домове – с площ
повече от 200 кв.м., и
техните собственици.

big_home(X,Y):-has(X,Y),
(Y=flat(_,space(Z),_);
Y=house(_,space(Z),_)), Z>200.

б) Кой има голям дом?
?- big_home(X,_).

9а) Предикат, задаващ кой е богат – ако има къща или
апартамент на цена повече от 30000, яхта, кола и банкова
сметка над 2000000. (извежда по веднъж всеки богат-one)
rich(X):-has(X,yacht), has(X,car(_,_)), has(X,bank_account(Z)),
Z>2000000, (has(X,house(_,_,price(Y)));
has(X,flat(_,_,price(Y)))), Y>30000.

б) Кой е богат?
?- rich(X).

10а) Предикат,
определящ колко е най-
голямата банкова
сметка.
biggest_account(Z):-
has(_,bank_account(Z)), \+
(has(_,bank_account(C)),
C>Z), !.

б) Колко е най-голямата
сметка?
?-biggest_account(X).