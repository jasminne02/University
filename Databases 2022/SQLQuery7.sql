/*Изведете имената на служителите и броя на поръчките, които са обработили. 
Като в резултат да се покажат само такива  с повече от 5 поръчки. Сортирайте 
резултатния набор спрямо броя в низходящ ред.*/

SELECT (EMPLOYEES.FNAME + ' ' + EMPLOYEES.LNAME) AS name, COUNT(ORDERS.ORDER_ID) AS orders_count
FROM EMPLOYEES
INNER JOIN ORDERS ON EMPLOYEES.EMPLOYEE_ID = ORDERS.EMPLOYEE_ID
GROUP BY EMPLOYEES.FNAME, EMPLOYEES.LNAME
HAVING COUNT(ORDERS.ORDER_ID)  > 5
ORDER BY COUNT(ORDERS.ORDER_ID) DESC




/*Изведете името на отдела, в който са назначени най-много служители*/
SELECT TOP 1 WITH TIES NAME, COUNT(EMPLOYEE_ID) AS TOTAL 
FROM DEPARTMENTS D JOIN EMPLOYEES E 
ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
GROUP BY NAME
ORDER BY TOTAL DESC 

/*Изведете трите страни, в които има най-много клиенти*/
SELECT TOP 3 WITH TIES NAME, COUNT(CUSTOMER_ID) AS TOTAL
FROM COUNTRIES C JOIN CUSTOMERS CU 
ON C.COUNTRY_ID = CU.COUNTRY_ID
GROUP BY NAME
ORDER BY TOTAL DESC 

/*Изведете имената на отделите, имената на страните и регионите, в които се намират*/
SELECT D.NAME AS DEPARTMENT, C.NAME AS COUNTRY, R.NAME AS REGION 
FROM DEPARTMENTS D JOIN COUNTRIES C
ON D.COUNTRY_ID = C.COUNTRY_ID 
JOIN REGIONS R 
ON R.REGION_ID = C.REGION_ID

/*Изведете имената на клиентите, които все още не са правили поръчки до момента*/
SELECT FNAME, LNAME 
FROM CUSTOMERS C LEFT JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
WHERE O.CUSTOMER_ID IS NULL 

/*Изведете клиентите, които са направили поръчки след датата на назначаване на някой от
служителите работещ в отдел 70*/
SELECT FNAME, LNAME 
FROM CUSTOMERS C JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
WHERE ORDER_DATE > ANY (SELECT HIRE_DATE 
						FROM EMPLOYEES
						WHERE DEPARTMENT_ID = 70)

/*Изведете номерата на поръчките, имената на клиента направил поръчката и датата на поръчка. 
Нека датата на поръчка да бъде форматирана в стил 107.*/
SELECT FNAME + ' ' + LNAME AS CUSTOMER, ORDER_ID, CONVERT(VARCHAR, ORDER_DATE, 107) AS ORD_DATE
FROM CUSTOMERS C JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID

/*Изведете всички клиенти, които имат първи имена различни от всички първи имена на служителите
работещи в отдел 80 */
SELECT FNAME + ' ' + LNAME AS CUSTOMER
FROM CUSTOMERS 
WHERE FNAME <> ALL (SELECT FNAME 
					FROM EMPLOYEES
					WHERE DEPARTMENT_ID = 80)










/*Изведете малките имена в базата, които принадлежат и на служител и на клиент*/
SELECT FNAME 
FROM EMPLOYEES
INTERSECT 
SELECT FNAME 
FROM CUSTOMERS

--SAME RESULT
SELECT FNAME 
FROM CUSTOMERS
INTERSECT 
SELECT FNAME 
FROM EMPLOYEES

SELECT DISTINCT FNAME 
FROM EMPLOYEES
WHERE FNAME IN (SELECT FNAME 
				FROM CUSTOMERS)

SELECT DISTINCT FNAME
FROM EMPLOYEES
WHERE FNAME = ANY (SELECT FNAME 
				   FROM CUSTOMERS)

SELECT DISTINCT FNAME 
FROM EMPLOYEES E 
WHERE EXISTS (SELECT * 
			  FROM CUSTOMERS C 
			  WHERE C.FNAME = E.FNAME)

/*Изведете малките имена в базата, които принадлежат на служители и не принадлежат на клиенти*/
SELECT FNAME 
FROM EMPLOYEES
EXCEPT 
SELECT FNAME 
FROM CUSTOMERS

