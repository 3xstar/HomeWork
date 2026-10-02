CREATE TABLE college.groups (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Автоинкрементный первичный ключ
    name NVARCHAR(50) NOT NULL,       -- Название группы (например, 'ИСП-311')
    specialty NVARCHAR(150) NOT NULL  -- Специальность
);


CREATE TABLE college.students (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Автоинкрементный первичный ключ
    name NVARCHAR(100) NOT NULL,      -- Имя студента
    age INT CHECK (age >= 16 AND age <= 60), -- Возраст с ограничением
    average_grade DECIMAL(3,2),       -- Средний балл (например, 4.75)
    group_id INT,                     -- Внешний ключ на группу
    CONSTRAINT FK_Students_Groups FOREIGN KEY (group_id) 
        REFERENCES college.groups(id) ON DELETE SET NULL
);

CREATE TABLE college.grades (
    id INT IDENTITY(1,1) PRIMARY KEY, -- Автоинкрементный первичный ключ
    student_id INT NOT NULL,          -- Внешний ключ на студента
    subject NVARCHAR(100) NOT NULL,   -- Название предмета (например, 'Математика')
    grade INT CHECK (grade >= 2 AND grade <= 5), -- Оценка (от 2 до 5)
    grade_date DATE DEFAULT GETDATE(),-- Дата выставления оценки
    CONSTRAINT FK_Grades_Students FOREIGN KEY (student_id) 
        REFERENCES college.students(id) ON DELETE CASCADE
);



-- task 1

SELECT
	s.name AS student_name,
	g.name AS group_name,
	s.average_grade,
	COUNT(gr.id) AS grades_count,
	AVG(CAST(gr.grade AS DECIMAL(3,2))) AS avg_by_grades
FROM college.students s
LEFT JOIN college.groups g
	ON g.id = s.group_id
LEFT JOIN college.grades gr
	ON gr.student_id = s.id
	
GROUP BY
	s.id,
	s.name,
	g.name,
	s.average_grade
	
	
	
-- task 2
	
WITH StudentStats AS(
	SELECT
		id,
		name,
		group_id,
		average_grade
	FROM college.students
)
SELECT
	name,
	average_grade,
	RANK() OVER (
		ORDER BY average_grade DESC
	) AS rating
FROM StudentStats
ORDER BY rating;



-- task 3

WITH StudentStats AS(
	SELECT
		s.name AS student_name,
		g.name AS group_name,
		s.average_grade
	FROM college.students s
	LEFT JOIN college.groups g
		ON g.id = s.group_id
)
SELECT
	student_name,
	group_name,
	average_grade,
	RANK() OVER (
		PARTITION BY group_name
		ORDER BY average_grade DESC
	) AS group_rating
FROM StudentStats;



-- task 4

CREATE VIEW college.StudentRating
AS
SELECT
	s.id,
	s.name,
	g.name AS group_name,
	s.average_grade,
	RANK() OVER (
		PARTITION BY g.name
		ORDER BY s.average_grade DESC
	) AS group_rating
FROM college.students s
LEFT JOIN college.groups g
	ON g.id = s.group_id
	

SELECT *
FROM college.StudentRating;


SELECT *
FROM college.StudentRating
WHERE group_name = N'ВЕБ-31';



-- task 5

CREATE PROCEDURE college.GetStudentsByMinGrade
	@min_grade DECIMAL(3,2)
AS
BEGIN
	SELECT
		id,
		name,
		average_grade
	FROM college.students
	WHERE average_grade >= @min_grade
	ORDER BY average_grade DESC;
END;


EXEC college.GetStudentsByMinGrade
    @min_grade = 4.5;


EXEC college.GetStudentsByMinGrade
    @min_grade = 3.0;



-- task 6

CREATE FUNCTION college.GetStudentStatus
(
	@average_grade DECIMAL(3,2)
)
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @status NVARCHAR(50)
	
	IF @average_grade >= 4.5
		SET @status = N'Отличник'
	ELSE IF @average_grade >= 3.5
		SET @status = N'Хорошист'
	ELSE
		SET @status = N'Требуется дополнительная подготовка'
		
	RETURN @status
END;


SELECT
    name,
    average_grade,
    college.GetStudentStatus(average_grade) AS status
FROM college.students



-- task 7

CREATE FUNCTION college.GetStudentsByGroup
(
	@group_id INT
)
RETURNS TABLE
AS
RETURN
(
	SELECT
		s.id,
		s.name,
		s.age,
		s.average_grade
	FROM college.students s
	WHERE s.group_id = @group_id
);


SELECT *
FROM college.GetStudentsByGroup(1);


SELECT *
FROM college.GetStudentsByGroup(1)
WHERE average_grade >= 4.5;



-- task 8

CREATE TABLE college.student_changes (
    id INT IDENTITY(1,1) PRIMARY KEY,
    student_id INT NOT NULL,
    old_average_grade DECIMAL(3,2),
    new_average_grade DECIMAL(3,2),
    change_date DATETIME2 NOT NULL
);


CREATE TRIGGER college.trg_Students_AverageGradeAudit
ON college.students
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO college.student_changes
    (
        student_id,
        old_average_grade,
        new_average_grade,
        change_date
    )
    SELECT
        d.id,
        d.average_grade,
        i.average_grade,
        SYSDATETIME()
    FROM deleted AS d
    JOIN inserted AS i
        ON i.id = d.id
    WHERE d.average_grade <> i.average_grade;
END;


UPDATE college.students
SET average_grade = average_grade + 0.1
WHERE id = 1;


SELECT *
FROM college.student_changes;



-- final task

SELECT
	s.id AS student_id,
	s.name AS student_name,
	g.name AS group_name,
	s.average_grade,
	college.GetStudentStatus(average_grade) AS status,
	RANK() OVER (
		PARTITION BY g.name
		ORDER BY s.average_grade DESC
	) AS group_rating,
	COUNT(gr.id) AS grades_count
	
FROM college.students s
LEFT JOIN college.groups g
	ON g.id = s.group_id
LEFT JOIN college.grades gr
	ON gr.student_id = s.id
GROUP BY
    s.id, s.name, g.name, s.average_grade
ORDER BY g.name, group_rating;