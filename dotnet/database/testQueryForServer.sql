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