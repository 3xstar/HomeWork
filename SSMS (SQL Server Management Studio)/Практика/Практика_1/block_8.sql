-- Задание 20

DECLARE @studentId DECIMAL;
DECLARE @studentName NVARCHAR(100);
DECLARE @studentAge INT;
DECLARE @studentGrade DECIMAL;


SELECT 
	@studentId = id,
	@studentName = name,
	@studentAge = age,
	@studentGrade = average_grade
FROM college.students
WHERE id = 3;


SELECT
	N'Информация о студенте',
	N'Имя: ' + @studentName,
	N'Возраст: ' + CONVERT(NVARCHAR(100), @studentAge),
	N'ID студента: '+ CONVERT(NVARCHAR(100), @studentId),
	
	N'Возрастная группа: ' +
    CASE
    	WHEN @studentAge < 18 THEN N'Младше 18'
    	WHEN @studentAge <= 19 THEN N'18-19 лет'
    	ELSE N'20+'
    END,
    
    N'Средний балл: ' + CONVERT(NVARCHAR(100), @studentGrade),
    
    N'Результат: ' +
    CASE
    	WHEN @studentGrade >= 4.5 THEN N'Отличник'
    	WHEN @studentGrade >= 3.5 THEN N'Хорошист'
    	WHEN @studentGrade >= 3.0 THEN N'Успевает'
    	ELSE N'Есть задолженности'
    END AS full_info
