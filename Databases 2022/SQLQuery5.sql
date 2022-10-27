/*изведете всички идентификатори на продуктите които не са поръчвани*/
SELECT *
FROM PRODUCTS
WHERE PRODUCT_ID NOT IN (
      SELECT PRODUCT_ID
	  FROM ORDER_ITEMS
) ORDER BY PRODUCT_ID

/*проверява предното дали е вярно*/
SELECT *
FROM ORDER_ITEMS
WHERE PRODUCT_ID IN (
      SELECT PRODUCT_ID
	  FROM PRODUCTS
	  WHERE PRODUCT_ID NOT IN (
	        SELECT PRODUCT_ID
			FROM ORDER_ITEMS
	  )
) ORDER BY PRODUCT_ID

/*Изведете броя на всички поръчки до момента*/
SELECT COUNT(*) AS TOTAL 
FROM ORDERS

/*Изведете имената на 3-мата служители с най-висока заплата*/
SELECT TOP 3 WITH TIES FNAME, LNAME, SALARY 
FROM EMPLOYEES
ORDER BY SALARY DESC 

/*Изведете номерата на поръчките и тяхната стойност. Нека в резултата да участват поръчки
със себестойност > 20000. Подредете резултата по себестойност низходящо*/
SELECT ORDER_ID, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM ORDER_ITEMS
GROUP BY ORDER_ID 
HAVING SUM(UNIT_PRICE * QUANTITY) > 20000
ORDER BY TOTAL DESC 

/*Изведете клиентите, които са от женски пол*/
SELECT *
FROM CUSTOMERS
WHERE GENDER = 'F'

/*Изведете отделите, които нямат попълнен пощенски код*/
SELECT *
FROM DEPARTMENTS
WHERE POSTAL_CODE IS NULL

/*Изведете длъжността с най-ниска минимална заплата*/
SELECT JOB_TITLE, MIN_SALARY
FROM JOBS 
WHERE MIN_SALARY = ( SELECT MIN(MIN_SALARY)
					 FROM JOBS)

SELECT TOP 1 WITH TIES JOB_TITLE, MIN_SALARY 
FROM JOBS 
WHERE MIN_SALARY IS NOT NULL
ORDER BY MIN_SALARY








/*Изведете имената на държавите и имената на регионите, в които се намират*/
SELECT *
FROM REGIONS

SELECT *
FROM COUNTRIES

SELECT REGIONS.NAME AS REGION, COUNTRIES.NAME AS COUNTRY
FROM REGIONS JOIN COUNTRIES 
ON REGIONS.REGION_ID = COUNTRIES.REGION_ID

SELECT R.NAME AS REGION, C.NAME AS COUNTRY
FROM REGIONS R JOIN COUNTRIES C 
ON R.REGION_ID = C.REGION_ID

/*Изведете имената на държавите и имената на регионите, в които се намират, 
нека в резултата участват и регионите, в които няма държави*/
SELECT R.NAME AS REGION, C.NAME AS COUNTRY
FROM REGIONS R LEFT OUTER JOIN COUNTRIES C 
ON R.REGION_ID = C.REGION_ID

SELECT R.NAME AS REGION, C.NAME AS COUNTRY
FROM COUNTRIES C RIGHT JOIN REGIONS R 
ON C.REGION_ID = R.REGION_ID

/*Изведете имената на държавите и имената на регионите, в които се намират,
 нека в резултата участват и държавите, които нямат региони*/
 SELECT R.NAME AS REGION, C.NAME AS COUNTRY
 FROM REGIONS R RIGHT JOIN COUNTRIES C 
 ON R.REGION_ID = C.REGION_ID

 SELECT R.NAME AS REGION, C.NAME AS COUNTRY
 FROM COUNTRIES C LEFT JOIN REGIONS R 
 ON C.REGION_ID = R.REGION_ID
 
/*Изведете имената на държавите и имената на регионите, в които се намират, 
нека в резултата участват държавите,които нямат регионите и регионите, 
 в които няма държави*/
 SELECT R.NAME AS REGION, C.NAME AS COUNTRY
 FROM REGIONS R FULL JOIN COUNTRIES C 
 ON R.REGION_ID = C.REGION_ID

/*Изведете имената на клиентите и броя поръчки, които са правили. 
Подредете резултата по брой поръчки низходящо*/
SELECT FNAME + ' ' + LNAME AS CUSTOMER, COUNT(ORDER_ID) AS TOTAL 
FROM CUSTOMERS C JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
GROUP BY FNAME  + ' ' + LNAME 
ORDER BY TOTAL DESC 

/*Изведете имената на клиентите и броя поръчки, нека в резултата участват и
 клиентите,които не са правили поръчки до момента, подредете по брой 
 поръчки низходящо*/
SELECT FNAME + ' ' + LNAME AS CUSTOMER, COUNT(ORDER_ID) AS TOTAL 
FROM CUSTOMERS C LEFT JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
GROUP BY FNAME  + ' ' + LNAME 
ORDER BY TOTAL DESC 

/*Изведете имената на служителите и наименованието на длъжността им*/
SELECT FNAME + ' ' + LNAME AS EMPLOYEE, JOB_TITLE
FROM EMPLOYEES E JOIN JOBS J 
ON E.JOB_ID = J.JOB_ID

/*Изведете имената на клиентите, имената на държавите, в които се намират 
и имената на регионите на съответните държави*/
SELECT FNAME + ' ' + LNAME AS CUSTOMER, CO.NAME AS COUNTRY, 
R.NAME AS REGION 
FROM CUSTOMERS C JOIN COUNTRIES CO 
ON C.COUNTRY_ID = CO.COUNTRY_ID
JOIN REGIONS R 
ON R.REGION_ID = CO.REGION_ID

/*Изведете имената на клиентите и общата стойност на поръчките, които са 
направили*/
SELECT FNAME + ' ' + LNAME AS CUSTOMER, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM CUSTOMERS C JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
JOIN ORDER_ITEMS OI 
ON O.ORDER_ID = OI.ORDER_ID
GROUP BY FNAME + ' ' + LNAME

/*Изведете имената на клиентите и общата стойност на поръчките, които са 
направили, нека в резултата участват само клиентите с обща стойност на 
поръчките над 10000*/
SELECT FNAME + ' ' + LNAME AS CUSTOMER, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM CUSTOMERS C JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
JOIN ORDER_ITEMS OI 
ON O.ORDER_ID = OI.ORDER_ID
GROUP BY FNAME + ' ' + LNAME
HAVING SUM(UNIT_PRICE * QUANTITY) > 10000

/*Изведете имената на отделите и броя служители в тях, нека в резултата 
участват само отдели с повече от 5 назначени служители*/
SELECT NAME, COUNT(EMPLOYEE_ID) AS EMPL_COUNT
FROM DEPARTMENTS D JOIN EMPLOYEES E 
ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
GROUP BY NAME 
HAVING COUNT(EMPLOYEE_ID) > 5

/*Изведете имената на отделите и броя служители в тях, нека в резултата 
участват само отдели с повече от 5 назначени служители и отдели, които се
 намират в държавите US или DE*/
SELECT NAME, COUNT(EMPLOYEE_ID) AS EMPL_COUNT
FROM DEPARTMENTS D JOIN EMPLOYEES E 
ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
WHERE COUNTRY_ID IN ('US', 'DE')
GROUP BY NAME 
HAVING COUNT(EMPLOYEE_ID) > 5
