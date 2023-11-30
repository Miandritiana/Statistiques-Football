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
    tirs_pm int,
    tacles_pm int,
    interceptions_pm int,
    faute_pm int,
    hors_jeu_pm int,
    note int,
    idType varchar(10) references type(idType)
);

create table attaque (
    idAttaque varchar(10) primary key,
    idEquipe varchar(10) references equipe(idEquipe),
    tirs_pm int,
    tirs_CA_pm int,
    dribbles_pm int,
    fautes_subies_pm int,
    note int,
    idType varchar(10) references type(idType)
);

create table generale (
    idGenerale varchar(10) primary key,
    idEquipe varchar(10) references equipe(idEquipe),
    buts int,
    tirs_pm int,
    discipline int,
    possession int,
    passesReussies int,
    aeriensGagnes int,
    note int,
    idType varchar(10) references type(idType)
);