-- Задание 10

SELECT
    s.name,
    s.average_grade,
    s.group_id
FROM college.students AS s
WHERE s.average_grade > (
    SELECT AVG(s2.average_grade)
    FROM college.students AS s2
    WHERE s2.group_id = s.group_id
);



-- Задание 11

SELECT
    s.name,
    s.average_grade,
    s.group_id
FROM college.students AS s
WHERE s.age > (
    SELECT AVG(s2.age)
    FROM college.students AS s2
    WHERE s2.group_id = s.group_id
);



-- Задание 12

SELECT
    s.name,
    s.average_grade,
    s.group_id
FROM college.students AS s
WHERE s.average_grade < (
    SELECT AVG(s2.average_grade)
    FROM college.students AS s2
    WHERE s2.group_id = s.group_id
);
