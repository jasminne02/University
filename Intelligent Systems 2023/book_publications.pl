%Книга - структура book(Заглавие,Автор,Брой страници)
%Публикация - предикат publication(Книга,Цена)

publication(book('Железният светилник',author('Димитър','Талев'),498),10.90).
publication(book('Осъдени души',author('Димитър','Димов'),456),25.00).
publication(book('Илинден',author('Димитър','Талев'),868),14.00).
publication(book('Ветрена мелница',author('Елин','Пелин'),526),25.00).
publication(book('Песента на колелетата',author('Йордан','Йовков'),560),9.00).
publication(book('Да бъде ден',author('Христо','Смирненски'),450),6.00).
publication(book('Поглед зад очилата',author('Атанас','Далчев'),496),9.00).
publication(book('Хъшове',author('Иван','Вазов'),546),25.00).
publication(book('В полите на Витоша',author('Пейо','Яворов'),362),20.00).
publication(book('Немили-Недраги',author('Иван','Вазов'),366),9.00).
publication(book('През води и гори',author('Емилиян','Станев'),144),4.20).
publication(book('Патиланци',author('Ран','Босилек'),272),12.90).
publication(book('Под Игото',author('Иван','Вазов'),600),10.00).
publication(book('В лунната стая',author('Валери','Петров'),80),17.00).
publication(book('Аз съм българче',author('Иван','Вазов'),80),12.90).
publication(book('Палечко',author('Валери','Петров'),10),10.00).
publication(book('Мамино детенце',author('Любен','Каравелов'),96),4.00).
publication(book('Зайченцето бяло',author('Леда','Милева'),80),12.90).
publication(book('Тютюн',author('Димитър','Димов'),864),40.00).
publication(book('Крадецът на праскови',author('Емилиян','Станев'),112),13.00).
publication(book('Бай Ганьо',author('Алеко','Константинов'),256),5.00).
publication(book('Ян Бибиян',author('Елин','Пелин'),200),4.00).
publication(book('До Чикаго и назад',author('Алеко','Константинов'),120),4.90).
publication(book('Лавина',author('Блага','Димитрова'),344),12.00).
publication(book('Нощем с белите коне',author('Павел','Вежинов'),464),18.00).
nationality(author('Димитър','Талев'),'гр.Прилеп').
nationality(author('Димитър','Димов'),'гр.Ловеч').
nationality(author('Елин','Пелин'),'с.Байлово').
nationality(author('Йордан','Йовков'),'гр.Жеравна').
nationality(author('Христо','Смирненски'),'гр.Кукуш').
nationality(author('Атанас','Далчев'),'гр.Солун').
nationality(author('Иван','Вазов'),'гр.Сопот').
nationality(author('Пейо','Яворов'),'гр.Чирпан').
nationality(author('Емилиян','Станев'),'гр.Велико Търново').
nationality(author('Ран','Босилек'),'гр.Габрово').
nationality(author('Валери','Петров'),'гр.София').
nationality(author('Любен','Каравелов'),'гр.Копривщица').
nationality(author('Леда','Милева'),'гр.София').
nationality(author('Алеко','Константинов'),'гр.Свищов').
nationality(author('Блага','Димитрова'),'гр.Бяла Слатина').
nationality(author('Павел','Вежинов'),'гр.София').
two_books(X):-publication(book(Y,X,_),_),publication(book(Z,X,_),_),Z\=Y.
one_book(X):-publication(book(Y,X,_),_), (publication(book(C,X,_),_)),C\=Y.
same_fname(X,Y):-publication(book(_,X,_),_),publication(book(_,Y,_),_),
    X\=Y,X=author(Z,_),Y=author(Z,_).

% 1. Да се изведът всички книги с цена над 4.90 
% ?-publication(X,Y),Y>4.90.


% 2. Да се изведът всички книги с повече от 200 страници:
% а) книгите да се изведът с отделни променливи за име,автор и страници;
% ?-publication(book(X,Y,Z),_),Z>200.
% б)книгите да се изведът като цели структури.
% ?-publication(X,_),X=book(_,_,Z),Z>200,write(X),nl,fail.


% 3.Да се намери автор с две различни книги.
% two_books(X):-publication(book(Y,X,_),_),publication(book(Z,X,_),_),Z\=Y.
% ?-two_books(X).


% 4.Да се намери автор с точно една книга.
% one_book(X):-publication(book(Y,X,_),_), \+ (publication(book(Z,X,_),_),Z\=Y).
% ?-one_book(X).


% 5.Всички двойки различни автори с едно и също първо име.
% same_fname(X,Y):-publication(book(_,author(Z,X),_),_),
% publication(book(_,author(Z,Y),_),_),X\=Y.
% или
% same_fname(X,Y):-publication(book(_,X,_),_),publication(book(_,Y,_),_),
%    X\=Y,X=author(Z,_),Y=author(Z,_).
% ?-same_fname(X,Y).
 
 
% 6.Заглавията на книги автори родени в гр.София.
% ?-publication(book(X,Y,_),_),nationality(Y,'гр.София'),write(X),nl,fail.
% 7.Да се намери най-евтината книга.
% ?-publication(X,Y),\+ (publication(_,Z),Z<Y).
