# HumaneSocietyProject

Austin's SQL Queries

INSERT INTO Categories Values ('dog');
INSERT INTO Categories Values ('cat');
INSERT INTO Categories Values ('dragon');
INSERT INTO Categories Values ('kangaroo');
INSERT INTO Categories Values ('pigeon');

INSERT INTO DietPlans Values ('Gain Weight Plan', 'Carbs', '10');
INSERT INTO DietPlans Values ('Lose Weight Plan', 'Protien', '7');
INSERT INTO DietPlans Values ('Vegitarian Plan', 'vegitables', '15');
INSERT INTO DietPlans Values ('Carnivore Plan', 'Meat', '12');
INSERT INTO DietPlans Values ('Seafood Plan', 'seafood', '8');

INSERT INTO Employees Values ('Austin', 'Barry', 'ABarry', 'Password1', '0001', 'ABarry@HumaneSociety.com')
INSERT INTO Employees Values ('Sean', 'Clennan', 'SClennan', 'Password2', '0002', 'SClennan@HumaneSociety.com')
INSERT INTO Employees Values ('Nevin', 'Seibel', 'NSeibel', 'Password3', '0003', 'NSeibel@HumaneSociety.com')
INSERT INTO Employees Values ('Gustavo', 'Olea', 'GOlea', 'Password4', '0004', 'GOlea@HumaneSociety.com')
INSERT INTO Employees Values ('Matthew', 'Acker', 'MAcker', 'Password5', '0005', 'MAcker@HumaneSociety.com')

INSERT INTO Addresses Values ('313 N Plankinton', 'Milwaukee', '49','53217')

INSERT INTO Clients VALUES('Paul', 'Jirovetz', 'PJirovetz', 'Password1', 1, 'PJirovetz@DDC.com')
INSERT INTO Clients VALUES('Brett', 'Johnson', 'BJohnson', 'Password2', 1, 'BJohnson@DDC.com')
INSERT INTO Clients VALUES('David', 'Lagrange', 'DLagrange', 'Password3', 1, 'DLagrange@DDC.com')
INSERT INTO Clients VALUES('Michael', 'Terrill', 'MTerrill', 'Password4', 1, 'MTerrill@DDC.com')
INSERT INTO Clients VALUES('Michael', 'Heinisch', 'MHeinisch', 'Password5', 1, 'MHeinisch@DDC.com')

INSERT INTO Animals Values ('Air Bud', 80, 4, 'Lazy', 1, 1, 'Male', 'Not Adopted', 1, 4, 1);
INSERT INTO Animals Values ('Eragon', 40000, 600, 'Wise', 1, 1, 'Female', 'Processing', 3, 2, 1);
INSERT INTO Animals Values ('Jack', 260, 4, 'Active', 0, 0, 'Male', 'Not Adopted', 4, 4, 2);
INSERT INTO Animals Values ('Garfield', 180, 4, 'Extremely Lazy', 1, 0, 'Male', 'Not Adopted', 2, 2, 4);
INSERT INTO Animals Values ('Toothless', 8000, 4, 'Playful', 1, 1, 'Male', 'Not Adopted', 3, 5, 5);
INSERT INTO Animals Values ('Trash', 80, 4, 'Sneaky', 0, 0, 'Male', 'Not Adopted', 5, 2, 5);
INSERT INTO Animals Values ('Air Rat', 80, 3, 'Cunning', 1, 0, 'Female', 'Not Adopted', 5, 1, 5);
INSERT INTO Animals Values ('Garbage', 80, 6, 'Glutonous', 0, 0, 'Male', 'Not Adopted', 5, 3, 5);
INSERT INTO Animals Values ('Flamingo', 80, 3, 'Obsessive', 1, 1, 'Female', 'Not Adopted', 2, 1, 5);
INSERT INTO Animals Values ('Mailman', 80, 4, 'Disaplined', 1, 1, 'Male', 'Not Adopted', 5, 3, 5);

INSERT INTO Rooms VALUES (101, 1)
INSERT INTO Rooms VALUES (102, 2)
INSERT INTO Rooms VALUES (103, 3)
INSERT INTO Rooms VALUES (104, 4)
INSERT INTO Rooms VALUES (105, 5)
INSERT INTO Rooms VALUES (106, null)
INSERT INTO Rooms VALUES (107, null)
INSERT INTO Rooms VALUES (108, null)
INSERT INTO Rooms VALUES (109, null)
INSERT INTO Rooms VALUES (110, null)


