--sql server

create database foot;

create table equipe (
    idEquipe int primary key,
    nom varchar(100)
);
insert into equipe (nom)
values
    ('Bayern Munich'),
    ('Paris Saint Germain'),
    ('Bayer Leverkusen'),
    ('Manchester City'),
    ('Real Madrid'),
    ('Inter'),
    ('VfB Stuttgart'),
    ('Atletico Madrid'),
    ('Barcelona'),
    ('Newcastle'),
    ('Tottenham'),
    ('Arsenal'),
    ('Liverpool'),
    ('Monaco'),
    ('RB Leipzig'),
    ('Napoli'),
    ('Aston Villa');

create table competition (
    idCompetition int primary key,
    nom varchar(100)
);
insert into competition (nom)
values
    ('Bundesliga'),
    ('Ligue 1'),
    ('Premier League'),
    ('LaLiga'),
    ('Serie A');

create table competitionEquipe (
    idCE int primary key,
    idCompetition int references competition(idCompetition),
    idEquipe int references equipe(idEquipe)
);
insert into competitionEquipe (idCompetition, idEquipe)
values
    ('competition1', 'equipe1'),
    ('competition2', 'equipe2'),
    ('competition1', 'equipe3'),
    ('competition3', 'equipe4'),
    ('competition4', 'equipe5'),
    ('competition5', 'equipe6'),
    ('competition1', 'equipe7'),
    ('competition4', 'equipe8'),
    ('competition4', 'equipe9'),
    ('competition3', 'equipe10'),
    ('competition3', 'equipe11'),
    ('competition3', 'equipe12'),
    ('competition3', 'equipe13'),
    ('competition2', 'equipe14'),
    ('competition1', 'equipe15'),
    ('competition5', 'equipe16'),
    ('competition3', 'equipe17');

select e.nom, c.nom from competitionequipe ce
	join competition c on c.idCompetition = ce.idCompetition
	join equipe e on e.idEquipe = ce.idEquipe

