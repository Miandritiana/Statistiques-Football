CREATE VIEW ViewGenerale AS
SELECT
    e.nom AS NomEquipe,
	c.nom AS NomCompetition,
    g.buts,
    g.tirs_pm,
    g.disciplineJaune,
    g.disciplineRouge,
    g.possession,
    g.passesReussies,
    g.aeriensGagnes,
    g.note,
    g.idType
FROM
    generale g
JOIN
    competitionEquipe ce ON g.idCE = ce.idCE
JOIN
    competition c ON ce.idCompetition = c.idCompetition
JOIN
    equipe e ON ce.idEquipe = e.idEquipe;


SELECT
    e.nom AS NomEquipe,
    c.nom AS NomCompetition,
    g.buts,
    g.tirs_pm,
    g.disciplineJaune,
    g.disciplineRouge,
    g.possession,
    g.passesReussies,
    g.aeriensGagnes,
    g.note,
    g.idType
FROM
    generale g
JOIN
    competitionEquipe ce ON g.idCE = ce.idCE
JOIN
    competition c ON ce.idCompetition = c.idCompetition
JOIN
    equipe e ON ce.idEquipe = e.idEquipe
WHERE
    g.idType = 'Type2';


CREATE VIEW ViewDefense AS
SELECT
    e.nom AS NomEquipe,
    c.nom AS NomCompetition,
    d.tirs_pm,
    d.tacles_pm,
    d.interceptions_pm,
    d.faute_pm,
    d.hors_jeu_pm,
    d.note,
    d.idType
FROM
    defense d
JOIN
    competitionEquipe ce ON d.idCE = ce.idCE
JOIN
    competition c ON ce.idCompetition = c.idCompetition
JOIN
    equipe e ON ce.idEquipe = e.idEquipe;

CREATE VIEW ViewAttaque AS
SELECT
    e.nom AS NomEquipe,
    c.nom AS NomCompetition,
    a.tirs_pm,
    a.tirs_CA_pm,
    a.dribbles_pm,
    a.fautes_subies_pm,
    a.note,
    a.idType
FROM
    attaque a
JOIN
    competitionEquipe ce ON a.idCE = ce.idCE
JOIN
    competition c ON ce.idCompetition = c.idCompetition
JOIN
    equipe e ON ce.idEquipe = e.idEquipe;