using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Competition
    {
       

        public String idEquipe { get; set; }
        public String nom { get; set; }
      

         public Competition()
        {
        }

        public Competition(String idE, String nom)
        {
            this.idEquipe = idE;
            this.nom = nom;
           
        }

        public List<Competition> selectCompetition()
        {
            Connexion connexion = new Connexion();
            List<Competition> listeCompetition = new  List<Competition>();
            try {
                connexion.connection.Open();
                    string requet = "select * from Competition";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string id = dataReader.GetString(0);
                        string nom = dataReader.GetString(1);
                      
                        Competition Competition = new Competition(id,nom);
                        listeCompetition.Add(Competition);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeCompetition.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeCompetition;
        }
        public void insertPlainte() {
            Connexion connexion = new Connexion();
            try {
                connexion.connection.Open();
                    string requet = "insert into equipe (nom) VALUES ('" + nom + "')";
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