--REVERSE RESULT
SELECT FNAME 
FROM CUSTOMERS
EXCEPT 
SELECT FNAME 
FROM EMPLOYEES

SELECT DISTINCT FNAME 
FROM EMPLOYEES
WHERE FNAME NOT IN (SELECT FNAME 
					FROM CUSTOMERS)

SELECT DISTINCT FNAME 
FROM EMPLOYEES
WHERE FNAME <> ALL (SELECT FNAME 
					FROM CUSTOMERS)

SELECT DISTINCT FNAME 
FROM EMPLOYEES E 
WHERE NOT EXISTS (SELECT * 
				  FROM CUSTOMERS C 
				  WHERE C.FNAME = E.FNAME)

/*Изведете имената на държавите, в които има клиенти и отделите на фирмата*/
SELECT NAME 
FROM COUNTRIES C JOIN CUSTOMERS CU 
ON C.COUNTRY_ID = CU.COUNTRY_ID
INTERSECT 
SELECT C.NAME 
FROM COUNTRIES C JOIN DEPARTMENTS D 
ON D.COUNTRY_ID = C.COUNTRY_ID

/*Изведете имената на държавите, в които има клиенти и няма отдели на фирмата*/
SELECT NAME 
FROM COUNTRIES C JOIN CUSTOMERS CU 
ON C.COUNTRY_ID = CU.COUNTRY_ID
EXCEPT 
SELECT C.NAME 
FROM COUNTRIES C JOIN DEPARTMENTS D 
ON D.COUNTRY_ID = C.COUNTRY_ID

/*Изведете имената на служителите, които са назначени последни във фирмата*/
SELECT FNAME + ' ' +LNAME AS EMPLOYEE
FROM EMPLOYEES
WHERE HIRE_DATE = (SELECT MAX(HIRE_DATE) FROM EMPLOYEES)

/*Изведете номерата, датите и стойността на всички поръчки
направени през 2000 година*/
SELECT O.ORDER_ID, ORDER_DATE, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM ORDERS O JOIN ORDER_ITEMS OI 
ON O.ORDER_ID = OI.ORDER_ID
WHERE YEAR(ORDER_DATE) = 2000
GROUP BY O.ORDER_ID, ORDER_DATE

/*Изведете номерата, датите и стойността на всяка поръчка, като ако всяка поръчка трябва да бъде
платена 7 дни след като е поръчана, изведете и датата, на която трябва да бъде платена.*/
SELECT O.ORDER_ID, ORDER_DATE, SUM(UNIT_PRICE * QUANTITY) AS TOTAL, 
DATEADD(DAY, 7, ORDER_DATE) AS PAID_DATE 
FROM ORDERS O JOIN ORDER_ITEMS OI 
ON O.ORDER_ID = OI.ORDER_ID
GROUP BY O.ORDER_ID, ORDER_DATE

/*Изведете имената на служителите и броя поръчки, които са обработвали. Нека в резултата 
участват и служителите, които не са обработвали порчъки до момента.*/
SELECT FNAME + ' ' + LNAME AS EMPLOYEE, COUNT(ORDER_ID) AS TOTAL 
FROM EMPLOYEES E LEFT JOIN ORDERS O
ON E.EMPLOYEE_ID = O.EMPLOYEE_ID
GROUP BY FNAME + ' ' + LNAME 

/*Изведете продуктите, чиито имена започват с S, имат поне три символа дължина  и завършват на L*/
SELECT NAME 
FROM PRODUCTS
WHERE NAME LIKE 'S___%L' 

/*Изведете имената на клиентите, които са поръчали най-скъпата и най-евтината поръчка
и стойността на съответната поръчка*/
SELECT *
FROM (SELECT TOP 1 WITH TIES FNAME, LNAME, O.ORDER_ID, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM CUSTOMERS C JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
JOIN ORDER_ITEMS OI 
ON OI.ORDER_ID = O.ORDER_ID
GROUP BY FNAME, LNAME, O.ORDER_ID
ORDER BY TOTAL) MIN_ORD
UNION
SELECT *
FROM (SELECT TOP 1 WITH TIES FNAME, LNAME, O.ORDER_ID, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM CUSTOMERS C JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
JOIN ORDER_ITEMS OI 
ON OI.ORDER_ID = O.ORDER_ID
GROUP BY FNAME, LNAME, O.ORDER_ID
ORDER BY TOTAL DESC) MAX_ORD
