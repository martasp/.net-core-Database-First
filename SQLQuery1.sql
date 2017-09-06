--@(#) script.ddl



CREATE TABLE Studentas
(
	vardas varchar (255),
	pavarde varchar (255),
	metai date,
	universitetas varchar (255),
	id_Studentas integer,
	fk_Destytojasid_Destytojas integer NOT NULL,
	PRIMARY KEY(id_Studentas),
	CONSTRAINT moko FOREIGN KEY(fk_Destytojasid_Destytojas) REFERENCES Destytojas (id_Destytojas)
);

CREATE TABLE Modulis
(
	kodas varchar (255),
	pavadinimas varchar (255),
	fk_Studentasid_Studentas integer NOT NULL,
	fk_Studentasid_Studentas1 integer NOT NULL,
	PRIMARY KEY(kodas),
	CONSTRAINT turi FOREIGN KEY(fk_Studentasid_Studentas) REFERENCES Studentas (id_Studentas),
	FOREIGN KEY(fk_Studentasid_Studentas1) REFERENCES Studentas (id_Studentas)
);

CREATE TABLE Atsiskaitymas
(
	pavadinimas varchar (255),
	pazymys int,
	id_Atsiskaitymas integer,
	fk_Studentasid_Studentas integer NOT NULL,
	PRIMARY KEY(id_Atsiskaitymas),
	CONSTRAINT atsiskaito FOREIGN KEY(fk_Studentasid_Studentas) REFERENCES Studentas (id_Studentas)
);