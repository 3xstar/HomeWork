-- Задание 1

SELECT name, average_grade
FROM college.students
WHERE average_grade > (
    SELECT AVG(average_grade)
    FROM college.students
);



-- Задание 2

SELECT name, age
FROM college.students
WHERE age > (
    SELECT AVG(age)
    FROM college.students
);



-- Задание 3 

SELECT name, average_grade
FROM college.students
WHERE average_grade = (
    SELECT MAX(average_grade)
    FROM college.students
);
