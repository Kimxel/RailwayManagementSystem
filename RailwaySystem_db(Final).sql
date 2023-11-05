CREATE DATABASE RailwaySystem_db
USE RailwaySystem_db

CREATE TABLE Train
(
	TrainID  CHAR (6) NOT NULL,
	TrainName VARCHAR (50) NOT NULL,
	TrainCap INT NOT NULL,
	TrainStatus VARCHAR (50) NOT NULL,
	PRIMARY KEY (TrainID),
);

CREATE TABLE Passenger
(
	PId CHAR (6) NOT NULL,
	PName VARCHAR (50) NOT NULL,
	PAdd VARCHAR (50) NOT NULL,
	PPhone VARCHAR (50) NOT NULL,
	PRIMARY KEY (PId),
);

CREATE TABLE Travel
(
	TravCode CHAR (6) NOT NULL,
	TravDate DATETIME NOT NULL,
	TrainID CHAR (6) NOT NULL,
	Src VARCHAR (50) NOT NULL,
	Dest VARCHAR (50) NOT NULL,
	Cost INT NOT NULL,
	PRIMARY KEY (TravCode),
	FOREIGN KEY (TrainID) REFERENCES Train (TrainID),
);

CREATE TABLE Reservation
(
	TicketID CHAR (6) NOT NULL,
	PId CHAR (6) NOT NULL,
	TravCode CHAR (6) NOT NULL,
	Pname VARCHAR (50) NOT NULL,
	TravDate DATETIME NOT NULL,
	TravSrc VARCHAR (50) NOT NULL,
	TravDest VARCHAR (50) NOT NULL,
	TravCost INT NOT NULL,
	PRIMARY KEY (TicketID),
	FOREIGN KEY (PId) REFERENCES Passenger (PId),
	FOREIGN KEY (TravCode) REFERENCES Travel (TravCode),  
);

CREATE TABLE Cancellation
(
	CancID CHAR (6) NOT NULL,
	TicketID CHAR (6) NOT NULL,
	CancDate DATETIME NOT NULL,
	PRIMARY KEY (CancID),
	FOREIGN KEY (TicketID) REFERENCES Reservation (TicketID),
);

