--sql server

create database foot;

create table equipe (
    idEquipe AS ('equipe' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
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
    idCompetition AS ('competition' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
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
    idCE AS ('ce' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
    idCompetition varchar(21) references competition(idCompetition),
    idEquipe varchar(16) references equipe(idEquipe)
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

select idCE, e.nom, c.nom from competitionEquipe ce
    join competition c on c.idCompetition = ce.idCompetition
    join equipe e on e.idEquipe = ce.idEquipe;

create table type (
    idType AS ('type' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
    nom varchar(100)
);
insert into type (nom)
values
    ('Generale'),
    ('Domicile'),
    ('Attaque');


create table generale (
    idGenerale varchar(10) primary key,
    idCE varchar(10) references competitionEquipe(idCE),
    buts int,
    tirs_pm float,
    disciplineJaune int,
    disciplineRouge int,
    possession float,
    passesReussies float,
    aeriensGagnes float,
    note float,
    idType varchar(10) references type(idType)
);
insert into generale (idCE, buts, tirs_pm, disciplineJaune, disciplineRouge, possession, passesReussies, aeriensGagnes, note, idType)
values
    ('ce1', 43, 19.9, 17, 1, 62.9, 88.8, 12.8, 7.16),
    ('ce2', 34, 16.9, 17, 0, 68.0, 90.6, 7, 7.04),
    ('ce3', 37, 16.3, 23, 0, 60.6, 88.9, 9.6, 6.98),
    ('ce4', 33, 16.5, 23, 2, 62.3, 90.2, 7.9, 6.96),
    ('ce5', 31, 17.5, 26, 1, 57.3, 89.7, 8.4, 6.93);

create table defense (
    idDefense varchar(10) primary key,
    idCE varchar(10) references competitionEquipe(idCE),
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
    idCE varchar(10) references competitionEquipe(idCE),
    tirs_pm float,
    tirs_CA_pm float,
    dribbles_pm float,
    fautes_subies_pm float,
    note float,
    idType varchar(10) references type(idType)
);
