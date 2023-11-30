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
);