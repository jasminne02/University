%f(X,Y,Res):- -1 <X, X=< 1, Y\=0, Res is log(3+X*X+Y)/(2+Y+X*X).

f(X,Res):- X<2, Y is (2*X+5), Res is sqrt(Y).
f(X,Res):- X>2, Res is (X*X+3)/(2*sqrt(X)).
f(X,Res):- X=2, Res is 0.