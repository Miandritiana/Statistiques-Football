--postgres

create database foot;

create table generalType1 (
    -- idGnrTy1 serial primary key,
    equipe varchar(100),
    competition varchar(100),
    buts int,
    tirs_pm float,
    disciplineJaune int,
    disciplineRouge int,
    possession float,
    passesReussies float,
    aeriensGagnes float,
    note float
);


create table generalType2 (
    equipe varchar(100),
    competition varchar(100),
    buts int,
    tirs_pm float,
    disciplineJaune int,
    disciplineRouge int,
    possession float,
    passesReussies float,
    aeriensGagnes float,
    note float
);