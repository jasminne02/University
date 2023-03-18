% 3. Пресмятане на степен: x**n  n>0 X**n=X*X**(n-1)
stepen(X,1,X):-!. % stepen(X,0,1).
stepen(X,N,Y):-X > 1, N1 is N-1, stepen(X,N1,Y1), 
    				Y is Y1*X.
% 4. Отпечатване на екрана на целите числа от 1 до зададено число.
w(0).
w(X):- X > 0, Y is X-1, w(Y), write(X), nl.

%5.
prd(X,N,S):-N > 0, (N mod 2 =:= 1,!, N1 is N-1,
    			pr(X,N1,S);pr(X,N,S)).
pr(_,0,0).
pr(X,N,S):- N1 is N-2, pr(X,N1,S1), S is S1+(X+N)**2.

%6. NOD
nod(X,0,X):-!. % nod(X,Y,Y):-X mod Y =:=0, !.
nod(X,Y,D):- R is X mod Y, nod(Y,R,D).

% 7. fibonachi
fib(0,1).
fib(1,1).
fib(N,X):-N > 1, P 	is N-1, PP is N-2,
    		fib(P,Z), fib(PP,Y), X is Z+Y.
    