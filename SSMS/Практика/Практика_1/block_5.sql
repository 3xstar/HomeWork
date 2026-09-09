-- Задание 13

DECLARE @age INT = 19;

IF @age < 18
	PRINT N'Несовершеннолетний'
	
ELSE IF @age <= 19
	PRINT N'18-19 лет'
	
ELSE
	PRINT N'20+'
	

	
-- Задание 14

DECLARE @averageGrade DECIMAL = 3.49;

IF @averageGrade >= 4.5
	PRINT N'Отличник'
	
ELSE IF @averageGrade >= 3.5
	PRINT N'Хорошист'
	
ELSE IF @averageGrade >= 3.0
	PRINT N'Успевает'
	
ELSE
	PRINT N'Есть задолженности'
	