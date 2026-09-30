USE CollegeDB;

SELECT *
FROM college.students;



-- task 1

CREATE TABLE college.student_changes (
    id INT IDENTITY(1,1) PRIMARY KEY,
    student_id INT NOT NULL,
    old_average_grade DECIMAL(4,2),
    new_average_grade DECIMAL(4,2),
    change_date DATETIME2 NOT NULL
);



-- task 2

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



-- task 3

UPDATE college.students
SET average_grade = 4
WHERE id = 1;


SELECT *
FROM college.student_changes;



-- task 4

UPDATE college.students
SET average_grade = average_grade + 0.1
WHERE group_id = 1;


SELECT *
FROM college.student_changes;



-- task 5

CREATE TRIGGER college.trg_Students_ValidateGrade
ON college.students
AFTER UPDATE, INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS
    (
    	SELECT 1
    	FROM inserted WHERE average_grade > 5 OR average_grade < 0
    )
    BEGIN
    	THROW 50001,
    		N'Average grade cannot be > 5 or < 0',
    		1;
    END;
END;



-- task 6

UPDATE college.students
SET average_grade = 4.5
WHERE id = 2;


UPDATE college.students
SET average_grade = 6
WHERE id = 2;


SELECT *
FROM college.students
WHERE id = 2;



-- task 7

-- 1. В deleted находятся старые данные таблицы
-- 2. В inserted находятся новые данные таблицы

-- 3. В UPDATE нужны обе таблицы потому-что одна хранит старые данные, а вторая новые
-- и логирование изменений создается через их сравнение

-- 4. Триггер должен корректно работать с несколькими строками
-- потому-что срабатывает один раз на весь запрос



-- final task

ALTER TABLE college.student_changes
ADD old_age INT,
    new_age INT;


ALTER TRIGGER college.trg_Students_AverageGradeAudit
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
        old_age,
        new_age,
        change_date
    )
    SELECT
        d.id,
        d.average_grade,
        i.average_grade,
        d.age,
        i.age,
        SYSDATETIME()
    FROM deleted AS d
    JOIN inserted AS i
        ON i.id = d.id
    WHERE d.average_grade <> i.average_grade OR d.age <> i.age;
END;


UPDATE college.students
SET
    age = age + 1,
    average_grade = average_grade + 0.1
WHERE id = 3;


SELECT *
FROM college.student_changes;