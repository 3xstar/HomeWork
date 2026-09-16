-- task 1

SELECT
    s.id,
    s.name,
    g.name AS group_name,
    AVG(gr.grade) AS average_grade,
    MAX(gr.grade) AS max_grade,
    MIN(gr.grade) AS min_grade,
    COUNT(gr.id) AS grades_count
FROM college.students s
JOIN college.groups g
    ON s.group_id = g.id
JOIN college.grades gr
    ON gr.student_id = s.id
GROUP BY
    s.id,
    s.name,
    g.name;



-- task 2

WITH StudentStats AS
(
    SELECT
        s.id,
        s.name,
        g.name AS group_name,
        AVG(gr.grade) AS average_grade
    FROM college.students s
    JOIN college.groups g
        ON s.group_id = g.id
    JOIN college.grades gr
        ON gr.student_id = s.id
    GROUP BY
        s.id,
        s.name,
        g.name
)
SELECT
    name,
    group_name,
    average_grade,
    ROW_NUMBER() OVER
    (
        ORDER BY average_grade DESC
    ) AS rating_position
FROM StudentStats
ORDER BY rating_position;



-- task 3

WITH StudentStats AS
(
    SELECT
        s.id,
        s.name,
        g.name AS group_name,
        AVG(gr.grade) AS average_grade
    FROM college.students s
    JOIN college.groups g
        ON s.group_id = g.id
    JOIN college.grades gr
        ON gr.student_id = s.id
    GROUP BY
        s.id,
        s.name,
        g.name
)
SELECT
    name,
    group_name,
    average_grade,
    ROW_NUMBER() OVER
    (
        ORDER BY average_grade DESC
    ) AS [ROW_NUMBER],
    RANK() OVER
    (
        ORDER BY average_grade DESC
    ) AS [RANK],
    DENSE_RANK() OVER
    (
        ORDER BY average_grade DESC
    ) AS [DENSE_RANK]
FROM StudentStats
ORDER BY [ROW_NUMBER];



-- task 4

WITH StudentStats AS
(
    SELECT
        s.id,
        s.name,
        g.name AS group_name,
        AVG(gr.grade) AS average_grade
    FROM college.students s
    JOIN college.groups g
        ON s.group_id = g.id
    JOIN college.grades gr
        ON gr.student_id = s.id
    GROUP BY
        s.id,
        s.name,
        g.name
)
SELECT
    name,
    group_name,
    average_grade,
    ROW_NUMBER() OVER
	(
	    PARTITION BY group_name
	    ORDER BY average_grade DESC
	) as group_position
FROM StudentStats
ORDER BY group_name, group_position;



-- task 5

WITH StudentStats AS
(
    SELECT
        s.id,
        s.name,
        g.name AS group_name,
        AVG(gr.grade) AS average_grade
    FROM college.students s
    JOIN college.groups g
        ON s.group_id = g.id
    JOIN college.grades gr
        ON gr.student_id = s.id
    GROUP BY
        s.id,
        s.name,
        g.name
),
Ranked AS
(
	SELECT
	    name,
	    group_name,
	    average_grade,
	    ROW_NUMBER() OVER
		(
		    PARTITION BY group_name
		    ORDER BY average_grade DESC
		) as group_position
	FROM StudentStats
)
SELECT
	name,
	group_name,
	average_grade,
	group_position
FROM Ranked
WHERE group_position = 1
ORDER BY group_name;



-- task 6

SELECT
    s.name,
    gr.grade_date,
    gr.grade,
    LAG(gr.grade) OVER
    (
        PARTITION BY gr.student_id
        ORDER BY gr.grade_date
    ) AS previous_grade
FROM college.grades gr
JOIN college.students s
    ON gr.student_id = s.id
ORDER BY
    s.name,
    gr.grade_date;



-- task 7

SELECT
    s.name,
    gr.grade_date,
    gr.grade,
    LAG(gr.grade) OVER
    (
        PARTITION BY gr.student_id
        ORDER BY gr.grade_date
    ) AS previous_grade,
    gr.grade - LAG(gr.grade) OVER
    (
        PARTITION BY gr.student_id
        ORDER BY gr.grade_date
    ) AS grade_difference,
    CASE
    	WHEN LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) IS NULL THEN N'Нет данных'
	    WHEN gr.grade > LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) THEN N'Улучшение'
	    WHEN gr.grade < LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) THEN N'Ухудшение'
	    ELSE N'Без изменений'
    END AS grade_status
    
FROM college.grades gr
JOIN college.students s
    ON gr.student_id = s.id
ORDER BY
    s.name,
    gr.grade_date;



-- task 8

SELECT
    s.name,
    gr.grade_date,
    gr.grade,
    LEAD(gr.grade) OVER
    (
        PARTITION BY gr.student_id
        ORDER BY gr.grade_date
    ) AS next_grade
FROM college.grades gr
JOIN college.students s
    ON gr.student_id = s.id
ORDER BY
    s.name,
    gr.grade_date;



-- task 9

