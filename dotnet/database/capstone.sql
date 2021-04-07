USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

BEGIN TRANSACTION
--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
);

CREATE TABLE tournaments (
tournament_id int IDENTITY NOT NULL,
creator_id int NOT NULL,
tournament_name varchar(50) NOT NULL,
sport_id int NOT NULL,
tour_status varchar(15) Default 'Recruiting',
CONSTRAINT  tournaments_tournament_id  PRIMARY KEY (tournament_id),
CONSTRAINT tournaments_tour_status CHECK (tour_status IN ('Recruiting', 'Active', 'Completed'))
);

CREATE TABLE sports (
sport_id int IDENTITY NOT NULL,
sport_name varchar(50) NOT NULL,
CONSTRAINT  sport_sport_id  PRIMARY KEY (sport_id),
);

CREATE TABLE participants (
	tournament_id integer NOT NULL,
	user_id integer NOT NULL,
	CONSTRAINT participants_tournament_id_user_id PRIMARY KEY (tournament_id, user_id)
);

--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
--admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

SET IDENTITY_INSERT tournaments ON
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (1, 2, 'soccer is a sport', 1, 'Recruiting');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (2, 2, 'baseball is a sport', 2, 'Active');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (3, 2, 'basketball is a sport', 3, 'Completed');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (4, 1, 'Not admin on purpose', 1, 'Recruiting');
SET IDENTITY_INSERT tournaments OFF

SET IDENTITY_INSERT sports ON
INSERT INTO sports (sport_id ,sport_name ) VALUES (1, 'soccer');
INSERT INTO sports (sport_id ,sport_name ) VALUES (2, 'baseball');
INSERT INTO sports (sport_id ,sport_name ) VALUES (3, 'basketball');
SET IDENTITY_INSERT sports OFF


INSERT INTO participants (tournament_id , user_id ) VALUES (1, 1);
INSERT INTO participants (tournament_id , user_id ) VALUES (2, 1);
INSERT INTO participants (tournament_id , user_id ) VALUES (3, 1);


GO

ALTER TABLE tournaments
ADD FOREIGN KEY (sport_id)
REFERENCES sports(sport_id);

ALTER TABLE tournaments
ADD FOREIGN KEY (creator_id)
REFERENCES users(user_id);

ALTER TABLE participants
ADD FOREIGN KEY (user_id)
REFERENCES users(user_id);

ALTER TABLE participants
ADD FOREIGN KEY (tournament_id)
REFERENCES tournaments(tournament_id);



COMMIT TRANSACTION

SELECT *
FROM tournaments;

SELECT * 
FROM users;

SELECT *
FROM participants;

SELECT * 
FROM sports;

SELECT * FROM tournaments t
JOIN users u ON u.user_id = t.creator_id
JOIN sports s ON s.sport_id = t.sport_id

INSERT INTO tournaments (creator_id ,tournament_name , sport_id ) VALUES ( 2, 'soccer is a sport', 
(SELECT sport_id FROM sports WHERE sport_name = 'soccer'));


INSERT INTO tournaments(creator_id , tournament_name , sport_id ) VALUES(
            (SELECT user_id FROM users WHERE username = ('admin')) 
            , ('hi I am a tournament'), 
(SELECT sport_id FROM sports WHERE sport_name = ('soccer')));

INSERT INTO tournaments (creator_id ,tournament_name , sport_id, tour_status ) VALUES (1, 'non adminds seize power', 1, 'Recruiting');

SELECT * FROM tournaments t
JOIN users u ON u.user_id = t.creator_id
JOIN sports s ON s.sport_id = t.sport_id
WHERE tournament_id = 1;
