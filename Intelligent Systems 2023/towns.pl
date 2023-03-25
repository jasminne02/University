road(krumovgrad,momchilgrad,30).
road(momchilgrad,kurdjali,20).
road(kurdjali,haskovo,70).
road(kurdjali,plovdiv,106).
road(haskovo,plovdiv,90).
road(haskovo,parvomay,50).
road(haskovo,dimitrovgrad,20).
road(haskovo,stz,70).
road(plovdiv,stz,100).
road(plovdiv,parvomay,40).
road(plovdiv,sofia,120).
road(plovdiv,kazanlak,110).
road(stz,kazanlak,40).
road(stz,sofia,220).
road(stz,dimitrovgrad,50).
road(kazanlak,haskovo,110).
road(kazanlak,sofia,180).
road(kazanlak,plovdiv,110).
road(kazanlak,gabrovo,40).
road(gabrovo,stz,80).
road(gabrovo,vtarnovo,50).
road(gabrovo,sevlievo,30).
connected(X,Y,L) :- road(X,Y,L) ; road(Y,X,L).
path(A,B,Path,Len) :-
travel(A,B,[A],Q,Len),
reverse(Q,Path).
travel(A,B,P,[B|P],L) :-
connected(A,B,L).
travel(A,B,Visited,Path,L) :-
connected(A,C,D),
C \== B,
\+member(C,Visited),
travel(C,B,[C|Visited],Path,L1),
L is D+L1.
shortest(A,B,Path,Length) :-
setof([P,L],path(A,B,P,L),Set),
Set = [_|_], % fail if empty
minimal(Set,[Path,Length]).
minimal([F|R],M) :- min(R,F,M).
% minimal path
min([],M,M).
min([[P,L]|R],[_,M],Min) :- L < M, !, min(R,[P,L],Min).
min([_|R],M,Min) :- min(R,M,Min).