-- Задание 16

SELECT
    s.name,
    s.average_grade,
    g.name as group_name,
    (SELECT AVG(s2.average_grade)
    FROM college.students AS s2
    WHERE s2.group_id = s.group_id
	) as group_average_grade
	
FROM college.students AS s
JOIN college.groups AS g ON s.group_id = g.id

WHERE s.average_grade > (
    SELECT AVG(s2.average_grade)
    FROM college.students AS s2
    WHERE s2.group_id = s.group_id
);
