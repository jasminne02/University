f(X, Y, Res) :- Y>X, Res is sqrt(abs(Y*Y - 3*X*X)).
f(X, Y, Res) :- X=Y, Res is X * sin(X).
f(X, Y, Res) :- X>Y, Res is e**X + log10(X-Y).

h(Y, Res) :- Y<(-4), Res is 2*Y*Y / (Y+4).
h(Y, Res) :- Y>=(-4), Y=<4, Res is 0.
h(Y, Res) :- Y>4, Res is log10(Y-4) * e**Y / (Y*Y*Y + sqrt(Y)).

factorial(0, R) :- R is 1.
factorial(N, R) :- N>0, N1 is N-1, factorial(N1, R1), R is R1*N.

k(N, Res) :- factorial(N, R), Res is R/ (N + 2)**2.