Sean's SQL Queries

INSERT INTO HumaneSociety.Category VALUES ('dog');
INSERT INTO HumaneSociety.Category VALUES ('cat');
INSERT INTO HumaneSociety.Category VALUES ('bird');
INSERT INTO HumaneSociety.Category VALUES ('kangaroo');
INSERT INTO HumaneSociety.Category VALUES ('turtle');

INSERT INTO DietPlans VALUES ('herbivore','plants', 10);
INSERT INTO DietPlans VALUES ('omnivore','combo', 10);
INSERT INTO DietPlans VALUES ('carnivore','meat', 10);
INSERT INTO DietPlans VALUES ('lose weight','plants', 6);
INSERT INTO DietPlans VALUES ('gain weight','combo', 15);

INSERT INTO Employees VALUES ('Sean','Clennan','username', 'securepassword', '001', 'email@gmail.com');
INSERT INTO Employees VALUES ('Austin','Barry','nextemployee', 'goodpassword', '002', 'email@hotmail.com');
INSERT INTO Employees VALUES ('Nevin','Seibel','zookeeper', 'badpassword', '003', 'nevin@dcc.com');
INSERT INTO Employees VALUES ('Zac','Melton','ZMelton', 'qwerty1234', '004', 'zac@gmail.com');
INSERT INTO Employees VALUES ('Gustavo','Sanchez','GSanchez', 'password', '005', 'GSanchez@gmail.com');

INSERT INTO Addresses VALUES ('313 N Plankinton St','Milwaukee',49, 53217);

INSERT INTO Clients VALUES ('Mike','Terrill', 'MTerrill', 'password', 1, 'mterrill@dcc.com');
INSERT INTO Clients VALUES ('Mike','Heinisch', 'MHeinisch', 'password', 1, 'mheinisch@dcc.com');
INSERT INTO Clients VALUES ('Paul','Jirovetz', 'PJirovetz', 'password', 1, 'pjirovetz@dcc.com');
INSERT INTO Clients VALUES ('Brett','Johnson', 'BJohnson', 'password', 1, 'bjohnson@dcc.com');
INSERT INTO Clients VALUES ('David','Lagrange', 'DLagrange', 'password', 1, 'dlagrange@dcc.com');

INSERT INTO Animals VALUES ('Buddy', 80, 8, 'friendly', 1, 1, 'm', 'not adopted', 1, 2, 1);
INSERT INTO Animals VALUES ('Rufus', 20, 3, 'curious', 0, 1, 'm', 'not adopted', 1, 2, 2);
INSERT INTO Animals VALUES ('Garfield', 35, 6, 'lazy', 1, 0, 'm', 'not adopted', 2, 4, 3);
INSERT INTO Animals VALUES ('Nala', 65, 4, 'timid', 1, 1, 'f', 'not adopted', 2, 3, 4);
INSERT INTO Animals VALUES ('Tweety', 5, 2, 'shy', 1, 1, 'f', 'not adopted', 3, 1, 5);
INSERT INTO Animals VALUES ('Ho-oh', 130, 100, 'aggreessive', 0, 0, 'm', 'not adopted', 3, 2, 2);
INSERT INTO Animals VALUES ('Roo', 90, 4, 'friendly', 1, 1, 'm', 'not adopted', 4, 2, 1);
INSERT INTO Animals VALUES ('Punchy', 200, 15, 'aggressive', 0, 0, 'm', 'not adopted', 4, 3, 3);
INSERT INTO Animals VALUES ('Leonardo', 30, 8, 'sneaky', 1, 1, 'm', 'not adopted', 5, 2, 4);
INSERT INTO Animals VALUES ('Michelangelo', 25, 8, 'sneaky', 1, 1, 'm', 'not adopted', 5, 2, 5);

INSERT INTO Rooms VALUES (101,null);
INSERT INTO Rooms VALUES (102,2);
INSERT INTO Rooms VALUES (103,null);
INSERT INTO Rooms VALUES (104,3);
INSERT INTO Rooms VALUES (105,null);
INSERT INTO Rooms VALUES (106,5);
INSERT INTO Rooms VALUES (107,null);
INSERT INTO Rooms VALUES (108,7);
INSERT INTO Rooms VALUES (109,null);
INSERT INTO Rooms VALUES (110,9);

