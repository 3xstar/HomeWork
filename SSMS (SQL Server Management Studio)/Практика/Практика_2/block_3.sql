-- Задание 7

SELECT name
FROM college.groups AS g
WHERE EXISTS (
    SELECT 1
    FROM college.students AS s
    WHERE s.group_id = g.id and s.average_grade > 4.5
);



-- Задание 8

SELECT name
FROM college.groups AS g
WHERE EXISTS (
    SELECT 1
    FROM college.students AS s
    WHERE s.group_id = g.id and s.age < 18
);



-- Задание 9

SELECT name
FROM college.groups AS g
WHERE NOT EXISTS (
	SELECT 1
    FROM college.students AS s
    WHERE s.group_id = g.id and s.average_grade < 3.0	
);
