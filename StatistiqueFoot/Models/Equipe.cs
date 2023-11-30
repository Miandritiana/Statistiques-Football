using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Equipe
    {
       

        public String idEquipe { get; set; }
        public String nom { get; set; }
      

         public Equipe()
        {
        }

        public Equipe(String idE, String nom)
        {
            this.idEquipe = idE;
            this.nom = nom;
           
        }

        public List<Equipe> selectEquipe()
        {
            Connexion connexion = new Connexion();
            List<Equipe> listeEquipe = new  List<Equipe>();
            try {
                connexion.connection.Open();
                    string requet = "select * from Equipe";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string id = dataReader.GetString(0);
                        string nom = dataReader.GetString(1);
                      
                        Equipe Equipe = new Equipe(id,nom);
                        listeEquipe.Add(Equipe);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeEquipe.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeEquipe;
        }
        public void insertPlainte() {
            Connexion connexion = new Connexion();
            try {
                connexion.connection.Open();
                    string requet = "insert into Equipe (nom) VALUES ('" + nom + "')";
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

