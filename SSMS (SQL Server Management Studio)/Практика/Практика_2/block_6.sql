-- Задание 14

SELECT
    s.name,
    s.average_grade
FROM college.students AS s
WHERE s.group_id IN (
    SELECT id
    FROM college.groups
    WHERE name = N'ПР-21'
)
AND s.average_grade > (
    SELECT AVG(s2.average_grade)
    FROM college.students AS s2
    WHERE s2.group_id = s.group_id
);



-- Задание 15

SELECT
    s.name,
    s.average_grade
FROM college.students AS s
WHERE s.average_grade > 4.0
AND s.age < (
    SELECT AVG(s2.age)
    FROM college.students AS s2
    WHERE s2.group_id = s.group_id
);
