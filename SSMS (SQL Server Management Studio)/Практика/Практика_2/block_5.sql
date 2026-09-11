-- Задание 13

SELECT name
FROM college.groups
WHERE id IN (
    SELECT group_id
    FROM college.students
    WHERE average_grade >= 4.5
);



SELECT g.name
FROM college.groups AS g
WHERE EXISTS (
    SELECT 1
    FROM college.students AS s
    WHERE s.group_id = g.id
      AND s.average_grade >= 4.5
);