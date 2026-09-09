-- Задание 18

SELECT AVG(average_grade)
FROM college.students;

DECLARE @averageGroupGrade DECIMAL(4,2);
SELECT @averageGroupGrade = AVG(average_grade)
FROM college.students;

SELECT @averageGroupGrade;



-- Задание 19

IF @averageGroupGrade >= 4.5
PRINT N'Группа показывает отличный результат'

ELSE IF @averageGroupGrade >= 3.5
PRINT N'Группа показывает хороший результат'

ELSE IF @averageGroupGrade >= 3.0
PRINT N'Группа успевает'

ELSE
PRINT N'Группе необходимо улучшить';