CREATE TABLE Devices(
	SerialNumber		DECIMAL(10)	NOT NULL,
	DeviceTypeName		VARCHAR(30) NOT NULL,
	Brand				VARCHAR(15)	NOT NULL,
	ElectricUsage		DECIMAL(10)	NOT NULL,
	PRIMARY KEY(SerialNumber)
);

CREATE TABLE DeviceTypes(
	Name			VARCHAR(30)	NOT NULL,
	Description		VARCHAR(100) NOT NULL,
	WarrantyMonths	DECIMAL(2)	NOT NULL,
	PRIMARY KEY(Name)
);

ALTER TABLE Devices
ADD CONSTRAINT DEVICES_DEVICE_TYPES_FK FOREIGN KEY (DeviceName)
REFERENCES DeviceTypes (Name);

INSERT INTO "DeviceTypes"("Name", "Description", "WarrantyMonths")
VALUES('Televisores', 'Tipo para Smart TVs', 12);

INSERT INTO "Devices"("SerialNumber", "DeviceTypeName", "Brand", "ElectricUsage")
VALUES(1234567890, 'Televisores', 'Samsung', 300);

SELECT * FROM "Devices";