-- DATABASE AND TABLES CREATION
CREATE DATABASE RealtyDB;

USE RealtyDB;


CREATE SCHEMA realty;


CREATE TABLE realty.agents
(
    id INT PRIMARY KEY,
    name NVARCHAR(100) NOT NULL
);

CREATE TABLE realty.clients
(
    id INT PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    phone NVARCHAR(30) NOT NULL
);

CREATE TABLE realty.properties
(
    id INT PRIMARY KEY,
    address NVARCHAR(200) NOT NULL,
    property_type NVARCHAR(50) NOT NULL,
    price DECIMAL(12, 2) NOT NULL,
    rooms INT NOT NULL,
    agent_id INT NOT NULL,

    CONSTRAINT FK_properties_agents
        FOREIGN KEY (agent_id)
        REFERENCES realty.agents(id)
);

CREATE TABLE realty.deals
(
    id INT PRIMARY KEY,
    client_id INT NOT NULL,
    property_id INT NOT NULL,
    agent_id INT NOT NULL,
    deal_date DATE NOT NULL,
    deal_price DECIMAL(12, 2) NOT NULL,

    CONSTRAINT FK_deals_clients
        FOREIGN KEY (client_id)
        REFERENCES realty.clients(id),

    CONSTRAINT FK_deals_properties
        FOREIGN KEY (property_id)
        REFERENCES realty.properties(id),

    CONSTRAINT FK_deals_agents
        FOREIGN KEY (agent_id)
        REFERENCES realty.agents(id)
);



-- VALUES INSERTING
INSERT INTO realty.agents (id, name)
VALUES
    (1, N'Анна Смирнова'),
    (2, N'Иван Петров'),
    (3, N'Мария Орлова');

INSERT INTO realty.clients (id, name, phone)
VALUES
    (1, N'Алексей Иванов', N'+7-900-111-11-11'),
    (2, N'Ольга Соколова', N'+7-900-222-22-22'),
    (3, N'Дмитрий Волков', N'+7-900-333-33-33'),
    (4, N'Елена Морозова', N'+7-900-444-44-44');

INSERT INTO realty.properties
(
    id,
    address,
    property_type,
    price,
    rooms,
    agent_id
)
VALUES
    (1, N'ул. Центральная, 10', N'Квартира', 5200000, 2, 1),
    (2, N'ул. Лесная, 25', N'Квартира', 6800000, 3, 1),
    (3, N'ул. Садовая, 7', N'Дом', 9500000, 4, 2),
    (4, N'ул. Молодёжная, 18', N'Квартира', 4300000, 3, 2),
    (5, N'ул. Речная, 4', N'Дом', 12500000, 5, 3),
    (6, N'ул. Школьная, 31', N'Квартира', 3900000, 1, 3);



-- PROCEDURES CREATING
CREATE PROCEDURE realty.FindProperties
	@max_price INT,
	@rooms INT
AS
BEGIN
	SELECT
		p.address,
		p.property_type,
		p.price,
		p.rooms,
		a.name
	FROM realty.properties p
	JOIN realty.agents a
		ON a.id = p.agent_id
	WHERE rooms = @rooms AND price <= @max_price;
END;

EXEC realty.FindProperties
    @max_price = 7000000,
    @rooms = 3;



CREATE PROCEDURE realty.GetClient
	@client_id INT
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM realty.clients WHERE id = @client_id)
	BEGIN
		THROW 50001, N'Client not exists', 1;
	END
	
	SELECT
		id,
		name,
		phone
	FROM realty.clients
	WHERE id = @client_id;
END;

EXEC realty.GetClient
    @client_id = 2;



CREATE PROCEDURE realty.CreateDeal
	@client_id INT,
	@property_id INT,
	@agent_id INT,
	@deal_price DECIMAL(12, 2),
	@deal_id INT = NULL OUTPUT
AS
BEGIN
	BEGIN TRY
		IF NOT EXISTS(SELECT 1 FROM realty.clients WHERE id = @client_id)
		BEGIN
			THROW 50001, N'Client not exists', 1;
		END;
		
		IF NOT EXISTS(SELECT 1 FROM realty.properties WHERE id = @property_id)
		BEGIN
			THROW 50002, N'Property not exists', 1;
		END;
		
		IF NOT EXISTS(SELECT 1 FROM realty.agents WHERE id = @agent_id)
		BEGIN
			THROW 50003, N'Agent not exists', 1;
		END;
		
		IF @deal_price < 1
		BEGIN
			THROW 50004, N'Price cannot be negative or zero', 1;
		END;
		
		DECLARE @new_deal_id INT = (SELECT ISNULL(MAX(id), 0) + 1 FROM realty.deals);
		
		INSERT INTO realty.deals
		(
			id,
			client_id,
			property_id,
			agent_id,
			deal_date,
			deal_price
		)
		
		VALUES
		(
			@new_deal_id,
			@client_id,
			@property_id,
			@agent_id,
			CAST(GETDATE() AS DATE),
			@deal_price
		);
		
		SET @deal_id = @new_deal_id;
	END TRY
	
	BEGIN CATCH
	    SELECT
	        ERROR_NUMBER() AS error_number,
	        ERROR_MESSAGE() AS error_message;
			THROW;
	END CATCH;
END;



-- TESTS

-- SCENARIO 1 - NORMAL
DECLARE @new_deal_id INT;

EXEC realty.CreateDeal
    @client_id = 1,
    @property_id = 2,
    @agent_id = 1,
    @deal_price = 6500000,
    @deal_id = @new_deal_id OUTPUT;


-- SCENARIO 2 - CLIENT_ID ERROR
DECLARE @new_deal_id INT;

EXEC realty.CreateDeal
    @client_id = 999,
    @property_id = 2,
    @agent_id = 1,
    @deal_price = 6500000,
    @deal_id = @new_deal_id OUTPUT;


-- SCENARIO 3 - DEAL_PRICE ERROR
DECLARE @new_deal_id INT;

EXEC realty.CreateDeal
    @client_id = 1,
    @property_id = 2,
    @agent_id = 1,
    @deal_price = -1000,
    @deal_id = @new_deal_id OUTPUT;


-- RESULT SHOWCASE
SELECT
    d.id,
    c.name AS client_name,
    p.address,
    a.name AS agent_name,
    d.deal_date,
    d.deal_price
FROM realty.deals d
JOIN realty.clients c
    ON c.id = d.client_id
JOIN realty.properties p
    ON p.id = d.property_id
JOIN realty.agents a
    ON a.id = d.agent_id;



-- FINAL TASK
CREATE PROCEDURE realty.GetAgentStatistics
	@agent_id INT
AS
BEGIN
	SELECT
		a.name,
		(SELECT COUNT(*) FROM realty.properties WHERE agent_id = a.id) AS properties_count,
		(SELECT COUNT(*) FROM realty.deals WHERE agent_id = a.id) AS deals_count,
		(SELECT SUM(deal_price) FROM realty.deals WHERE agent_id = a.id) AS total_price
		FROM realty.agents a
		WHERE a.id = @agent_id;
END;

EXEC realty.GetAgentStatistics
    @agent_id = 1;
