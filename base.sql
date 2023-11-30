--sql server

create database foot;

create table equipe (
    idEquipe AS ('equipe' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
    nom varchar(100)
);

insert into equipe (nom)
values
("Bayern Munich",
"Paris Saint-Germain",
"Bayer Leverkusen",
"Manchester City",
"Real Madrid",
"Inter",
"VfB Stuttgart",
"Atletico Madrid",
"Barcelona",
"Newcastle",
"Tottenham",
"Arsenal",
"Liverpool",
"Monaco",
"RB Leipzig",
"Napoli",
"Aston Villa",
"Juventus",
"Lille",
"Gironad");

insert into equipe (nom)
values
    ('Lorient'),
    ('Lyon'),
    ('Strasbourg'),
    ('Roma');

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
insert into competitionEquipe (idCompetition, idEquipe)
values
    ('competition3', 'equipe18'),
    ('competition2', 'equipe19'),
    ('competition4', 'equipe20'),
    ('competition4', 'equipe21');
insert into competitionEquipe (idCompetition, idEquipe)
values
    ('competition2', 'equipe22'),
    ('competition2', 'equipe23'),
    ('competition2', 'equipe24'),
    ('competition5', 'equipe25');


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
    idGenerale AS ('gnrl' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
    idCE varchar(12) references competitionEquipe(idCE),
    buts int,
    tirs_pm float,
    disciplineJaune int,
    disciplineRouge int,
    possession float,
    passesReussies float,
    aeriensGagnes float,
    note float,
    idType varchar(14) references type(idType)
);
insert into generale (idCE, buts, tirs_pm, disciplineJaune, disciplineRouge, possession, passesReussies, aeriensGagnes, note, idType)
values
    ('ce1', 43, 19.9, 17, 1, 62.9, 88.8, 12.8, 7.16, 'type1'),
    ('ce2', 34, 16.9, 17, 0, 68.0, 90.6, 7, 7.04, 'type1'),
    ('ce3', 37, 16.3, 23, 0, 60.6, 88.9, 9.6, 6.98, 'type1'),
    ('ce4', 33, 16.5, 23, 2, 62.3, 90.2, 7.9, 6.96, 'type1'),
    ('ce5', 31, 17.5, 26, 1, 57.3, 89.7, 8.4, 6.93, 'type1'),
    ('ce1', 27, 21.7, 4, 1, 61.9, 88.8, 13, 7.21, 'type2'),
    ('ce3', 21, 19.3, 8, 0, 65.5, 90.2, 11.7, 7.05, 'type2'),
    ('ce17', 23, 15.3, 17, 0, 57.6, 86.8, 9.5, 7.04, 'type2'),
    ('ce13', 17, 21.5, 5, 1, 66.9, 87.9, 19.5, 7.04, 'type2'),
    ('ce4', 17, 12.5, 9, 2, 60.6, 90.4, 7.5, 7.03, 'type2'),
    ('ce1', 16, 18.2, 13, 0, 63.9, 88.8, 12.5, 7.12, 'type3'),
    ('ce2', 14, 17.8, 12, 0, 64.9, 89.9, 7.7, 7.07, 'type3'),
    ('ce3', 16, 13.2, 15, 0, 55.7, 87.5, 7.5, 6.91, 'type3');

create table defense (
    idDefense AS ('df' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
    idCE varchar(12) references competitionEquipe(idCE),
    tirs_pm float,
    tacles_pm float,
    interceptions_pm float,
    faute_pm float,
    hors_jeu_pm float,
    note float,
    idType varchar(14) references type(idType)
);
insert into defense (idCE, tirs_pm, tacles_pm, interceptions_pm, faute_pm, hors_jeu_pm, note, idType)
values
    ('ce11', 13.5, 20.2, 8.6, 11.6, 2.4, 6.80, 'type1'),
    ('ce18', 12.2, 20.1, 9.3, 12, 1.7, 6.63, 'type1'),
    ('ce19', 11.5, 19.9, 9.8, 13.3, 0.9, 6.67, 'type1'),
    ('ce20', 9.7, 19.6, 9.5, 13.8, 1.3, 6.57, 'type1'),
    ('ce21', 12.4, 19.6, 8.5, 12.9, 2.7, 6.66, 'type1'),
    ('ce22', 17.3, 20.9, 12.1, 11.7, 1.9, 6.73, 'type2'),
    ('ce21', 11, 20.7, 8.3, 14.4, 2.9, 6.71, 'type2'),
    ('ce18', 9.9, 20, 9, 11.6, 2, 6.57, 'type2'),
    ('ce25', 8.6, 20, 6.9, 12.9, 1.9, 6.84, 'type2'),
    ('ce23', 12.4, 20, 10.1, 16.1, 1.7, 6.47, 'type2'),
    ('ce20', 12.1, 22.1, 9, 13.1, 0.7, 6.50, 'type3'),
    ('ce19', 13.1, 22.1, 10, 12.3, 1.4, 6.61, 'type3'),
    ('ce2', 15.5, 20.5, 7.8, 10.5, 1.3, 7.07, 'type3'),
    ('ce18', 14.8, 20.2, 9.7, 12.5, 1.3, 6.70, 'type3');

create table attaque (
    idAttaque AS ('att' + cast(id as varchar(10))) PERSISTED primary key,
    id int identity(1, 1),
    idCE varchar(12) references competitionEquipe(idCE),
    tirs_pm float,
    tirs_CA_pm float,
    dribbles_pm float,
    fautes_subies_pm float,
    note float,
    idType varchar(14) references type(idType)
);
insert into attaque (idCE, tirs_pm, tirs_CA_pm, dribbles_pm, fautes_subies_pm, note, idType)
values
    ('ce1', 19.9, 8.3, 15.7, 9.3, 7.6, 'type1'),
    ('ce2', 16.6, 6.8, 12.2, 12.2, 7.04, 'type1'),
    ('ce9', 15.4, 6.1, 12.2, 14.3, 6.81, 'type1'),
    ('ce1', 21.7, 9.8, 14.5, 8.3, 7.21, 'type2'),
    ('ce3', 19.3, 9, 12.3, 8.5, 7.05, 'type2'),
    ('ce5', 20.2, 8.3, 12.2, 13.2, 7.00, 'type2'),
    ('ce1', 18.2, 6.8, 16.8, 10.3, 7.12, 'type3'),
    ('ce2', 17.8, 7.3, 13.3, 11, 7.07, 'type3'),
    ('ce9', 14.7, 5.9, 12.9, 14.7, 6.74, 'type3');
