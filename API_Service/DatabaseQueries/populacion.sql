
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
INSERT INTO devices( serial_number, brand, electric_usage, price, device_type_name, client_email)
	VALUES (12345, 'Philips', 35, 399, 'SmartTV Android', 'erick.barrantes12@gmail.com');
	

INSERT INTO distributors(legal_card, name, country, continent)
	VALUES (3001, 'DistriRefri', 'Costa Rica', 'America');
INSERT INTO distributors(legal_card, name, country, continent)
	VALUES (4002, 'Electro Star', 'Panama', 'America');

INSERT INTO device_state(device_serial_number, action, minutes_action, date, "time")
	VALUES (12345, 'Apagar', 35, '2021/05/14', '07:15');
INSERT INTO device_state(device_serial_number, action, minutes_action, date, "time")
	VALUES (12345, 'Encender', 60, '2021/05/14', '08:15');
INSERT INTO device_state(device_serial_number, action, minutes_action, date, "time")
	VALUES (12345, 'Apagar', 65, '2021/05/14', '09:20');