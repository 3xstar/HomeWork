-- Задание 10

DECLARE @age INT = 18;

IF @age >= 18
	PRINT N'Совершеннолетний';
ELSE
	PRINT N'Несовершеннолетний';



-- Задание 11

DECLARE @grade DECIMAL = 3;

IF @grade >= 3
	PRINT N'Студент успевает';
ELSE
	PRINT N'Есть задолженность';



-- Задание 12

DECLARE @price INT = 5000;

IF @price >= 5000
	PRINT N'Большая покупка';
ELSE
	PRINT N'Обычная покупка';