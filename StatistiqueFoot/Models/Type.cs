using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Type
    {
       

        public String idType { get; set; }
        public String nom { get; set; }
      

         public Type()
        {
        }

        public Type(String idE, String nom)
        {
            this.idType = idE;
            this.nom = nom;
           
        }

        public List<Type> selectType()
        {
            Connexion connexion = new Connexion();
            List<Type> listeType = new  List<Type>();
            try {
                connexion.connection.Open();
                    string requet = "select * from Type";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string id = dataReader.GetString(0);
                        string nom = dataReader.GetString(1);
                      
                        Type Type = new Type(id,nom);
                        listeType.Add(Type);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeType.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeType;
        }
        public void insertType() {
            Connexion connexion = new Connexion();
            try {
                connexion.connection.Open();
                    string requet = "insert into Type (nom) VALUES ('" + nom + "')";
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

