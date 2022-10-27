/*Изведете имената на регионите, както и колко държави има във всеки един от тях. 
Нека в резултатния набор участват и региони, в които няма държави. Сортирайте 
резултатния набор по броя на държавите във възходящ ред.*/


SELECT REGIONS.NAME, COUNT(COUNTRIES.COUNTRY_ID) AS countries_count
FROM REGIONS
LEFT JOIN COUNTRIES ON COUNTRIES.REGION_ID = REGIONS.REGION_ID
GROUP BY REGIONS.NAME
ORDER BY countries_count


SELECT DISTINCT NAME, REGION_ID
FROM REGIONS

SELECT DISTINCT REGION_ID, COUNT(COUNTRY_ID)
FROM COUNTRIES
WHERE REGION_ID = 2
GROUP BY REGION_ID





/*Изведете имената на продуктите и общото количество, в което са били 
поръчани, нека в резултата участват само продуктите, които са поръчани в 
общо количество > 1000. Подредете резултата по общо количество низходящо*/
SELECT NAME, SUM(QUANTITY) AS TOTAL 
FROM PRODUCTS P JOIN ORDER_ITEMS OI 
ON P.PRODUCT_ID = OI.PRODUCT_ID
GROUP BY NAME
HAVING SUM(QUANTITY) > 1000
ORDER BY TOTAL DESC 

/*Изведете имената на служителите и имената на техните преки началници*/
SELECT E.FNAME + ' ' + E.LNAME AS EMPLOYEE, M.FNAME + ' ' + M.LNAME AS MANAGER 
FROM EMPLOYEES E JOIN EMPLOYEES M 
ON E.MANAGER_ID = M.EMPLOYEE_ID

/*Изведете имената на служителите и имената на техните преки началници,
 нека в резултата участват и служителите, които нямат преки началници*/
SELECT E.FNAME + ' ' + E.LNAME AS EMPLOYEE, M.FNAME + ' ' + M.LNAME AS MANAGER 
FROM EMPLOYEES E LEFT JOIN EMPLOYEES M 
ON E.MANAGER_ID = M.EMPLOYEE_ID

/*Изведете имената на служителите, които получават заплата по-голяма от 
заплатата на служител Peter Hall*/
SELECT E.FNAME, E.LNAME 
FROM EMPLOYEES E JOIN EMPLOYEES PH 
ON E.SALARY > PH.SALARY
WHERE PH.FNAME = 'Peter' AND PH.LNAME = 'Hall'

SELECT FNAME, LNAME 
FROM EMPLOYEES
WHERE SALARY > (SELECT SALARY 
				FROM EMPLOYEES
				WHERE FNAME = 'Peter' AND LNAME ='Hall')

/*Изведете имената на регионите, които не са свързани с никоя старана*/
SELECT R.NAME 
FROM REGIONS R LEFT JOIN COUNTRIES C 
ON R.REGION_ID = C.REGION_ID
WHERE C.REGION_ID IS NULL

/*Изведете имената на отделите, имената на техните мениджъри и общия брой на
служителите в дадения отдел*/
SELECT NAME, M.FNAME + ' ' + M.LNAME AS MANAGER, COUNT(E.EMPLOYEE_ID) AS TOTAL_EMPL
FROM DEPARTMENTS D JOIN EMPLOYEES E 
ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
LEFT JOIN EMPLOYEES M 
ON D.MANAGER_ID = M.EMPLOYEE_ID
GROUP BY NAME, M.FNAME + ' ' + M.LNAME 












/*Изведете имената на служителите, които получават заплата по-голяма от 
заплатата на някой от служителите, който работи в отдел 80*/
SELECT FNAME, LNAME 
FROM EMPLOYEES
WHERE SALARY > ANY (SELECT SALARY 
					FROM EMPLOYEES
					WHERE DEPARTMENT_ID = 80)

/*Изведете имената на служителите, които получават заплата по-голяма от 
заплатата на всеки от служителите, който работи в отдел 80*/
SELECT FNAME, LNAME 
FROM EMPLOYEES
WHERE SALARY > ALL (SELECT SALARY 
					FROM EMPLOYEES
					WHERE DEPARTMENT_ID = 80)

