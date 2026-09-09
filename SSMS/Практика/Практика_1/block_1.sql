-- Задание 1

DECLARE @age INT = 18;

SELECT @age;



-- Задание 2

DECLARE @age INT = 18;

SET @age = 19;

SELECT @age;



-- Задание 3

DECLARE @name NVARCHAR(100);
DECLARE @age INT;
DECLARE @averageGrade DECIMAL;

set @name = 'Боря';
set @age = 20;
set @averageGrade = 5;

SELECT @name, @age, @averageGrade;