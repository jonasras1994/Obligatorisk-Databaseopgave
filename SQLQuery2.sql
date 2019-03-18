CREATE TABLE DemoFacilities( Hotel_No INT PRIMARY KEY NOT NULL, Swimmingpool BIT NOT
NULL, Tabletennis BIT NOT NULL, Pooltable BIT NOT NULL, Bar BIT NOT NULL, FOREIGN
KEY(Hotel_No) REFERENCES DemoHotel(Hotel_No));