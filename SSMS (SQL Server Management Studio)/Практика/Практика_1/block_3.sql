-- Задание 7

DECLARE @age INT;
SELECT @age = age
FROM college.students WHERE id = 1;

DECLARE @future_age INT;
SELECT @future_age = age + 5
FROM college.students WHERE id = 1;

SELECT @age, @future_age;



-- Задание 8

DECLARE @grade1 DECIMAL;
SELECT @grade1 = average_grade
FROM college.students WHERE id = 1;

DECLARE @grade2 DECIMAL;
SELECT @grade2 = average_grade
FROM college.students WHERE id = 2;

DECLARE @grade3 DECIMAL;
SELECT @grade3 = average_grade
FROM college.students WHERE id = 3;

DECLARE @middle_grade DECIMAL(4,2);
SET @middle_grade = (@grade1 + @grade2 + @grade3) / 3;

SELECT @grade1, @grade2, @grade3, @middle_grade;



-- Задание 9

DECLARE @price INT;
DECLARE @discount INT;

SET @price = 1500;
SET @discount = 10;

DECLARE @final_price INT;
SET @final_price = @price - (@price * @discount / 100);

SELECT @price, @discount, @final_price;