INSERT INTO Train VALUES ('TRN001', 'Malabar', '300', 'Beroperasi');
INSERT INTO Train VALUES ('TRN002', 'Ranggajati', '250', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN003', 'Gumarang', '360', 'Beroperasi');
INSERT INTO Train VALUES ('TRN004', 'Ciremai', '400', 'Beroperasi');
INSERT INTO Train VALUES ('TRN005', 'Sindang Marga', '280', 'Beroperasi');
INSERT INTO Train VALUES ('TRN006', 'Sribilah Utama', '380', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN007', 'Purwosari', '320', 'Beroperasi');
INSERT INTO Train VALUES ('TRN008', 'Sembrani', '280', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN009', 'Gajayana', '180', 'Beroperasi');
INSERT INTO Train VALUES ('TRN010', 'Purwojaya', '300', 'Beroperasi');
INSERT INTO Train VALUES ('TRN011', 'Argo Bromo', '420', 'Beroperasi');
INSERT INTO Train VALUES ('TRN012', 'Bima', '200', 'Beroperasi');
INSERT INTO Train VALUES ('TRN013', 'Turangga', '300', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN014', 'Taksaka', '360', 'Beroperasi');
INSERT INTO Train VALUES ('TRN015', 'Sancaka', '270', 'Beroperasi');
INSERT INTO Train VALUES ('TRN016', 'Mutiara Timur', '220', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN017', 'Fajar Utama', '120', 'Beroperasi');
INSERT INTO Train VALUES ('TRN018', 'Sidomukti', '180', 'Beroperasi');
INSERT INTO Train VALUES ('TRN019', 'Jayabaya', '230', 'Beroperasi');
INSERT INTO Train VALUES ('TRN020', 'Ambarawa Ekspres', '400', 'Beroperasi');
INSERT INTO Train VALUES ('TRN021', 'Matar,aja', '290', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN022', 'Logawa', '240', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN023', 'Tawang Jaya', '150', 'Beroperasi');
INSERT INTO Train VALUES ('TRN024', 'Sri Tanjung', '200', 'Beroperasi');
INSERT INTO Train VALUES ('TRN025', 'Maharani', '230', 'Beroperasi');
INSERT INTO Train VALUES ('TRN026', 'Kamandaka', '320', 'Beroperasi');
INSERT INTO Train VALUES ('TRN027', 'Blora Jaya', '300', 'Tidak Beroperasi');
INSERT INTO Train VALUES ('TRN028', 'Delta Ekspress', '350', 'Beroperasi');
INSERT INTO Train VALUES ('TRN029', 'Jenggala', '200', 'Beroperasi');
INSERT INTO Train VALUES ('TRN030', 'Pangrango', '240', 'Tidak Beroperasi');

INSERT INTO Passenger VALUES ('PSG001', 'Cheryl Agustin', 'Permata 2', '081252387934');
INSERT INTO Passenger VALUES ('PSG002', 'Theodore', 'Puri Permai', '081371836892');
INSERT INTO Passenger VALUES ('PSG003', 'Sebastian', 'Indah Kapuk', '085283492896');
INSERT INTO Passenger VALUES ('PSG004', 'Arvito Chandra', 'Reni Jaya', '081315667234');
INSERT INTO Passenger VALUES ('PSG005', 'Sheren Olivia', 'Permata 1', '085836218936');
INSERT INTO Passenger VALUES ('PSG006', 'Jonathan', 'Graha Mas', '089127343897');
INSERT INTO Passenger VALUES ('PSG007', 'Monalisa', 'Griya Hijau', '081274289325');
INSERT INTO Passenger VALUES ('PSG008', 'Febrianti', 'Perum Taman Fasco', '087834620852');
INSERT INTO Passenger VALUES ('PSG009', 'Irene Clarytin', 'Batan Indah', '085280379042');
INSERT INTO Passenger VALUES ('PSG010', 'Haikal Putera', 'Amarapura 1', '081252382738');
INSERT INTO Passenger VALUES ('PSG011', 'Davin Timothy', 'Pondok Maharta', '081827382523');
INSERT INTO Passenger VALUES ('PSG012', 'Jeklin Harefa', 'Mangu Indah', '081212557214');
INSERT INTO Passenger VALUES ('PSG013', 'Julian Wesley', 'Amarapura 2', '085237084937');
INSERT INTO Passenger VALUES ('PSG014', 'Lydia', 'Villa Dago', '085836289436');
INSERT INTO Passenger VALUES ('PSG015', 'Fani', 'Bintaro 2', '081252384538');
INSERT INTO Passenger VALUES ('PSG016', 'Michael Saputra', 'Bukit Dago', '085282381296');
INSERT INTO Passenger VALUES ('PSG017', 'Fikhi Arman', 'Mutiara Serpong', '081264385297');
INSERT INTO Passenger VALUES ('PSG018', 'Mellinda', 'Pamulang 2', '081381582289');
INSERT INTO Passenger VALUES ('PSG019', 'Dimas Arya', 'Alam Sutera', '089830274892');
INSERT INTO Passenger VALUES ('PSG020', 'Destiara', 'Pondok Aren', '089173452738');
INSERT INTO Passenger VALUES ('PSG021', 'Faleria Gladista', 'Nusa Indah', '082034782386');
INSERT INTO Passenger VALUES ('PSG022', 'Gracella', 'Griya Setu', '0812308138754');
INSERT INTO Passenger VALUES ('PSG023', 'Jody Raphael', 'Pamulang Permai', '082376102938');
INSERT INTO Passenger VALUES ('PSG024', 'Samuel', 'Asri Kemuning', '081273497638');
INSERT INTO Passenger VALUES ('PSG025', 'Sion Candra', 'Griya Asri', '082374651235');
INSERT INTO Passenger VALUES ('PSG026', 'John Andi', 'Pondok Payung Mas', '081256712985');
INSERT INTO Passenger VALUES ('PSG027', 'Cyntia Pebriani', 'Nusa Indah', '081363287381');
INSERT INTO Passenger VALUES ('PSG028', 'Wisnu Kusuma', 'Nerada Paradise', '082937453895');
INSERT INTO Passenger VALUES ('PSG029', 'Maria', 'Griya Jakarta', '081204713892');
INSERT INTO Passenger VALUES ('PSG030', 'Claudia', 'Graha Raya', '085208738026');

INSERT INTO Travel VALUES ('TRV001', '2022-05-24 08:00', 'TRN001', 'Gambir', 'Semarangtawang', 18000);
INSERT INTO Travel VALUES ('TRV002', '2022-06-12 13:50', 'TRN002', 'Cirebon', 'Gambir', 13000);
INSERT INTO Travel VALUES ('TRV003', '2022-07-14 09:38', 'TRN003', 'Surabaya', 'Malang', 15000);
INSERT INTO Travel VALUES ('TRV004', '2022-08-10 14:23', 'TRN004', 'Malang', 'Bandung', 22000);
INSERT INTO Travel VALUES ('TRV005', '2022-06-23 17:04', 'TRN005', 'Bekasi', 'Pasar Senen', 11000);
INSERT INTO Travel VALUES ('TRV006', '2022-04-29 12:14', 'TRN006', 'Madiun', 'Jember', 17000);
INSERT INTO Travel VALUES ('TRV007', '2022-07-04 10:50', 'TRN007', 'Tegal', 'Padalarang', 19000);
INSERT INTO Travel VALUES ('TRV008', '2022-05-12 13:08', 'TRN008', 'Blitar', 'Kutoarjo', 21000);
INSERT INTO Travel VALUES ('TRV009', '2022-06-09 17:48', 'TRN009', 'Cirebon', 'Cibatu', 12000);
INSERT INTO Travel VALUES ('TRV010', '2022-08-26 14:50', 'TRN010', 'Purwokerto', 'Gambir', 23000);
INSERT INTO Travel VALUES ('TRV011', '2022-04-17 15:42', 'TRN011', 'Cikampek', 'Bandung', 10000);
INSERT INTO Travel VALUES ('TRV012', '2022-07-29 17:12', 'TRN012', 'Kutoarjo', 'Pasar Senen', 15000);
INSERT INTO Travel VALUES ('TRV013', '2022-05-30 15:05', 'TRN013', 'Surabaya', 'Malang', 13000);
INSERT INTO Travel VALUES ('TRV014', '2022-06-12 14:57', 'TRN014', 'Cirebon', 'Solobalapan', 20000);
INSERT INTO Travel VALUES ('TRV015', '2022-08-03 11:03', 'TRN015', 'Purwosari', 'Blitar', 17000);
INSERT INTO Travel VALUES ('TRV016', '2022-04-18 19:07', 'TRN016', 'Lamongan', 'Gambir', 19000);
INSERT INTO Travel VALUES ('TRV017', '2022-09-26 12:17', 'TRN017', 'Porong', 'Surabaya', 22000);
INSERT INTO Travel VALUES ('TRV018', '2022-07-07 09:30', 'TRN018', 'Sidoarjo', 'Mojokerto', 14000);
INSERT INTO Travel VALUES ('TRV019', '2022-06-15 10:50', 'TRN019', 'Padalarang', 'Cicalengka', 16000);
INSERT INTO Travel VALUES ('TRV020', '2022-08-22 14:15', 'TRN020', 'Bogor', 'Rawa Buntu', 10000);
INSERT INTO Travel VALUES ('TRV021', '2022-05-02 17:31', 'TRN021', 'Serpong', 'Bekasi', 12000);
INSERT INTO Travel VALUES ('TRV022', '2022-04-30 18:55', 'TRN022', 'Jurang Mangu', 'Gambir', 15000);
INSERT INTO Travel VALUES ('TRV023', '2022-08-01 12:04', 'TRN023', 'Tangerang', 'Bandung', 19000);
INSERT INTO Travel VALUES ('TRV024', '2022-09-17 20:47', 'TRN024', 'Malang', 'Sudimara', 21000);
INSERT INTO Travel VALUES ('TRV025', '2022-07-19 09:15', 'TRN025', 'Cikampek', 'Lamongan', 10000);
INSERT INTO Travel VALUES ('TRV026', '2022-06-26 14:30', 'TRN026', 'Brebes', 'Sukabumi', 13000);
INSERT INTO Travel VALUES ('TRV027', '2022-10-19 08:56', 'TRN027', 'Semarang', 'Solo', 15000);
INSERT INTO Travel VALUES ('TRV028', '2022-09-22 14:03', 'TRN028', 'Blitar', 'Surabaya', 20000);
INSERT INTO Travel VALUES ('TRV029', '2022-05-09 09:05', 'TRN029', 'Bojonegoro', 'Banyuwangi', 23000);
INSERT INTO Travel VALUES ('TRV030', '2022-06-28 11:01', 'TRN030', 'Bogor', 'Pasar Senen', 14000);

INSERT INTO Reservation VALUES ('TCKT01', 'PSG001', 'TRV001', 'Cheryl Agustin', '2022-05-24 08:00', 'Gambir', 'Semarangtawang', 18000);
INSERT INTO Reservation VALUES ('TCKT02', 'PSG002', 'TRV002', 'Theodore', '2022-06-12 13:50', 'Cirebon', 'Gambir', 13000);
INSERT INTO Reservation VALUES ('TCKT03', 'PSG003', 'TRV003', 'Sebastian', '2022-07-14 09:38', 'Surabaya', 'Malang', 15000);
INSERT INTO Reservation VALUES ('TCKT04', 'PSG004', 'TRV004', 'Arvito Chandra', '2022-08-10 14:23', 'Malang', 'Bandung', 22000);
INSERT INTO Reservation VALUES ('TCKT05', 'PSG005', 'TRV005', 'Sheren Olivia', '2022-06-23 17:04', 'Bekasi', 'Pasar Senen', 11000);
INSERT INTO Reservation VALUES ('TCKT06', 'PSG006', 'TRV006', 'Jonathan', '2022-04-29 12:14', 'Madiun', 'Jember', 17000);
INSERT INTO Reservation VALUES ('TCKT07', 'PSG007', 'TRV007', 'Monalisa', '2022-07-04 10:50', 'Tegal', 'Padalarang', 19000);
INSERT INTO Reservation VALUES ('TCKT08', 'PSG008', 'TRV008', 'Febrianti', '2022-05-12 13:08', 'Blitar', 'Kutoarjo', 21000);
INSERT INTO Reservation VALUES ('TCKT09', 'PSG009', 'TRV009', 'Irene Clarytin', '2022-06-09 17:48', 'Cirebon', 'Cibatu', 12000);
INSERT INTO Reservation VALUES ('TCKT10', 'PSG010', 'TRV010', 'Haikal Putera', '2022-08-26 14:50', 'Purwokerto', 'Gambir', 23000);
INSERT INTO Reservation VALUES ('TCKT11', 'PSG011', 'TRV011', 'Davin Timothy', '2022-04-17 15:42', 'Cikampek', 'Bandung', 10000);
INSERT INTO Reservation VALUES ('TCKT12', 'PSG012', 'TRV012', 'Jeklin Harefa', '2022-07-29 17:12', 'Kutoarjo', 'Pasar Senen', 15000);
INSERT INTO Reservation VALUES ('TCKT13', 'PSG013', 'TRV013', 'Julian Wesley', '2022-05-30 15:05', 'Surabaya', 'Malang', 13000);
INSERT INTO Reservation VALUES ('TCKT14', 'PSG014', 'TRV014', 'Lydia', '2022-06-12 14:57','Cirebon', 'Solobalapan', 20000);
INSERT INTO Reservation VALUES ('TCKT15', 'PSG015', 'TRV015', 'Fani Claudia', '2022-08-03 11:03', 'Purwosari', 'Blitar', 17000);
INSERT INTO Reservation VALUES ('TCKT16', 'PSG016', 'TRV016', 'Michael Saputra', '2022-04-18 19:07', 'Lamongan', 'Gambir', 19000);
INSERT INTO Reservation VALUES ('TCKT17', 'PSG017', 'TRV017', 'Fikhi Arman', '2022-09-26 12:17', 'Porong', 'Surabaya', 22000);
INSERT INTO Reservation VALUES ('TCKT18', 'PSG018', 'TRV018', 'Mellinda', '2022-07-07 09:30', 'Sidoarjo', 'Mojokerto', 14000);
INSERT INTO Reservation VALUES ('TCKT19', 'PSG019', 'TRV019', 'Dimas Arya', '2022-06-15 10:50', 'Padalarang', 'Cicalengka', 16000);
INSERT INTO Reservation VALUES ('TCKT20', 'PSG020', 'TRV020', 'Destiara', '2022-08-22 14:15', 'Bogor', 'Rawa Buntu', 10000);
INSERT INTO Reservation VALUES ('TCKT21', 'PSG021', 'TRV021', 'Faleria Gladista', '2022-05-02 17:31', 'Serpong', 'Bekasi', 12000);
INSERT INTO Reservation VALUES ('TCKT22', 'PSG022', 'TRV022', 'Gracella', '2022-04-30 18:55', 'Jurang Mangu', 'Gambir', 15000);
INSERT INTO Reservation VALUES ('TCKT23', 'PSG023', 'TRV023', 'Jody Raphael', '2022-08-01 12:04', 'Tangerang', 'Bandung', 19000);
INSERT INTO Reservation VALUES ('TCKT24', 'PSG024', 'TRV024', 'Martinus Samuel', '2022-09-17 20:47', 'Malang', 'Sudimara', 21000);
INSERT INTO Reservation VALUES ('TCKT25', 'PSG025', 'TRV025', 'Sion Candra', '2022-07-19 09:15', 'Cikampek', 'Lamongan', 10000);
INSERT INTO Reservation VALUES ('TCKT26', 'PSG026', 'TRV026', 'John Andi', '2022-06-26 14:30', 'Brebes', 'Sukabumi', 13000);
INSERT INTO Reservation VALUES ('TCKT27', 'PSG027', 'TRV027', 'Cyntia Pebriani', '2022-10-19 08:56', 'Semarang', 'Solo', 15000);
INSERT INTO Reservation VALUES ('TCKT28', 'PSG028', 'TRV028', 'Wisnu Kusuma', '2022-09-22 14:03', 'Blitar', 'Surabaya', 20000);
INSERT INTO Reservation VALUES ('TCKT29', 'PSG029', 'TRV029', 'Maria Theresa', '2022-05-09 09:05', 'Bojonegoro', 'Banyuwangi', 23000);
INSERT INTO Reservation VALUES ('TCKT30', 'PSG030', 'TRV030', 'Claudia', '2022-06-28 11:01', 'Bogor', 'Pasar Senen', 14000);

INSERT INTO Cancellation VALUES ('CNCL01', 'TCKT01', '2022-05-01 11:30');
INSERT INTO Cancellation VALUES ('CNCL02', 'TCKT02', '2022-05-20 13:40');
INSERT INTO Cancellation VALUES ('CNCL03', 'TCKT03', '2022-06-11 14:08');
INSERT INTO Cancellation VALUES ('CNCL04', 'TCKT04', '2022-04-09 15:22');
INSERT INTO Cancellation VALUES ('CNCL05', 'TCKT05', '2022-06-01 12:50');
INSERT INTO Cancellation VALUES ('CNCL06', 'TCKT06', '2022-05-05 14:57');
INSERT INTO Cancellation VALUES ('CNCL07', 'TCKT07', '2022-05-31 16:02');
INSERT INTO Cancellation VALUES ('CNCL08', 'TCKT08', '2022-06-12 16:17');
INSERT INTO Cancellation VALUES ('CNCL09', 'TCKT09', '2022-06-05 15:42');
INSERT INTO Cancellation VALUES ('CNCL10', 'TCKT10', '2022-05-10 16:44');
INSERT INTO Cancellation VALUES ('CNCL11', 'TCKT11', '2022-07-05 17:12');
INSERT INTO Cancellation VALUES ('CNCL12', 'TCKT12', '2022-04-01 18:37');
INSERT INTO Cancellation VALUES ('CNCL13', 'TCKT13', '2022-05-15 21:20');
INSERT INTO Cancellation VALUES ('CNCL14', 'TCKT14', '2022-07-25 20:23');
INSERT INTO Cancellation VALUES ('CNCL15', 'TCKT15', '2022-06-19 11:30');
INSERT INTO Cancellation VALUES ('CNCL16', 'TCKT16', '2022-04-15 02:14');
INSERT INTO Cancellation VALUES ('CNCL17', 'TCKT17', '2022-05-23 15:37');
INSERT INTO Cancellation VALUES ('CNCL18', 'TCKT18', '2022-06-20 09:30');
INSERT INTO Cancellation VALUES ('CNCL19', 'TCKT19', '2022-05-17 11:05');
INSERT INTO Cancellation VALUES ('CNCL20', 'TCKT20', '2022-06-18 18:03');
INSERT INTO Cancellation VALUES ('CNCL21', 'TCKT21', '2022-05-10 12:13');
INSERT INTO Cancellation VALUES ('CNCL22', 'TCKT22', '2022-08-23 15:30');
INSERT INTO Cancellation VALUES ('CNCL23', 'TCKT23', '2022-07-30 10:25');
INSERT INTO Cancellation VALUES ('CNCL24', 'TCKT24', '2022-04-24 16:28');
INSERT INTO Cancellation VALUES ('CNCL25', 'TCKT25', '2022-05-19 18:01');
INSERT INTO Cancellation VALUES ('CNCL26', 'TCKT26', '2022-08-01 11:13');
INSERT INTO Cancellation VALUES ('CNCL27', 'TCKT27', '2022-06-21 19:19');
INSERT INTO Cancellation VALUES ('CNCL28', 'TCKT28', '2022-08-10 13:48');
INSERT INTO Cancellation VALUES ('CNCL29', 'TCKT29', '2022-05-28 15:13');
INSERT INTO Cancellation VALUES ('CNCL30', 'TCKT30', '2022-07-12 01:12');

SELECT * FROM Train
SELECT * FROM Passenger
SELECT * FROM Travel
SELECT * FROM Reservation
SELECT * FROM Cancellation