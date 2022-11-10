﻿/*Изведете имената и заплатите на всички служители, които получават заплата 
по-голяма от средната заплата на отдела, в който работят*/
SELECT FNAME, LNAME, SALARY 
FROM EMPLOYEES E 
WHERE SALARY > (SELECT AVG(SALARY)
				FROM EMPLOYEES EM 
				WHERE E.DEPARTMENT_ID = EM.DEPARTMENT_ID)

/*Изведете имената на 3-те продукта, които имат най-голяма стойност*/
SELECT TOP 3 NAME, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM PRODUCTS P JOIN ORDER_ITEMS OI 
ON P.PRODUCT_ID = OI.PRODUCT_ID
GROUP BY NAME 
ORDER BY TOTAL DESC 

/*Изведете стойността на най-скъпата поръчка*/
SELECT TOP 1 ORDER_ID, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
FROM ORDER_ITEMS OI 
GROUP BY ORDER_ID 
ORDER BY TOTAL DESC 

/*Изведете средния брой поръчки, който обработва всеки служител,
 работещ в отдел 80*/
 SELECT AVG(EMPL.TOTAL) AS AVG_COUNT
 FROM (SELECT E.EMPLOYEE_ID, COUNT(ORDER_ID) AS TOTAL 
 FROM EMPLOYEES E JOIN ORDERS O 
 ON E.EMPLOYEE_ID = O.EMPLOYEE_ID
 WHERE DEPARTMENT_ID = 80
 GROUP BY E.EMPLOYEE_ID) EMPL

 /*Изведете имената на отделите, които има повече от 7 назначени служители*/
 SELECT NAME, COUNT(EMPLOYEE_ID) AS TOTAL 
 FROM DEPARTMENTS D JOIN EMPLOYEES E 
 ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
 GROUP BY NAME
 HAVING COUNT(EMPLOYEE_ID) > 7 






 







 ---------------
/*Създайте изглед, който съдържа имената, месечните заплати и номерата
 на отделите на всички служители*/
 CREATE VIEW EMPL_VIEW
 AS
 SELECT FNAME, LNAME, SALARY/12 AS MONTH_SALARY, DEPARTMENT_ID
 FROM EMPLOYEES 

 CREATE VIEW EMPL_80_VIEW
 AS
 SELECT EMPLOYEE_ID, FNAME, LNAME, DEPARTMENT_ID
 FROM EMPLOYEES
 WHERE DEPARTMENT_ID = 80

 SELECT *
 FROM EMPL_80_VIEW

 UPDATE EMPL_80_VIEW
 SET DEPARTMENT_ID = 90
 WHERE EMPLOYEE_ID = 145

 CREATE VIEW EMPL_90_VIEW 
 AS
 SELECT EMPLOYEE_ID, FNAME, LNAME, DEPARTMENT_ID
 FROM EMPLOYEES
 WHERE DEPARTMENT_ID = 90
 WITH CHECK OPTION

 SELECT *
 FROM EMPL_90_VIEW

 --WE CAN NOT EXECUTE THIS
 UPDATE EMPL_90_VIEW
 SET DEPARTMENT_ID = 80
 WHERE EMPLOYEE_ID = 145

 UPDATE EMPLOYEES
 SET DEPARTMENT_ID = 80
 WHERE EMPLOYEE_ID = 145

/*Създайте изглед, който съдържа имената и общата стойност на поръчките,
 обработени от мениджъри*/
 CREATE VIEW MANAGER_VIEW
 AS
 SELECT FNAME, LNAME, SUM(UNIT_PRICE * QUANTITY) AS TOTAL 
 FROM EMPLOYEES E JOIN ORDERS O 
 ON E.EMPLOYEE_ID = O.EMPLOYEE_ID
 JOIN ORDER_ITEMS OI 
 ON O.ORDER_ID = OI.ORDER_ID
 WHERE E.EMPLOYEE_ID = ANY (SELECT MANAGER_ID 
							FROM EMPLOYEES
							WHERE MANAGER_ID IS NOT NULL)
GROUP BY FNAME, LNAME 

SELECT *
FROM MANAGER_VIEW


/*Създайте изглед, който съдържа наименованията на длъжностите и датите на 
първия и последния назначен служител в тази длъжност*/
CREATE VIEW JOB_VIEW
AS 
SELECT JOB_TITLE, MIN(HIRE_DATE) AS MIN_DATE, MAX(HIRE_DATE) AS MAX_DATE
FROM JOBS J JOIN EMPLOYEES E 
ON J.JOB_ID = E.JOB_ID
GROUP BY JOB_TITLE

SELECT *
FROM JOB_VIEW

/* Да се създаде изглед, който съдържа номерата на поръчките, датата им,
 името на клиента, направил поръчката.*/
 CREATE VIEW ORD_CUST_VIEW
 AS 
 SELECT ORDER_ID, ORDER_DATE, FNAME + ' ' + LNAME AS CUSTOMER
 FROM ORDERS O JOIN CUSTOMERS C 
 ON O.CUSTOMER_ID = C.CUSTOMER_ID

 SELECT *
 FROM ORD_CUST_VIEW

/* Създайте изглед, който съдържа номера на служителите, имената на 
отделите им и броя поръчки направени от съответния служител. Нека
да участват и служителите, които не са обработвали поръчки*/
CREATE VIEW DEP_EML_ORD_VIEW
AS
SELECT E.EMPLOYEE_ID, NAME, COUNT(ORDER_ID) AS TOTAL 
FROM DEPARTMENTS D JOIN EMPLOYEES E 
ON D.DEPARTMENT_ID = E.DEPARTMENT_ID
LEFT JOIN ORDERS O 
ON O.EMPLOYEE_ID = E.EMPLOYEE_ID
GROUP BY E.EMPLOYEE_ID, NAME 

SELECT *
FROM DEP_EML_ORD_VIEW