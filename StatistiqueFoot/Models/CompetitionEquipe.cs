using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class CompetitionEquipe
    {
       

        public String idCE { get; set; }
        public String idCompetition { get; set; }
        public String idEquipe { get; set; }
      

         public CompetitionEquipe()
        {
        }

        public CompetitionEquipe(String idCE, String idCompetition,String idEquipe)
        {
            this.idCE = idCE;
            this.idCompetition = idCompetition;
            this.idEquipe = idEquipe;
           
        }

        public List<CompetitionEquipe> selectCompetitionEquipe()
        {
            Connexion connexion = new Connexion();
            List<CompetitionEquipe> listeCompetitionEquipe = new  List<CompetitionEquipe>();
            try {
                connexion.connection.Open();
                    string requet = "select * from competitionEquipe";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string idCE = dataReader.GetString(0);
                        string idCompetition = dataReader.GetString(1);
                        string idEquipe = dataReader.GetString(2);
                      
                        CompetitionEquipe CompetitionEquipe = new CompetitionEquipe(idCE,idCompetition,idEquipe);
                        listeCompetitionEquipe.Add(CompetitionEquipe);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeCompetitionEquipe.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeCompetitionEquipe;
        }
        public void insertCompetitionEquipe() {
            Connexion connexion = new Connexion();
            try {
                connexion.connection.Open();
                    string requet = "insert into competitionEquipe (idCompetition,idEquipe) VALUES ('" + idCompetition + "','" + idEquipe + "')";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    command.ExecuteReader();
                    connexion.connection.Close();                
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
            }    
        }

    }
}

