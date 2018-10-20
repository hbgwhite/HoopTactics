CREATE TABLE Player (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR (255) NOT NULL
);

CREATE TABLE Team (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ShortName VARCHAR (3) NOT NULL,
	LongName VARCHAR (255) NOT NULL
);

INSERT INTO Team (ShortName, LongName) VALUES
	('ATL', 'Atlanta Hawks'),
	('BOS', 'Boston Celtics'),
	('BKN', 'Brooklyn Nets'),
	('CHA', 'Charlotte Hornets'),
	('CHI', 'Chicago Bulls'),
	('CLE', 'Cleveland Cavaliers'),
	('DAL', 'Dallas Mavericks'),
	('DEN', 'Denver Nuggets'),
	('DET', 'Detroit Pistons'),
	('GSW', 'Golden State Warriors'),
	('HOU', 'Houston Rockets'),
	('IND', 'Indiana Pacers'),
	('LAC', 'Los Angeles Clippers'),
	('LAL', 'Los Angeles Lakers'),
	('MEM', 'Memphis Grizzlies'),
	('MIA', 'Miami Heat'),
	('MIL', 'Milwaukee Bucks'),
	('MIN', 'Minnesota Timberwolves'),
	('NOP', 'New Orleans Pelicans'),
	('NYK', 'New York Knicks'),
	('OKC', 'Oklahoma City Thunder'),
	('ORL', 'Orlando Magic'),
	('PHI', 'Philadelphia 76ers'),
	('PHO', 'Phoenix Suns'),
	('POR', 'Portland Trailblazers'),
	('SAC', 'Sacramento Kings'),
	('SAN', 'San Antonio Spurs'),
	('TOR', 'Toronto Raptors'),
	('UTA', 'Utah Jazz'),
	('WAS', 'Washington Wizards');

CREATE TABLE Position (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ShortName VARCHAR (2) NOT NULL,
	LongName VARCHAR (255) NOT NULL
);

INSERT INTO Position (ShortName, LongName) VALUES
	('PG', 'Point Guard'),
	('SG', 'Shooting Guard'),
	('SF', 'Small Forward'),
	('PF', 'Power Forward'),
	('C', 'Center');

CREATE TABLE Game (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Date] DATE NOT NULL,
	HomeTeam INT NOT NULL FOREIGN KEY REFERENCES Team(Id),
	AwayTeam INT NOT NULL FOREIGN KEY REFERENCES Team(Id),
	Winner INT NOT NULL FOREIGN KEY REFERENCES Team(Id)
);

CREATE TABLE PlayerPosition (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	PlayerId INT NOT NULL FOREIGN KEY REFERENCES Player(Id),
	PositionId INT NOT NULL FOREIGN KEY REFERENCES Position(Id),
	StartGameId INT NOT NULL FOREIGN KEY REFERENCES Game(Id),
	EndGameId INT NULL FOREIGN KEY REFERENCES Game(Id)
);

CREATE TABLE Stat (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ShortName VARCHAR(3) NOT NULL,
	LongName VARCHAR(255) NOT NULL
);

INSERT INTO Stat (ShortName, LongName) VALUES
	('MIN', 'Minutes Played'),
	('FGA', 'Field Goals Attempted'),
	('FGM', 'Field Goals Made'),
	('FTA', 'Free Throws Attempted'),
	('FTM', 'Free throws Made'),
	('3PA', 'Three Pointers Attempted'),
	('3PM', 'Three Pointers Made'),
	('DRB', 'Defensive Rebound'),
	('AST', 'Assist'),
	('BLK', 'Block'),
	('STL', 'Steal'),
	('TO', 'Turnover'),
	('PF', 'Personal Foul'),
	('ORB', 'Offensive Rebound');

CREATE TABLE GameStat (
	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	GameId INT NOT NULL FOREIGN KEY REFERENCES Game(Id),
	TeamId INT NOT NULL  FOREIGN KEY REFERENCES Team(Id),
	PlayerId INT NOT NULL FOREIGN KEY REFERENCES Player(Id),
	StatId INT NOT NULL FOREIGN KEY REFERENCES Stat(Id),
	[Value] FLOAT NOT NULL
);