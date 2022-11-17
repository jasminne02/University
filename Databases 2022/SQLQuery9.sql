/*Създайте изглед, който съдържа имената на държавите и имената на регионите,
 в които се намират. Нека в резултата участват само държавите, в които 
 няма отдели и клиенти на фирмата*/
 CREATE VIEW COUN_REG_VIEW
 AS
 SELECT C.NAME AS COUNTRY, R.NAME AS REGION 
 FROM COUNTRIES C JOIN REGIONS R 
 ON C.REGION_ID = R.REGION_ID
 LEFT JOIN CUSTOMERS CU 
 ON CU.COUNTRY_ID = C.COUNTRY_ID
 LEFT JOIN DEPARTMENTS D 
 ON D.COUNTRY_ID = C.COUNTRY_ID
 WHERE D.COUNTRY_ID IS NULL AND CU.COUNTRY_ID IS NULL

 SELECT *
 FROM COUN_REG_VIEW

/*Създайте изглед, който съдържа имената на отделите, броя служители в тях и 
най-високата заплата*/
CREATE VIEW DEP_VIEW
AS
SELECT NAME, COUNT(EMPLOYEE_ID) AS TOTAL, MAX(SALARY) AS SALARY 
FROM DEPARTMENTS D JOIN EMPLOYEES E 
ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
GROUP BY NAME 

SELECT *
FROM DEP_VIEW

/*Създайте изглед, който съдържа имената на продуктите и общото количество,
 в което  са били поръчани.*/
 CREATE VIEW PROD_VIEW 
 AS
 SELECT NAME, SUM(QUANTITY) AS TOTAL 
 FROM PRODUCTS P JOIN ORDER_ITEMS OI 
 ON P.PRODUCT_ID = OI.PRODUCT_ID
 GROUP BY NAME 

 SELECT *
 FROM PROD_VIEW

 /*Име и цена на продуктите, чието име започва с „M“ и цена по-голяма от 
50, сортиран по цена на продукта в низходящ ред (z-a)*/
SELECT NAME, PRICE
FROM PRODUCTS
WHERE NAME LIKE 'M%' AND PRICE < 50
ORDER BY PRICE DESC

/*имената на служителите и наименованията на отделите, в които работят,
 в резултата да участват само служителите, които получават заплата по-голяма 
 от всеки служител, работещ в отдел Маркетинг(номер 20)*/
 SELECT JOB_TITLE, FNAME + ' ' + LNAME AS EMPLOYEE
 FROM EMPLOYEES E JOIN JOBS J 
 ON E.JOB_ID = J.JOB_ID
 WHERE SALARY > ALL (SELECT SALARY 
					 FROM EMPLOYEES
					 WHERE DEPARTMENT_ID = 20)

SELECT *
FROM EMPLOYEES

SELECT M.FNAME + ' ' + M.LNAME AS MANAGER, E.FNAME + ' ' + E.LNAME AS EMPLOYEE
FROM EMPLOYEES E JOIN EMPLOYEES M 
ON E.MANAGER_ID = M.EMPLOYEE_ID

---------------------------------------------------------------------------
BEGIN TRAN 

INSERT PRODUCTS 
VALUES(1, 'APPLE', 100, 'FRUIT')

UPDATE EMPLOYEES
SET SALARY += 1000
WHERE EMPLOYEE_ID = 100

COMMIT 

SELECT *
FROM PRODUCTS
WHERE PRODUCT_ID = 1
 
---24000.00
SELECT SALARY
FROM EMPLOYEES
WHERE EMPLOYEE_ID = 100


/*Създайте процедура, която извежда имената на всички продукти, които са били поръчвани*/
CREATE PROCEDURE PROD_PROC 
AS 
SELECT NAME
FROM PRODUCTS P JOIN ORDER_ITEMS OI 
ON P.PRODUCT_ID = OI.PRODUCT_ID

EXECUTE PROD_PROC

/*Създайте процедура, която връща като резултат броя поръчки на клиент и
има като входен параметър номер на клиент*/
CREATE PROC CUST_PROC @CUST_ID INT 
AS
SELECT FNAME + ' ' + LNAME AS CUSTOMER, COUNT(ORDER_ID) AS TOTAL 
FROM CUSTOMERS C LEFT JOIN ORDERS O 
ON C.CUSTOMER_ID = O.CUSTOMER_ID
WHERE C.CUSTOMER_ID = @CUST_ID
GROUP BY FNAME + ' ' + LNAME 

EXEC CUST_PROC @CUST_ID = 105

--TRIGGER DEFINITION
CREATE TRIGGER PRODUCT_INSERT_TRIGGER
ON PRODUCTS
AFTER INSERT
AS
SELECT *
FROM inserted;


INSERT PRODUCTS 
VALUES(2, 'APPLE', 100, 'FRUIT')


/*Изведете наименованието на длъжността, в която са назначени най-много служители*/
SELECT TOP 1 WITH TIES JOB_TITLE, COUNT(EMPLOYEE_ID) AS TOTAL 
FROM JOBS J JOIN EMPLOYEES E 
ON J.JOB_ID = E.JOB_ID
GROUP BY JOB_TITLE
ORDER BY TOTAL DESC 

/*Изведете имената на клиентите, които са от женски пол и не са правили поръчки до 
момента*/
SELECT FNAME + ' ' + LNAME AS FEMALE_CUST 
FROM CUSTOMERS
WHERE GENDER = 'F' AND CUSTOMER_ID NOT IN (SELECT CUSTOMER_ID FROM ORDERS)

/*Извдете отделите и имената на мениджърите им. Подредете резултата възходящо по 
име на отдел.*/
SELECT NAME, FNAME + ' ' + LNAME AS MANAGER 
FROM DEPARTMENTS D JOIN EMPLOYEES E 
ON D.MANAGER_ID = E.EMPLOYEE_ID
ORDER BY NAME
