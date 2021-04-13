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
max_number_participants int NOT NULL DEFAULT 8,
tour_status varchar(15) Default 'Recruiting',
CONSTRAINT  tournaments_tournament_id  PRIMARY KEY (tournament_id),
CONSTRAINT tournaments_tour_status CHECK (tour_status IN ('Recruiting', 'Active', 'Completed')),
CONSTRAINT tournaments_max_number_participants CHECK ((max_number_participants >=2) and (max_number_participants <=64))
);

CREATE TABLE sports (
sport_id int IDENTITY NOT NULL,
sport_name varchar(50) NOT NULL,
CONSTRAINT  sport_sport_id  PRIMARY KEY (sport_id),
);

CREATE TABLE participants (
	tournament_id integer NOT NULL,
	user_id integer NOT NULL,
	team_number integer NOT NULL,
	CONSTRAINT participants_tournament_id_user_id PRIMARY KEY (tournament_id, user_id)
);

-- Drake edit for demo tournament
CREATE TABLE matches (
tournament_id integer NOT NULL,
match_number integer NOT NULL,
home_team_id integer NOT NULL,
away_team_id integer NOT NULL,
home_team_score varchar(50) DEFAULT '' NOT NULL ,
away_team_score varchar(50) DEFAULT '' NOT NULL ,
victor_id integer NOT NULL,
CONSTRAINT matches_tournament_id_match_number PRIMARY KEY (tournament_id, match_number),
CONSTRAINT matches_victor_id CHECK (victor_id IN (home_team_id, away_team_id, ''))
);

--populate default data
SET IDENTITY_INSERT users ON
-- user/password
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (1, 'user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
--admin/password
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (2, 'admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');


-- Drake edit for demo tournament
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (3,	'Aaron', '5C3f+YD3kx3mH8TQPRPqRqyqLjo=', 'MW6lnSChV1Q=', 'admin');
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (4,    'Bob', '0CZpWyZKkTABMliwA/0W1jaYUJE=', 'hYqPM95MXwY=', 'admin');
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (5,	'Conner', 'BXW4iJxq0+ZTB+ZTx66yTQpQebc=', 'FXhaCioadlQ=', 'admin');
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (6,	'Doug', 'cfpq6XHgRcvX+ckKCgRQX0q6/1s=', '4ZAkChsb+5Q=', 'user');
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (7,	'Elizabeth', 'p1IZ+bEB992j4IQde3x1eoS+pBg=', '9EBow/9ISqI=', 'user');
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (8,	'Frank', 'jPCrwEvNE/yfYSa0itn5Mpz6Q9c=', 'cFK5lgDnzfk=', 'user');
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (9,	'Gloria', 'OMghYW3jmdlJ7ffEsOCuaNDZRh0=', 'MTIex7iREik=', 'user');
INSERT INTO users (user_id, username, password_hash, salt, user_role) VALUES (10,	'Henry', 'g0Q2aeoMd40+n8vNquy6rLBvAt0=', 'NYK4oaniGzg=', 'user');

SET IDENTITY_INSERT users OFF



SET IDENTITY_INSERT tournaments ON
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (1, 2, 'soccer is a sport', 1, 'Recruiting');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (2, 2, 'baseball is a sport', 2, 'Active');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (3, 2, 'basketball is a sport', 3, 'Completed');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (4, 4, 'b is an admin', 1, 'Recruiting');

-- more test
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (5, 2, '3', 2, 'Active');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (6, 2, '4', 3, 'Completed');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (7, 4, '5', 1, 'Recruiting');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (8, 2, '6', 2, 'Active');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (9, 2, '7', 3, 'Completed');
INSERT INTO tournaments (tournament_id, creator_id ,tournament_name , sport_id , tour_status) VALUES (10, 4, '8', 1, 'Recruiting');

SET IDENTITY_INSERT tournaments OFF

SET IDENTITY_INSERT sports ON
INSERT INTO sports (sport_id ,sport_name ) VALUES (1, 'soccer');
INSERT INTO sports (sport_id ,sport_name ) VALUES (2, 'baseball');
INSERT INTO sports (sport_id ,sport_name ) VALUES (3, 'basketball');
SET IDENTITY_INSERT sports OFF

INSERT INTO sports (sport_name ) VALUES ('Tennis');
INSERT INTO sports (sport_name ) VALUES ('Football (American)');
INSERT INTO sports (sport_name ) VALUES ('Soccer');
INSERT INTO sports (sport_name ) VALUES ('VolleyBall');
INSERT INTO sports (sport_name ) VALUES ('Cricket');
INSERT INTO sports (sport_name ) VALUES ('Dodgeball');
INSERT INTO sports (sport_name ) VALUES ('Jujitsu');
INSERT INTO sports (sport_name ) VALUES ('Wrestling');
INSERT INTO sports (sport_name ) VALUES ('Sumo');
INSERT INTO sports (sport_name ) VALUES ('Boxing');
INSERT INTO sports (sport_name ) VALUES ('MMA');
INSERT INTO sports (sport_name ) VALUES ('Kendo');
INSERT INTO sports (sport_name ) VALUES ('Fencing');
INSERT INTO sports (sport_name ) VALUES ('Judo');
INSERT INTO sports (sport_name ) VALUES ('Pool');
INSERT INTO sports (sport_name ) VALUES ('Bridge');
INSERT INTO sports (sport_name ) VALUES ('PingPong');
INSERT INTO sports (sport_name ) VALUES ('Foosball');
INSERT INTO sports (sport_name ) VALUES ('Ultimate');
INSERT INTO sports (sport_name ) VALUES ('Rugby');
INSERT INTO sports (sport_name ) VALUES ('Roller Derby');
INSERT INTO sports (sport_name ) VALUES ('Ice Hockey');
INSERT INTO sports (sport_name ) VALUES ('Squash');
INSERT INTO sports (sport_name ) VALUES ('Roller Hockey');
INSERT INTO sports (sport_name ) VALUES ('Lacrosse');
INSERT INTO sports (sport_name ) VALUES ('Flag Football');




INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (1, 1, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (1, 2, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (2, 1, 1);

-- Drake edit for demo tournament
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 5, 3);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 6, 4);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 7, 5);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 8, 6);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 9, 7);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (3, 10, 8);

