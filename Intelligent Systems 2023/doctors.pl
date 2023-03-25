% работа(лекар, лечебно_заведение, трудов_стаж)
работа('Иван Петров', 'Трета поликлиника', 23).
работа('Стоян Драганов', 'Пълмед', 8).
работа('Михаела Тодорова', 'Първа поликлиника', 14).
работа('Илиан Дойков', 'Каридат', 30).
работа('Диана Петкова', 'Първа поликниника', 20).
%.... Допишете още факти по посочения начин
% лекува(лекар, пациент) – описващ отношението лекар-пациент
% пациент(име, възраст)
лекува('Михаела Тодорова', пациент('Иван Иванов', 34)).
лекува('Михаела Тодорова', пациент('Жана Иванова', 34)).
лекува('Стоян Драганов', пациент('Нели Томова', 53)).
лекува('Иван Петров',пациент('Христо Ангелов', 76)).
лекува('Иван Петров',пациент('Камен Димов', 23)).
лекува('Илиан Дойков', пациент('Жана Иванова', 34)).
лекува('Диана Петкова', пациент('Иван Стоянов', 42)).
стаж10(А):-работа(А,_,В), В<10.
пациент_3(А):-лекува(С,А),работа(С, 'Трета поликлиника',В), В>15.
пациент_не1(А):-лекува(В,А), \+ работа(В,'Първа поликлиника',_).
%.... Допишете още факти по посочения начин
/* А) Дефинирайте предикат, 
 който определя лекарите с трудов стаж под 10 години.
 стаж10(А):- работа(А,_,В),В<10.
 или 
 стаж_10(А):-работа(A,C, B),B<10, write(A), nl, fail.
Б) Напишете цел, която извежда като резултати пациенти 
на възраст 34 г., лекувани от д-р Михаела Тодорова.
?- лекува(А, пациент(В,С)), А='Михаела Тодорова',
С=34, write(В), nl, fail.
или 
лекува('Михаела Тодорова', пациент(В,34)), 
write(В), nl, fail.
В) Дефинирайте предикат, определящ имената на пациентите, 
които се лекуват при лекар работещ в Трета поликлиника и 
има стаж под 15 години.
пациент_3(А):-лекува(С,А),работа(С,'Трета поликлиника',В), 
В<15.
Г) Напишете цел, която извежда двама различни пациенти, 
които се лекуват при един и същи лекар.
?- лекува(А,В), лекува(А,С), В\=С.
Д) Дефинирайте предикат, който определя пациентите, 
които не се лекуват в Първа поликлиника.
пациент_не1(А):-лекува(В,А), \+работа(В,'Първа поликлиника',_).
или
пациент_не1(А):-лекува(В,А),работа(В,С,_), 
С\='Първа поликлиника'.
Е) Напишете цел, която извежда пациентите, 
които се лекуват само при един лекар.
?- лекува(А,В), лекува(С,В), А\=С, 
write(В), nl, fail.
*/