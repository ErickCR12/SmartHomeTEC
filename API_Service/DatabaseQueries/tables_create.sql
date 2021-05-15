CREATE TABLE admin
(
    username VARCHAR (10) NOT NULL,
    password VARCHAR (20) NOT NULL,
    PRIMARY KEY (username)
);

CREATE TABLE clients
(
    email       VARCHAR (50) NOT NULL,
    name        VARCHAR (20) NOT NULL,
    password    VARCHAR (20) NOT NULL,
    last_name1  VARCHAR (20) NOT NULL,
    last_name2  VARCHAR (20) NOT NULL,
    country     VARCHAR (20) NOT NULL,
    continent   VARCHAR (20) NOT NULL,
    PRIMARY KEY (email)
);

CREATE TABLE device_distributor
(
     devices_serial_number   DECIMAL NOT NULL,
     distributors_legal_card DECIMAL NOT NULL,
     PRIMARY KEY (devices_serial_number, distributors_legal_card)
);


CREATE TABLE device_types
(
    name            VARCHAR (50)  NOT NULL,
    description     VARCHAR (255) NOT NULL,
    warranty_months DECIMAL       NOT NULL,
    PRIMARY KEY (name)
);

CREATE TABLE devices
(
    serial_number    DECIMAL      NOT NULL,
    brand            VARCHAR (20) NOT NULL,
    electric_usage   DECIMAL      NOT NULL,
    price            DECIMAL      NOT NULL,
    device_type_name VARCHAR (50) NOT NULL,
    client_email     VARCHAR (50),
    PRIMARY KEY (serial_number)
);

CREATE TABLE directions_clients
(
    direction 		VARCHAR (255) NOT NULL,
    client_email 	VARCHAR (255) NOT NULL,
    PRIMARY KEY (direction)
);

CREATE TABLE distributors
(
    legal_card  DECIMAL      NOT NULL,
    name        VARCHAR (20) NOT NULL,
    country     VARCHAR (20) NOT NULL,
    continent   VARCHAR (20) NOT NULL,
    PRIMARY KEY (legal_card)
);

CREATE TABLE orders
(
    bill_number          INT GENERATED ALWAYS AS IDENTITY,
    consecutive          DECIMAL      NOT NULL,
    price                DECIMAL      NOT NULL,
    purchase_date        DATE         NOT NULL,
    purchase_time        CHAR (5)     NOT NULL,
    client_email         VARCHAR (50) NOT NULL,
    device_serial_number DECIMAL      NOT NULL,
    PRIMARY KEY (consecutive, bill_number)
);

CREATE TABLE regions
(
    country     VARCHAR (20) NOT NULL,
    continent   VARCHAR (20) NOT NULL,
    PRIMARY KEY (country, continent)
);

CREATE TABLE device_state
(
	device_serial_number DECIMAL 	 NOT NULL,
	action				 VARCHAR (8) NOT NULL,
	minutes_action		 DECIMAL 	 NOT NULL,
	date				 DATE		 NOT NULL,
	time				 CHAR    (5) NOT NULL,
	PRIMARY KEY(device_serial_number, action, date, time)
);

ALTER TABLE clients
ADD CONSTRAINT CLIENTS_REGIONS_FK FOREIGN KEY (continent, country)
REFERENCES regions (continent, country);

ALTER TABLE device_distributor
ADD CONSTRAINT DEVICE_DISTRIBUTOR_SDEVICES_FK FOREIGN KEY (devices_serial_number)
REFERENCES devices (serial_number) ON DELETE CASCADE;

ALTER TABLE device_distributor
ADD CONSTRAINT DEVICE_DISTRIBUTOR_DISTRIBUTORS_FK FOREIGN KEY (distributors_legal_card)
REFERENCES distributors (legal_card);

ALTER TABLE devices
ADD CONSTRAINT DEVICES_DEVICE_TYPES_FK FOREIGN KEY (device_type_name)
REFERENCES device_types (name) ON DELETE CASCADE;

ALTER TABLE devices
ADD CONSTRAINT DEVICES_CLIENTS_FK FOREIGN KEY (client_email)
REFERENCES clients (email);

ALTER TABLE directions_clients
ADD CONSTRAINT DIRECTIONS_CLIENTS_CLIENTS_FK FOREIGN KEY (client_email)
REFERENCES clients (email);

ALTER TABLE distributors
ADD CONSTRAINT DISTRIBUTORS_REGIONS_FK FOREIGN KEY (continent, country)
REFERENCES regions (continent, country);

ALTER TABLE orders
ADD CONSTRAINT ORDERS_DEVICES_FK FOREIGN KEY (device_serial_number)
REFERENCES devices (serial_number) ON DELETE CASCADE;

ALTER TABLE orders
ADD CONSTRAINT ORDERS_CLIENTS_FK FOREIGN KEY (client_email)
REFERENCES clients (email);

ALTER TABLE device_state
ADD CONSTRAINT DEVICE_STATE_DEVICES_FK FOREIGN KEY (device_serial_number)
REFERENCES devices (serial_number) ON DELETE CASCADE;


INSERT INTO admin(username, password)
	VALUES ('admin', 'admin123');
	
INSERT INTO regions(country, continent)
	VALUES ('Costa Rica', 'America');
INSERT INTO regions(country, continent)
	VALUES ('Panama', 'America');
INSERT INTO regions(country, continent)
	VALUES ('España', 'Europa');
	
INSERT INTO clients(email, name, password, last_name1, last_name2, country, continent)
	VALUES('erick.barrantes12@gmail.com', 'Erick', 'cliente1', 'Barrantes', 'Cerdas', 'Costa Rica', 'America');	
INSERT INTO clients(email, name, password, last_name1, last_name2, country, continent)
	VALUES('joshuag@gmail.com', 'Joshua', 'cliente2', 'Guzmán', 'Quesada', 'Panama', 'America');
	
INSERT INTO device_types(name, description, warranty_months)
	VALUES ('Refrigeradoras doble puerta', 'Refrigeradoras inteligentes con dos puertas', 24);
INSERT INTO device_types(name, description, warranty_months)
	VALUES ('SmartTV Android', 'Televisores inteligentes con sistema Android', 12);
	
INSERT INTO devices( serial_number, brand, electric_usage, price, device_type_name)
	VALUES (54345, 'LG', 80, 649, 'Refrigeradoras doble puerta');
INSERT INTO devices( serial_number, brand, electric_usage, price, device_type_name)
	VALUES (45267, 'Frigidaire', 75, 659, 'Refrigeradoras doble puerta');	
INSERT INTO devices( serial_number, brand, electric_usage, price, device_type_name)
	VALUES (71458, 'Samsumg', 40, 499, 'SmartTV Android');
INSERT INTO devices( serial_number, brand, electric_usage, price, device_type_name)
	VALUES (11858, 'Sony', 45, 599, 'SmartTV Android');
	

INSERT INTO distributors(legal_card, name, country, continent)
	VALUES (3001, 'DistriRefri', 'Costa Rica', 'America');
INSERT INTO distributors(legal_card, name, country, continent)
	VALUES (4002, 'Electro Star', 'Panama', 'America');

INSERT INTO device_state(device_serial_number, action, minutes_action, date, "time")
	VALUES (54345, 'Apagar', 35, '2021/05/14', '07:15');
	
INSERT INTO device_state(device_serial_number, action, minutes_action, date, "time")
	VALUES (54345, 'Encender', 60, '2021/05/14', '08:15');
	
INSERT INTO device_state(device_serial_number, action, minutes_action, date, "time")
	VALUES (54345, 'Apagar', 65, '2021/05/14', '09:20');
	