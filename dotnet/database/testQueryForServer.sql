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

-- INSERT INTO tournaments (creator_id ,tournament_name , sport_id, tour_status ) VALUES (1, 'non adminds seize power', 1, 'Recruiting');

SELECT * FROM tournaments t
JOIN users u ON u.user_id = t.creator_id
JOIN sports s ON s.sport_id = t.sport_id
WHERE tournament_id = 1;

SELECT u.user_id, username, team_number  FROM users u
JOIN participants p on p.user_id = u.user_id
WHERE tournament_id = 3
ORDER BY team_number;

UPDATE participants
SET team_number = 1
WHERE user_id = 5 and tournament_id = 3;


  SELECT * FROM tournaments t 
        JOIN users u ON u.user_id = t.creator_id
        JOIN sports s ON s.sport_id = t.sport_id
        WHERE tournament_id = (1);

		INSERT INTO participants (tournament_id  , user_id, team_number ) VALUES (1, 5, 5);

		select * from participants;

UPDATE tournaments
SET tour_status = 'Completed'
WHERE tournament_id = 10;

SELECT creator_id FROM tournaments WHERE tournament_id = (1);


 SELECT * FROM tournaments t JOIN users u ON u.user_id = t.creator_id JOIN sports s ON s.sport_id = t.sport_id WHERE tournament_id = (1);
 
 select * from participants

 SELECT DISTINCT m.tournament_id, match_number, 
 home_team_id, home_team_score,  home.team_number AS 'home_team_number'  , home_users.username AS 'home_name',
 away_team_id, away_team_score,  away.team_number AS 'away_team_number'  , away_users.username AS 'away_name',
 victor_id, victor.team_number AS 'victor_team_number'  , victor_users.username AS 'victor_name'
 FROM matches m
 JOIN participants away ON away.user_id = m.away_team_id
 JOIN users away_users ON away_users.user_id = m.away_team_id
 JOIN participants home ON home.user_id = m.home_team_id
 JOIN users home_users ON home_users.user_id = m.home_team_id
 JOIN participants victor ON victor.user_id = m.victor_id
 JOIN users victor_users ON victor_users.user_id = m.victor_id
 WHERE m.tournament_id = 3
 ORDER BY match_number;


 SELECT DISTINCT m.tournament_id, match_number, home_team_id, home_team_score,  home.team_number AS 'home_team_number'  , home_users.username AS 'home_name',  away_team_id, away_team_score, away.team_number AS 'away_team_number'  , away_users.username AS 'away_name', victor_id, victor.team_number AS 'victor_team_number'  , victor_users.username AS 'victor_name'  FROM matches m  JOIN participants away ON away.user_id = m.away_team_id  JOIN users away_users ON away_users.user_id = m.away_team_id  JOIN participants home ON home.user_id = m.home_team_id  JOIN users home_users ON home_users.user_id = m.home_team_id  JOIN participants victor ON victor.user_id = m.victor_id  JOIN users victor_users ON victor_users.user_id = m.victor_id  WHERE m.tournament_id = (tournament_id)  ORDER BY match_number;



 SELECT * FROM tournaments t 
        JOIN users u ON u.user_id = t.creator_id 
        JOIN sports s ON s.sport_id = t.sport_id 
        WHERE tournament_id IN (SELECT tournament_id
								FROM participants
								WHERE user_id = 1);

SELECT * FROM tournaments t 
        JOIN users u ON u.user_id = t.creator_id 
        JOIN sports s ON s.sport_id = t.sport_id 
        WHERE t.creator_id = 2;

		SELECT DISTINCT m.tournament_id, match_number, 
 home_team_id, home_team_score,  home.team_number AS 'home_team_number'  , home_users.username AS 'home_name', 
  away_team_id, away_team_score, away.team_number AS 'away_team_number'  , away_users.username AS 'away_name', 
 victor_id, victor.team_number AS 'victor_team_number'  , victor_users.username AS 'victor_name' 
  FROM matches m 
  JOIN participants away ON away.user_id = m.away_team_id 
  JOIN users away_users ON away_users.user_id = m.away_team_id 
  JOIN participants home ON home.user_id = m.home_team_id 
  JOIN users home_users ON home_users.user_id = m.home_team_id 
  JOIN participants victor ON victor.user_id = m.victor_id 
  JOIN users victor_users ON victor_users.user_id = m.victor_id 
  WHERE m.tournament_id = (3) 
  ORDER BY match_number;

  SELECT DISTINCT *
  FROM matches m 
  JOIN participants away ON (away.user_id = m.away_team_id  and away.tournament_id = m.tournament_id)
  JOIN users away_users ON away_users.user_id = m.away_team_id 
  JOIN participants home ON (home.user_id = m.home_team_id  and home.tournament_id = m.tournament_id)
  JOIN users home_users ON home_users.user_id = m.home_team_id 
  JOIN participants victor ON (victor.user_id = m.victor_id  and victor.tournament_id = m.tournament_id)
  JOIN users victor_users ON victor_users.user_id = m.victor_id 
  WHERE m.tournament_id = (3) 
  ORDER BY match_number;

  select * from matches

  INSERT INTO matches 
  (tournament_id , match_number, home_team_id, away_team_id, home_team_score, away_team_score, victor_id ) 
  VALUES (7, 1, 3, 4, '2', '0', 3);


  UPDATE tournaments SET tour_status = ('Active') WHERE tournament_id = (10);

  SELECT * FROM tournaments

  DELETE FROM matches WHERE tournament_id = 3;