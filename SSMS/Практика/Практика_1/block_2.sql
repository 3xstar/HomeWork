-- Задание 4

DECLARE @studentName NVARCHAR(100);
SELECT @studentName = name
FROM college.students WHERE id = 1;

SELECT @studentName;



-- Задание 5

DECLARE @studentName NVARCHAR(100);
SELECT @studentName = name
FROM college.students WHERE id = 2;

DECLARE @studentAge INT;
SELECT @studentAge = age
FROM college.students WHERE id = 2;

DECLARE @studentGrade DECIMAL;
SELECT @studentGrade = average_grade
FROM college.students WHERE id = 2;

SELECT @studentName, @studentAge, @studentGrade;



-- Задание 6

DECLARE @studentCount INT;
SELECT @studentCount = COUNT(*)
FROM college.students

SELECT @studentCount;