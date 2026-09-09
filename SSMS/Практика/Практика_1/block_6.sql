-- Задание 15

SELECT
    name,
    age,
    CASE
    	WHEN age < 18 THEN N'Младше 18'
    	WHEN age <= 19 THEN N'18-19 лет'
    	ELSE N'20+'
    END AS age_group
FROM college.students;



-- Задание 16

SELECT
    name,
    average_grade,
    CASE
    	WHEN average_grade >= 4.5 THEN N'Отличник'
    	WHEN average_grade >= 3.5 THEN N'Хорошист'
    	WHEN average_grade >= 3.0 THEN N'Успевает'
    	ELSE N'Есть задолженности'
    END AS result
FROM college.students;



-- Задание 17

SELECT
    name,
    age,
    CASE
    	WHEN age < 18 THEN N'Несовершеннолетний'
    	ELSE N'Совершеннолетний'
    END AS age_status
FROM college.students;
