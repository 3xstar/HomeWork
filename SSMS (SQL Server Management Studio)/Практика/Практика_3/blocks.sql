-- block 1

WITH DangerousLocations AS
(
    SELECT
        id,
        name,
        difficulty,
        reward
    FROM game.locations
    WHERE difficulty >= 5
)
SELECT *
FROM DangerousLocations;



-- block 2

WITH LocationStatistics AS
(
    SELECT
    	parent_id,
    	COUNT(id) AS child_count,
        AVG(CAST(difficulty AS FLOAT)) as avg_difficulty,
        MAX(reward) AS max_reward
    FROM game.locations
    WHERE parent_id IS NOT NULL
    GROUP BY parent_id
)
SELECT
	l.name  AS location,
	ls.child_count AS [number of childs],
	ls.avg_difficulty AS [average difficulty], 
	ls.max_reward AS [max reward]
FROM LocationStatistics ls
JOIN game.locations l ON ls.parent_id = l.id
WHERE l.location_type = N'Локация'



-- block 3

WITH HighDifficultyRegions AS
(
    SELECT
    	id,
    	parent_id,
    	name,
    	difficulty,
    	id AS region_id,
    	name AS region_name,
    	difficulty AS region_difficulty
    FROM game.locations
    WHERE location_type = N'Регион'
	
    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name,
		l.difficulty,
		hdr.region_id,
		hdr.region_name,
		hdr.region_difficulty 
	FROM game.locations AS l
	JOIN HighDifficultyRegions AS hdr on l.parent_id = hdr.id
)
SELECT
	region_name AS region,
	region_difficulty AS difficulty,
	MAX(difficulty) AS [max childs difficulty]
FROM HighDifficultyRegions
WHERE id <> region_id
GROUP BY region_id, region_name, region_difficulty 
HAVING MAX(difficulty) >= 7;




-- block 4

WITH LocationTree AS
(
    SELECT 
    	id,
    	parent_id,
    	name
    FROM game.locations
    WHERE name = N'Северные земли'

    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name
	FROM game.locations AS l
	JOIN LocationTree AS lt
		ON l.parent_id = lt.id
)
SELECT name AS [child name]
FROM LocationTree;



-- block 5

WITH LocationTree AS
(
    SELECT 
    	id,
    	parent_id,
    	name,
    	0 AS level
    FROM game.locations
    WHERE name = N'Северные земли'

    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name,
		lt.level + 1
	FROM game.locations AS l
	JOIN LocationTree AS lt
		ON l.parent_id = lt.id
)
SELECT
	name AS [child name],
	level
FROM LocationTree;



-- block 6

WITH LocationTree AS
(
    SELECT 
    	id,
    	parent_id,
    	name,
    	0 AS level,
    	location_type,
    	difficulty,
    	reward
    FROM game.locations
    WHERE name = N'Северные земли'

    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name,
		lt.level + 1,
		l.location_type,
		l.difficulty,
		l.reward
	FROM game.locations AS l
	JOIN LocationTree AS lt
		ON l.parent_id = lt.id
)
SELECT
	name AS [child name],
	level,
	location_type as type,
	difficulty,
	reward
FROM LocationTree;



-- block 7

WITH MaxLevelReward AS
(
    SELECT
    	id,
    	parent_id,
    	name,
    	reward,
    	difficulty
    FROM game.locations
    WHERE parent_id is NULL
	
    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name,
		l.reward,
		l.difficulty
	FROM game.locations AS l
	JOIN MaxLevelReward AS mlr ON l.parent_id = mlr.id
),
MaxReward AS
(
	SELECT MAX(reward) AS max_reward
	FROM MaxLevelReward
)
SELECT
	mxl.name AS [level name],
	mxl.reward AS [reward],
	mxl.difficulty AS [difficulty]
FROM MaxLevelReward mxl
CROSS JOIN MaxReward mr
WHERE mxl.reward = mr.max_reward;



-- block 8

WITH WorldMap AS
(
    SELECT 
    	id,
    	parent_id,
    	name,
    	0 AS level,
    	CAST(name AS NVARCHAR(MAX)) AS sort_path
    FROM game.locations
    WHERE name = N'Королевство'

    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name,
		wm.level + 1,
		wm.sort_path + N'/' + l.name
	FROM game.locations AS l
	JOIN WorldMap AS wm
		ON l.parent_id = wm.id
)
SELECT
	REPLICATE(N'						', level) + name AS display_name
FROM WorldMap
ORDER BY sort_path;



-- final block

WITH LocationTree AS
(
    SELECT 
    	id,
    	parent_id,
    	name,
    	reward,
    	difficulty,
    	0 AS level,
    	CAST(name AS NVARCHAR(MAX)) AS sort_path
    FROM game.locations
    WHERE name = N'Королевство'

    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name,
		l.reward,
		l.difficulty,
		lt.level + 1,
		lt.sort_path + N'/' + l.name
	FROM game.locations AS l
	JOIN LocationTree AS lt
		ON l.parent_id = lt.id
)
SELECT
	REPLICATE(N'						', level) + name 
	+ N'	|	' + CAST(difficulty AS NVARCHAR(50)) 
	+ N'	|	' + CAST(reward AS NVARCHAR(50)) 
	AS display_name
FROM LocationTree
ORDER BY sort_path;



-- dop mission

WITH DangerMeter AS
(
    SELECT 
    	id,
    	parent_id,
    	name,
    	difficulty
    FROM game.locations
    WHERE name = N'Королевство'

    UNION ALL

    SELECT
		l.id,
		l.parent_id,
		l.name,
		l.difficulty
	FROM game.locations AS l
	JOIN DangerMeter AS dm
		ON l.parent_id = dm.id
)
SELECT
	name as location,
	difficulty,
	CASE
		WHEN difficulty BETWEEN 1 AND 3 THEN N'Безопасная'
		WHEN difficulty BETWEEN 4 AND 6 THEN N'Опасная'
		WHEN difficulty BETWEEN 7 AND 9 THEN N'Очень опасная'
		WHEN difficulty = 10 THEN N'Босс'
		ELSE N'Неизвестно'
	END AS danger_level
FROM DangerMeter;



-- bonus mission

WITH LocationRewardSum AS
(
    SELECT
    	parent_id,
    	COUNT(id) AS child_count,
        SUM(reward) AS reward_sum
    FROM game.locations
    WHERE parent_id IS NOT NULL
    GROUP BY parent_id
)
SELECT
	l.name  AS location, 
	lrs.reward_sum AS [reward sum]
FROM LocationRewardSum lrs
JOIN game.locations l ON lrs.parent_id = l.id
WHERE l.location_type = N'Локация'