WITH StudentStats AS
(
    SELECT
    	s.id,
        s.name,
        gr.grade_date,
        gr.grade,
        AVG(gr.grade) OVER
		(
		    PARTITION BY gr.student_id
		) as average_grade
    FROM college.students s
    JOIN college.grades gr
        ON gr.student_id = s.id
)
SELECT
    name,
    grade_date,
    grade,
    average_grade
FROM StudentStats
ORDER BY name, grade_date;



-- task 10

WITH StudentStats AS
(
    SELECT
    	s.id,
        s.name,
        gr.grade_date,
        gr.grade,
        SUM(gr.grade) OVER
		(
		    PARTITION BY gr.student_id
		    ORDER BY gr.grade_date
		) as grade_sum
    FROM college.students s
    JOIN college.grades gr
        ON gr.student_id = s.id
)
SELECT
    name,
    grade_date,
    grade,
    grade_sum
FROM StudentStats
ORDER BY name, grade_date;



-- task 11

WITH StudentStats AS
(
    SELECT
        s.id,
        s.name,
        g.name AS group_name,
        gr.grade_date,
        gr.grade,
        AVG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	    ) AS average_grade,
        LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) AS previous_grade,
	    LEAD(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) AS next_grade,
	    gr.grade - LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) AS prev_current_grade_diff,
	    SUM(gr.grade) OVER
		(
		    PARTITION BY gr.student_id
		    ORDER BY gr.grade_date
		) AS grade_sum
        
    FROM college.students s
    JOIN college.groups g
        ON s.group_id = g.id
    JOIN college.grades gr
        ON gr.student_id = s.id
)
SELECT *
FROM StudentStats
ORDER BY group_name, name, grade_date;



-- task 12

WITH StudentStats AS
(
    SELECT
        s.id,
        s.name,
        g.name AS group_name,
        AVG(gr.grade) AS average_grade,
        MAX(gr.grade) AS max_grade,
        MIN(gr.grade) AS min_grade,
        COUNT(gr.id) AS grades_count,
        SUM(gr.grade) AS total_grade
    FROM college.students s
    JOIN college.groups g
        ON s.group_id = g.id
    JOIN college.grades gr
        ON gr.student_id = s.id
    GROUP BY
        s.id,
        s.name,
        g.name
)
SELECT
    name,
    group_name,
    average_grade,
    max_grade,
    min_grade,
    grades_count,
    total_grade,
    RANK() OVER
    (
        ORDER BY total_grade DESC
    ) AS rating
FROM StudentStats
ORDER BY rating;



-- task 13

SELECT
    s.name,
    gr.grade_date,
    gr.grade,
    LAG(gr.grade) OVER
    (
        PARTITION BY gr.student_id
        ORDER BY gr.grade_date
    ) AS previous_grade,
    gr.grade - LAG(gr.grade) OVER
    (
        PARTITION BY gr.student_id
        ORDER BY gr.grade_date
    ) AS grade_difference,
    CASE
    	WHEN LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) IS NULL THEN N'Нет предыдущего результата'
	    WHEN gr.grade > LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) THEN N'Улучшение'
	    WHEN gr.grade < LAG(gr.grade) OVER
	    (
	        PARTITION BY gr.student_id
	        ORDER BY gr.grade_date
	    ) THEN N'Ухудшение'
	    ELSE N'Без изменений'
    END AS grade_status
    
FROM college.grades gr
JOIN college.students s
    ON gr.student_id = s.id
ORDER BY
    s.name,
    gr.grade_date;



-- final task

WITH StudentStats AS
(
    SELECT
        s.id,
        s.name,
        g.name AS group_name,
        AVG(gr.grade) AS average_grade,
        MAX(gr.grade) AS max_grade,
        MIN(gr.grade) AS min_grade,
        COUNT(gr.id) AS grades_count,
        SUM(gr.grade) AS total_grade
    FROM college.students s
    JOIN college.groups g
        ON s.group_id = g.id
    JOIN college.grades gr
        ON gr.student_id = s.id
    GROUP BY
        s.id,
        s.name,
        g.name
)
SELECT
    name,
    group_name,
    average_grade,
    max_grade,
    min_grade,
    grades_count,
    RANK() OVER
    (
        ORDER BY total_grade DESC
    ) AS total_rating,
    RANK() OVER
    (
    	PARTITION BY group_name
        ORDER BY total_grade DESC
    ) AS group_rating
FROM StudentStats
ORDER BY total_rating;

SELECT
    s.name,
    gr.grade_date,
    gr.grade,
    LAG(gr.grade) OVER
	(
	  PARTITION BY gr.student_id
	  ORDER BY gr.grade_date
	) AS previous_grade,
	LEAD(gr.grade) OVER
	(
	   PARTITION BY gr.student_id
	   ORDER BY gr.grade_date
	) AS next_grade,
	gr.grade - LAG(gr.grade) OVER
	(
	   PARTITION BY gr.student_id
	   ORDER BY gr.grade_date
	 ) AS prev_current_grade_diff,
	 SUM(gr.grade) OVER
	(
	   PARTITION BY gr.student_id
	   ORDER BY gr.grade_date
	 ) AS total_grade
FROM college.grades gr
JOIN college.students s
    ON gr.student_id = s.id
ORDER BY
    s.name,
    gr.grade_date;