create table type ( --generale, domicile, exterieur
    idType AS ('type' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
    nom varchar(100)
);
insert into type (nom)
values
    (''),
    (''),
    ('');

create table defense (
    idDefense varchar(10) primary key,
    idEquipe varchar(10) references equipe(idEquipe),
    tirs_pm float,
    tacles_pm float,
    interceptions_pm float,
    faute_pm float,
    hors_jeu_pm float,
    note float,
    idType varchar(10) references type(idType)
);

create table attaque (
    idAttaque varchar(10) primary key,
    idEquipe varchar(10) references equipe(idEquipe),
    tirs_pm float,
    tirs_CA_pm float,
    dribbles_pm float,
    fautes_subies_pm float,
    note float,
    idType varchar(10) references type(idType)
);

create table generale (
    idGenerale varchar(10) primary key,
    idEquipe varchar(10) references equipe(idEquipe),
    buts int,
    tirs_pm float,
    discipline float,
    possession float,
    passesReussies float,
    aeriensGagnes float,
    note float,
    idType varchar(10) references type(idType)
);


---insert data from json

DECLARE @json NVARCHAR(MAX) = '{  "teamTableStats" :  [{"name":"Bayern","teamId":37,"teamName":"Bayern Munich","teamRegionName":"Allemagne","seasonId":0,"seasonName":null,"tournamentId":3,"isOpta":true,"tournamentRegionId":81,"tournamentRegionCode":"de","tournamentRegionName":"Allemagne","regionCode":"de","tournamentName":"Bundesliga","rating":7.16,"ranking":1,"apps":12,"goal":43.0,"yellowCard":17.0,"redCard":1.0,"shotsPerGame":19.916666666666668,"aerialWonPerGame":12.75,"possession":0.62859166666666655,"passSuccess":0.88811188811188813},{"name":"PSG","teamId":304,"teamName":"Paris Saint-Germain","teamRegionName":"France","seasonId":0,"seasonName":null,"tournamentId":22,"isOpta":true,"tournamentRegionId":74,"tournamentRegionCode":"fr","tournamentRegionName":"France","regionCode":"fr","tournamentName":"Ligue 1","rating":7.04,"ranking":2,"apps":13,"goal":34.0,"yellowCard":17.0,"redCard":0.0,"shotsPerGame":16.615384615384617,"aerialWonPerGame":7.0,"possession":0.680476923076923,"passSuccess":0.90566240464166758},{"name":"Leverkusen","teamId":36,"teamName":"Bayer Leverkusen","teamRegionName":"Allemagne","seasonId":0,"seasonName":null,"tournamentId":3,"isOpta":true,"tournamentRegionId":81,"tournamentRegionCode":"de","tournamentRegionName":"Allemagne","regionCode":"de","tournamentName":"Bundesliga","rating":6.98,"ranking":3,"apps":12,"goal":37.0,"yellowCard":23.0,"redCard":0.0,"shotsPerGame":16.25,"aerialWonPerGame":9.5833333333333339,"possession":0.60575833333333329,"passSuccess":0.88899839842306272},{"name":"Man City","teamId":167,"teamName":"Manchester City","teamRegionName":"Angleterre","seasonId":0,"seasonName":null,"tournamentId":2,"isOpta":true,"tournamentRegionId":252,"tournamentRegionCode":"gb-eng","tournamentRegionName":"Angleterre","regionCode":"gb-eng","tournamentName":"Premier League","rating":6.96,"ranking":4,"apps":13,"goal":33.0,"yellowCard":23.0,"redCard":2.0,"shotsPerGame":16.46153846153846,"aerialWonPerGame":7.9230769230769234,"possession":0.62333846153846151,"passSuccess":0.90200071882113331},{"name":"Real Madrid","teamId":52,"teamName":"Real Madrid","teamRegionName":"Espagne","seasonId":0,"seasonName":null,"tournamentId":4,"isOpta":true,"tournamentRegionId":206,"tournamentRegionCode":"es","tournamentRegionName":"Espagne","regionCode":"es","tournamentName":"LaLiga","rating":6.93,"ranking":5,"apps":14,"goal":31.0,"yellowCard":26.0,"redCard":1.0,"shotsPerGame":17.5,"aerialWonPerGame":8.3571428571428577,"possession":0.57288571428571422,"passSuccess":0.89664429530201339},{"name":"Inter","teamId":75,"teamName":"Inter","teamRegionName":"Italie","seasonId":0,"seasonName":null,"tournamentId":5,"isOpta":true,"tournamentRegionId":108,"tournamentRegionCode":"it","tournamentRegionName":"Italie","regionCode":"it","tournamentName":"Serie A","rating":6.89,"ranking":6,"apps":13,"goal":30.0,"yellowCard":17.0,"redCard":0.0,"shotsPerGame":16.307692307692307,"aerialWonPerGame":15.23076923076923,"possession":0.55596923076923077,"passSuccess":0.8640606767794633},{"name":"Stuttgart","teamId":41,"teamName":"VfB Stuttgart","teamRegionName":"Allemagne","seasonId":0,"seasonName":null,"tournamentId":3,"isOpta":true,"tournamentRegionId":81,"tournamentRegionCode":"de","tournamentRegionName":"Allemagne","regionCode":"de","tournamentName":"Bundesliga","rating":6.86,"ranking":7,"apps":12,"goal":31.0,"yellowCard":16.0,"redCard":0.0,"shotsPerGame":15.916666666666666,"aerialWonPerGame":15.916666666666666,"possession":0.5767,"passSuccess":0.85678868309756451},{"name":"Atletico","teamId":63,"teamName":"Atletico Madrid","teamRegionName":"Espagne","seasonId":0,"seasonName":null,"tournamentId":4,"isOpta":true,"tournamentRegionId":206,"tournamentRegionCode":"es","tournamentRegionName":"Espagne","regionCode":"es","tournamentName":"LaLiga","rating":6.84,"ranking":8,"apps":13,"goal":30.0,"yellowCard":25.0,"redCard":1.0,"shotsPerGame":13.461538461538462,"aerialWonPerGame":12.692307692307692,"possession":0.5276384615384615,"passSuccess":0.8474453611231727},{"name":"Barcelona","teamId":65,"teamName":"Barcelona","teamRegionName":"Espagne","seasonId":0,"seasonName":null,"tournamentId":4,"isOpta":true,"tournamentRegionId":206,"tournamentRegionCode":"es","tournamentRegionName":"Espagne","regionCode":"es","tournamentName":"LaLiga","rating":6.8100000000000005,"ranking":9,"apps":14,"goal":27.0,"yellowCard":33.0,"redCard":1.0,"shotsPerGame":15.357142857142858,"aerialWonPerGame":12.142857142857142,"possession":0.66742857142857148,"passSuccess":0.89156210429377225},{"name":"Newcastle","teamId":23,"teamName":"Newcastle","teamRegionName":"Angleterre","seasonId":0,"seasonName":null,"tournamentId":2,"isOpta":true,"tournamentRegionId":252,"tournamentRegionCode":"gb-eng","tournamentRegionName":"Angleterre","regionCode":"gb-eng","tournamentName":"Premier League","rating":6.8,"ranking":10,"apps":13,"goal":31.0,"yellowCard":37.0,"redCard":0.0,"shotsPerGame":13.153846153846153,"aerialWonPerGame":10.846153846153847,"possession":0.53266153846153852,"passSuccess":0.843531202435312},{"name":"Tottenham","teamId":30,"teamName":"Tottenham","teamRegionName":"Angleterre","seasonId":0,"seasonName":null,"tournamentId":2,"isOpta":true,"tournamentRegionId":252,"tournamentRegionCode":"gb-eng","tournamentRegionName":"Angleterre","regionCode":"gb-eng","tournamentName":"Premier League","rating":6.8,"ranking":11,"apps":13,"goal":25.0,"yellowCard":34.0,"redCard":3.0,"shotsPerGame":16.153846153846153,"aerialWonPerGame":8.76923076923077,"possession":0.60345384615384612,"passSuccess":0.87973333333333337},{"name":"Arsenal","teamId":13,"teamName":"Arsenal","teamRegionName":"Angleterre","seasonId":0,"seasonName":null,"tournamentId":2,"isOpta":true,"tournamentRegionId":252,"tournamentRegionCode":"gb-eng","tournamentRegionName":"Angleterre","regionCode":"gb-eng","tournamentName":"Premier League","rating":6.79,"ranking":12,"apps":13,"goal":27.0,"yellowCard":17.0,"redCard":2.0,"shotsPerGame":14.538461538461538,"aerialWonPerGame":13.307692307692308,"possession":0.61133076923076923,"passSuccess":0.87210569327158816},{"name":"Liverpool","teamId":26,"teamName":"Liverpool","teamRegionName":"Angleterre","seasonId":0,"seasonName":null,"tournamentId":2,"isOpta":true,"tournamentRegionId":252,"tournamentRegionCode":"gb-eng","tournamentRegionName":"Angleterre","regionCode":"gb-eng","tournamentName":"Premier League","rating":6.79,"ranking":13,"apps":13,"goal":28.0,"yellowCard":23.0,"redCard":4.0,"shotsPerGame":17.307692307692307,"aerialWonPerGame":14.384615384615385,"possession":0.57144615384615383,"passSuccess":0.86113382393022619},{"name":"Monaco","teamId":248,"teamName":"Monaco","teamRegionName":"France","seasonId":0,"seasonName":null,"tournamentId":22,"isOpta":true,"tournamentRegionId":74,"tournamentRegionCode":"fr","tournamentRegionName":"France","regionCode":"fr","tournamentName":"Ligue 1","rating":6.78,"ranking":14,"apps":13,"goal":27.0,"yellowCard":31.0,"redCard":0.0,"shotsPerGame":14.692307692307692,"aerialWonPerGame":11.23076923076923,"possession":0.5515692307692307,"passSuccess":0.83382966051220964},{"name":"RBL","teamId":7614,"teamName":"RB Leipzig","teamRegionName":"Allemagne","seasonId":0,"seasonName":null,"tournamentId":3,"isOpta":true,"tournamentRegionId":81,"tournamentRegionCode":"de","tournamentRegionName":"Allemagne","regionCode":"de","tournamentName":"Bundesliga","rating":6.78,"ranking":15,"apps":12,"goal":29.0,"yellowCard":19.0,"redCard":0.0,"shotsPerGame":14.5,"aerialWonPerGame":12.75,"possession":0.57876666666666665,"passSuccess":0.84418356456776944},{"name":"Napoli","teamId":276,"teamName":"Napoli","teamRegionName":"Italie","seasonId":0,"seasonName":null,"tournamentId":5,"isOpta":true,"tournamentRegionId":108,"tournamentRegionCode":"it","tournamentRegionName":"Italie","regionCode":"it","tournamentName":"Serie A","rating":6.77,"ranking":16,"apps":13,"goal":26.0,"yellowCard":23.0,"redCard":1.0,"shotsPerGame":17.923076923076923,"aerialWonPerGame":11.076923076923077,"possession":0.58513076923076923,"passSuccess":0.86794067313177414},{"name":"Aston Villa","teamId":24,"teamName":"Aston Villa","teamRegionName":"Angleterre","seasonId":0,"seasonName":null,"tournamentId":2,"isOpta":true,"tournamentRegionId":252,"tournamentRegionCode":"gb-eng","tournamentRegionName":"Angleterre","regionCode":"gb-eng","tournamentName":"Premier League","rating":6.76,"ranking":17,"apps":13,"goal":31.0,"yellowCard":32.0,"redCard":0.0,"shotsPerGame":14.923076923076923,"aerialWonPerGame":8.1538461538461533,"possession":0.52288461538461539,"passSuccess":0.862257184138706},{"name":"Juventus","teamId":87,"teamName":"Juventus","teamRegionName":"Italie","seasonId":0,"seasonName":null,"tournamentId":5,"isOpta":true,"tournamentRegionId":108,"tournamentRegionCode":"it","tournamentRegionName":"Italie","regionCode":"it","tournamentName":"Serie A","rating":6.76,"ranking":18,"apps":13,"goal":20.0,"yellowCard":35.0,"redCard":0.0,"shotsPerGame":13.846153846153847,"aerialWonPerGame":13.615384615384615,"possession":0.4751538461538462,"passSuccess":0.83489647849938065},{"name":"Lille","teamId":607,"teamName":"Lille","teamRegionName":"France","seasonId":0,"seasonName":null,"tournamentId":22,"isOpta":true,"tournamentRegionId":74,"tournamentRegionCode":"fr","tournamentRegionName":"France","regionCode":"fr","tournamentName":"Ligue 1","rating":6.76,"ranking":19,"apps":13,"goal":17.0,"yellowCard":28.0,"redCard":1.0,"shotsPerGame":12.538461538461538,"aerialWonPerGame":11.692307692307692,"possession":0.57123076923076921,"passSuccess":0.85387602473752333},{"name":"Girona","teamId":2783,"teamName":"Girona","teamRegionName":"Espagne","seasonId":0,"seasonName":null,"tournamentId":4,"isOpta":true,"tournamentRegionId":206,"tournamentRegionCode":"es","tournamentRegionName":"Espagne","regionCode":"es","tournamentName":"LaLiga","rating":6.75,"ranking":20,"apps":14,"goal":32.0,"yellowCard":32.0,"redCard":0.0,"shotsPerGame":13.714285714285714,"aerialWonPerGame":11.785714285714286,"possession":0.56750714285714288,"passSuccess":0.87019027484143763}],  "paging" : {   "currentPage" :  1, "totalPages" :  5, "resultsPerPage" :  20, "totalResults" :  96, "firstRecordIndex" :  1, "lastRecordIndex" :  20},  "statColumns" :  ["apps","goal","shotsPerGame","yellowCard","redCard","possession","passSuccess","aerialWonPerGame"] } 
';
DECLARE @teamTableStats NVARCHAR(MAX) = JSON_VALUE(@json, '$.teamTableStats');

INSERT INTO equipe (idEquipe, nom)
SELECT teamId, teamName
FROM OPENJSON(@teamTableStats)
WITH (
    teamId int '$.teamId',
    teamName varchar(100) '$.teamName'
);

INSERT INTO generale (idEquipe, buts, tirs_pm, discipline, possession, passesReussies, aeriensGagnes, note, idType)
SELECT CONCAT('equipe', teamId), goal, shotsPerGame, (yellowCard + redCard), possession, passSuccess, aerialWonPerGame, rating, 'type' + CAST(id AS VARCHAR(10))
FROM OPENJSON(@teamTableStats)
WITH (
    teamId int '$.teamId',
    goal int '$.goal',
    shotsPerGame float '$.shotsPerGame',
    yellowCard int '$.yellowCard',
    redCard int '$.redCard',
    possession float '$.possession',
    passSuccess float '$.passSuccess',
    aerialWonPerGame float '$.aerialWonPerGame',
    rating float '$.rating'
);

INSERT INTO attaque (idEquipe, tirs_pm, dribbles_pm, fautes_subies_pm, note, idType)
SELECT CONCAT('equipe', teamId), shotsPerGame, shotsPerGame, yellowCard, rating, 'type' + CAST(id AS VARCHAR(10))
FROM OPENJSON(@teamTableStats)
WITH (
    teamId int '$.teamId',
    shotsPerGame float '$.shotsPerGame',
    yellowCard int '$.yellowCard',
    rating float '$.rating'
);

INSERT INTO defense (idEquipe, tirs_pm, tacles_pm, interceptions_pm, faute_pm, hors_jeu_pm, note, idType)
SELECT CONCAT('equipe', teamId), shotsPerGame, tacles_pm, interceptions_pm, faute_pm, 0.0, rating, 'type' + CAST(id AS VARCHAR(10))
FROM OPENJSON(@teamTableStats)
WITH (
    teamId int '$.teamId',
    shotsPerGame float '$.shotsPerGame',
    tacles_pm float '$.aerialWonPerGame',
    interceptions_pm float '$.possession',
    faute_pm float '$.yellowCard',
    rating float '$.rating'
);


INSERT INTO TeamStats (teamName)
VALUES 
    ( 'Bayern Munich'),
    ( 'Paris Saint-Germain'),
    ( 'Bayer Leverkusen'),
    ( 'Manchester City'),
    ( 'Real Madrid'),
    ( 'Inter'),
    ( 'VfB Stuttgart'),
    ( 'Atletico Madrid'),
    ( 'Barcelona'),
    ( 'Newcastle'),
    ( 'Tottenham'),
    ( 'Arsenal'),
    ( 'Liverpool'),
    ( 'Monaco'),
    ( 'RB Leipzig'),
    ( 'Napoli'),
    ( 'Aston Villa'),
    ( 'Juventus'),
    ( 'Lille'),
    ( 'Girona')
    ;

