/*Добавете нов атрибут SHIPPING_ID от тип int, който може да съдържа null стойности, към таблица ORDERS;*/
ALTER TABLE ORDERS
ADD SHIPPING_ID INT;



/*Създайте таблица SHIPPING;*/
CREATE TABLE SHIPPING
(
	SHIPPING_ID INT PRIMARY KEY, 
	COURIER VARCHAR(10) NOT NULL
);



/*Добавете външен ключ в таблица ORDERS към таблица SHIPPING (свързващ ги по SHIPPING_ID атрибутите);*/
ALTER TABLE ORDERS
ADD FOREIGN KEY(SHIPPING_ID) REFERENCES SHIPPING;



/*Добавете два записа при новата таблица SHIPPING (с идентификатори 1 и 2 , относно SHIPPING_ID);*/
INSERT INTO SHIPPING (SHIPPING_ID, COURIER)
VALUES (1, 'SPEEDY');
INSERT INTO SHIPPING (SHIPPING_ID, COURIER)
VALUES (2, 'ECONT');



/*Направете промяна в полетата за SHIPPING_ID при таблица ORDERS, като: поръчка с индентификатор 2374 - 
придобие стойност 1 в полето при атрибут SHIPPING_ID, а поръчка 2359 - стойност 2.*/
UPDATE ORDERS
SET SHIPPING_ID = 1
WHERE ORDER_ID = 2374;

UPDATE ORDERS
SET SHIPPING_ID = 2
WHERE ORDER_ID = 2359;



/*Изведете всички данни чрез съединение (join) между новосъздадената таблица SHIPPING и таблица ORDERS.*/
SELECT S.SHIPPING_ID, S.COURIER, O.ORDER_ID, O.ORDER_DATE, O.CUSTOMER_ID, O.EMPLOYEE_ID, O.SHIP_ADDRESS
FROM SHIPPING AS S
JOIN ORDERS AS O ON S.SHIPPING_ID = O.SHIPPING_ID;
