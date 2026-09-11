-- Задание 4

SELECT name, group_id
FROM college.students
WHERE group_id IN (
    SELECT id
    FROM college.groups
    WHERE name LIKE N'ИС%'
);



-- Задание 5

SELECT name, group_id
FROM college.students
WHERE group_id IN (
    SELECT id
    FROM college.groups
    WHERE name LIKE N'%21'
);



-- Задание 6

SELECT name
FROM college.groups
WHERE id IN (
    SELECT group_id
    FROM college.students
    WHERE average_grade > 4.5
);

