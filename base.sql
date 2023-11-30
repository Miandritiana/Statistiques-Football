--sql server

create database foot;

create table equipe (
    idEquipe varchar(10) primary key,
    nom varchar(100)
);

create table competition (
    idCompetition varchar(10) primary key,
    idEquipe varchar(10) references equipe(idEquipe)
);

create table type (
    idType varchar(10) primary key,
    nom varchar(100)
);

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