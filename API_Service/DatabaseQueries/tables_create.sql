CREATE TABLE admin
(
    username VARCHAR (255) NOT NULL,
    password VARCHAR (255) NOT NULL,
    PRIMARY KEY (username)
);

CREATE TABLE chambers
(
    name 			VARCHAR (255) NOT NULL,
    client_email 	VARCHAR (255) NOT NULL,
    PRIMARY KEY (name)
);

CREATE TABLE clients
(
    email 		VARCHAR (255) NOT NULL,
    name 		VARCHAR (255) NOT NULL,
    password 	VARCHAR (255) NOT NULL,
    last_name1 	VARCHAR (255) NOT NULL,
    last_name2 	VARCHAR (255) NOT NULL,
    country 	VARCHAR (255) NOT NULL,
    continent 	VARCHAR (255) NOT NULL,
    PRIMARY KEY (email)
);

CREATE TABLE device_distributor
(
    devices_serial_number	INT NOT NULL,
    distributors_legal_card INT NOT NULL,
    PRIMARY KEY (devices_serial_number, distributors_legal_card)
);


CREATE TABLE device_types
(
    name 			VARCHAR (255) NOT NULL,
    description 	VARCHAR (255) NOT NULL,
    warranty_months INT NOT NULL,
    PRIMARY KEY (name)
);

CREATE TABLE devices
(
    serial_number 		INT NOT NULL,
    brand 				VARCHAR (255) NOT NULL,
    electric_usage 		INT NOT NULL,
	price				INT NOT NULL,
    device_type_name 	VARCHAR (255) NOT NULL,
    client_email 		VARCHAR (255),
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
    legal_card 	INT NOT NULL,
    name 		VARCHAR (255) NOT NULL,
    country 	VARCHAR (255) NOT NULL,
    continent 	VARCHAR (255) NOT NULL,
    PRIMARY KEY (legal_card)
);

CREATE TABLE orders
(
    consecutive INT NOT NULL,
    bill_number INT GENERATED ALWAYS AS IDENTITY,
    price INT NOT NULL,
    purchase_date DATE NOT NULL,
    purchase_time CHAR (5) NOT NULL,
    client_email VARCHAR (255) NOT NULL,
    device_serial_number INT NOT NULL,
    PRIMARY KEY (consecutive, bill_number)
);

CREATE TABLE regions
(
    country 	VARCHAR (255) NOT NULL,
    continent 	VARCHAR (255) NOT NULL,
    PRIMARY KEY (country, continent)
);


ALTER TABLE chambers
ADD CONSTRAINT CHAMBERS_CLIENTS_FK FOREIGN KEY (client_email)
REFERENCES clients (email);

ALTER TABLE clients
ADD CONSTRAINT CLIENTS_REGIONS_FK FOREIGN KEY (continent, country)
REFERENCES regions (continent, country);

ALTER TABLE device_distributor
ADD CONSTRAINT DEVICE_DISTRIBUTOR_SDEVICES_FK FOREIGN KEY (devices_serial_number)
REFERENCES devices (serial_number);

ALTER TABLE device_distributor
ADD CONSTRAINT DEVICE_DISTRIBUTOR_DISTRIBUTORS_FK FOREIGN KEY (distributors_legal_card)
REFERENCES distributors (legal_card);

ALTER TABLE devices
ADD CONSTRAINT DEVICES_DEVICE_TYPES_FK FOREIGN KEY (device_type_name)
REFERENCES device_types (name);

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
REFERENCES devices (serial_number);

ALTER TABLE orders
ADD CONSTRAINT ORDERS_CLIENTS_FK FOREIGN KEY (client_email)
REFERENCES clients (email);




