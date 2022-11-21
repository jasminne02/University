/* В базата TRADECOMPANY създайте още една таблица под името SHIPPING, 
в която ще се случва пренасочването към куриерска фирма (SPEEDY или ECONT). 
Също така ще е нужен външен ключ към вече съществуващата таблица ORDERS (и по конкретно атрибут от нея ORDER_ID).*/

CREATE TABLE SHIPPING
(
	SHIPPING_ID INT PRIMARY KEY, 
	ORDER_ID INT NOT NULL FOREIGN KEY REFERENCES ORDERS,
	COURIER VARCHAR(10) NOT NULL
);


/*След това въведете данни в таблица SHIPPING за куриерски фирми относно поръчки с идентификатори 2374 и 2359 (по един  запис). */

INSERT INTO SHIPPING (SHIPPING_ID, ORDER_ID, COURIER)
VALUES (1, 2374, 'SPEEDY');
INSERT INTO SHIPPING (SHIPPING_ID, ORDER_ID, COURIER)
VALUES (2, 2359, 'ECONT');



/* Изведете всички данни чрез съединение (join) между новосъздадената таблица SHIPPING и таблица ORDERS.*/

SELECT S.SHIPPING_ID, S.ORDER_ID, S.COURIER, O.ORDER_DATE, O.CUSTOMER_ID, O.EMPLOYEE_ID, O.SHIP_ADDRESS
FROM SHIPPING AS S
JOIN ORDERS AS O ON S.ORDER_ID = O.ORDER_ID