-- Drake edit for demo tournament
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (3, 1, 3, 4, '2', '0', 3);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (3, 2, 5, 6, '2', '5', 6);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (3, 3, 7, 8, '2', '5', 8);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (3, 4, 9, 10, '2', '0', 9);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (3, 5, 3, 6, '7', '1', 3);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (3, 6, 8, 9, '5', '6', 9);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (3, 7, 3, 9, '9', '10', 9);


-- second demo tournament
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 5, 3);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 6, 4);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 7, 5);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 8, 6);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 9, 7);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (4, 10, 8);

-- more demos
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (5, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (5, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (5, 5, 3);

INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (6, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (6, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (6, 5, 3);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (6, 6, 4);

INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (7, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (7, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (7, 5, 3);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (7, 6, 4);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (7, 7, 5);

INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (8, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (8, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (8, 5, 3);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (8, 6, 4);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (8, 7, 5);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (8, 8, 6);

INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (9, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (9, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (9, 5, 3);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (9, 6, 4);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (9, 7, 5);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (9, 8, 6);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (9, 9, 7);

INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 3, 1);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 4, 2);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 5, 3);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 6, 4);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 7, 5);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 8, 6);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 9, 7);
INSERT INTO participants (tournament_id , user_id, team_number ) VALUES (10, 10, 8);







INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (4, 1, 3, 4, '2', '0', 3);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (4, 2, 5, 6, '2', '5', 6);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (4, 3, 7, 8, '2', '5', 8);
INSERT INTO matches (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) VALUES (4, 4, 9, 10, '2', '0', 9);



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


-- Drake edit for demo tournament
ALTER TABLE matches
ADD FOREIGN KEY (tournament_id)
REFERENCES tournaments(tournament_id);

ALTER TABLE matches
ADD FOREIGN KEY (home_team_id)
REFERENCES users(user_id);

ALTER TABLE matches
ADD FOREIGN KEY (away_team_id)
REFERENCES users(user_id);


COMMIT TRANSACTION


