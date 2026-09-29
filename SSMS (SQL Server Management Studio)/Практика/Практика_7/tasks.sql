USE CollegeDB;

SELECT * FROM college.groups;
SELECT * FROM college.students;



-- task 1

CREATE FUNCTION college.GetStudentStatus
(
	@average_grade DECIMAL(4,2)
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
		SET @status = N'Требуетсфя дополнительная проверка'
		
	RETURN @status
END;


SELECT
    name,
    average_grade,
    college.GetStudentStatus(average_grade) AS status
FROM college.students;

SELECT college.GetStudentStatus(5.0);
SELECT college.GetStudentStatus(4.2);
SELECT college.GetStudentStatus(3.1);



-- task 2

CREATE FUNCTION college.CalculateDiscount
(
	@price DECIMAL(10,2),
	@discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
	RETURN @price - (@price * @discount / 100);
END;


SELECT college.CalculateDiscount(10000, 10);
SELECT college.CalculateDiscount(25000, 15);

SELECT
    name,
    average_grade,
    college.CalculateDiscount(10000, 10) AS discounted_price
FROM college.students;



-- task 3

SELECT
	s.name,
	g.name as group_name,
	s.average_grade,
	college.GetStudentStatus(s.average_grade) as status
FROM college.students s 
JOIN college.groups g ON g.id = s.group_id;



-- task 4

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
		s.average_grade,
		@group_id AS group_id
	FROM college.students s
	JOIN college.groups as g
		ON g.id = s.group_id
	WHERE s.group_id = @group_id
);


SELECT *
FROM college.GetStudentsByGroup(1);

SELECT *
FROM college.GetStudentsByGroup(2);

SELECT *
FROM college.GetStudentsByGroup(3);



-- task 5

SELECT
    s.name,
    g.name AS group_name,
    s.average_grade
FROM college.GetStudentsByGroup(1) s
JOIN college.groups g
    ON g.id = s.group_id;



-- task 6

CREATE FUNCTION college.GetAgeCategory
(
	@age INT
)
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @age_category NVARCHAR(50)
	
	IF @age < 18
		SET @age_category = N'Несовершеннолетний'
	ELSE IF @age <= 20
		SET @age_category = N'Студент'
	ELSE
		SET @age_category = N'Взрослый'
		
	RETURN @age_category
END;


SELECT
    name,
    age,
    college.GetAgeCategory(age) AS age_category
FROM college.students;



-- final task

SELECT
    s.name,
    g.name AS group_name,
    s.age,
    s.average_grade,
    college.GetStudentStatus(s.average_grade) AS status,
    college.GetAgeCategory(s.age) AS age_category
FROM college.students s
JOIN college.groups g
    ON g.id = s.group_id;