/*Изведете всички служители, които са наети след някой от служителите работещи в 
отдел 80*/
SELECT FNAME, LNAME 
FROM EMPLOYEES
WHERE HIRE_DATE > ANY (SELECT HIRE_DATE 
						FROM EMPLOYEES
						WHERE DEPARTMENT_ID = 80)

/*Изведете служителите, които получават заплата по-висока всички минимални заплати, 
дефинирани за заеманите длъжности*/
SELECT FNAME, LNAME 
FROM EMPLOYEES
WHERE SALARY > ALL (SELECT MIN_SALARY 
					FROM JOBS 
					WHERE MIN_SALARY IS NOT NULL)

/*Изведете номерата и датите на всички поръчки, които са направени
 след 12.04.2008*/
 SELECT ORDER_ID, ORDER_DATE
 FROM ORDERS
 WHERE ORDER_DATE > '2008-04-12'

 SELECT GETDATE()

 SELECT ORDER_DATE, YEAR(ORDER_DATE)
 FROM ORDERS
 WHERE ORDER_ID = 2360

 SELECT ORDER_DATE, MONTH(ORDER_DATE)
 FROM ORDERS
 WHERE ORDER_ID = 2360

 SELECT ORDER_DATE, DAY(ORDER_DATE)
 FROM ORDERS
 WHERE ORDER_ID = 2360

/*Изведете имената и датите на назначаване на служителите, като изведете
 датите в стил 109*/
 SELECT FNAME, LNAME, HIRE_DATE, CONVERT(VARCHAR, HIRE_DATE, 109)
 FROM EMPLOYEES

/*Изведете имената, датите на назначаване и месеца, в който е бил назначен
 всеки един служител*/
 SELECT FNAME, LNAME, HIRE_DATE, MONTH(HIRE_DATE) AS [MONTH], 
 DATENAME(MONTH, HIRE_DATE) AS MONTH_NAME
 FROM EMPLOYEES

 /*Изведете имената и годината на назначение на служителя с най-ранно назначение във 
 фирмата*/
 SELECT TOP 1 WITH TIES FNAME, LNAME, HIRE_DATE, YEAR(HIRE_DATE) AS [YEAR]
 FROM EMPLOYEES
 ORDER BY HIRE_DATE 

/*Изведете имената и фамилиите на всички служители, чиято фамилия започва
 с буква М*/
 SELECT FNAME, LNAME 
 FROM EMPLOYEES
 WHERE LNAME LIKE 'M%'

/*Изведете името на длъжността, в която са назначени най-много служители*/
SELECT TOP 1 WITH TIES JOB_TITLE, COUNT(EMPLOYEE_ID) AS TOTAL
FROM JOBS J JOIN EMPLOYEES E 
ON J.JOB_ID = E.JOB_ID
GROUP BY JOB_TITLE 
ORDER BY TOTAL DESC 

/*Изведете разликата в години на служителите с най-ранно и най-късно назначение*/
SELECT DATEDIFF(YEAR, MIN(HIRE_DATE), MAX(HIRE_DATE)) AS [DIFFERENCE] 
FROM EMPLOYEES

/*Изведете имената на държавите, в които има клиенти или отдели на фирмата*/
SELECT NAME 
FROM COUNTRIES C JOIN CUSTOMERS CU 
ON C.COUNTRY_ID = CU.COUNTRY_ID
UNION
SELECT C.NAME 
FROM COUNTRIES C JOIN DEPARTMENTS D 
ON C.COUNTRY_ID = D.COUNTRY_ID

SELECT FNAME 
FROM EMPLOYEES
UNION 
SELECT FNAME 
FROM CUSTOMERS


SELECT FNAME, LNAME  
FROM EMPLOYEES
UNION 
SELECT FNAME, NULL  
FROM CUSTOMERS

SELECT FNAME, LNAME 
FROM EMPLOYEES
UNION 
SELECT FNAME, CAST(CUSTOMER_ID AS VARCHAR)
FROM CUSTOMERS
