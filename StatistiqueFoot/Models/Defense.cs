using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Defense
    {
       

        public String idDefense { get; set; }
        public String idCE { get; set; }
      
        public Double tirs_pm {get; set;}
        public Double tacles_pm {get; set;}
        public Double interceptions_pm {get; set;}
        public Double faute_pm {get; set;}
        public Double hors_jeu_pm {get; set;}
        public Double note {get; set;}
        public String idType {get; set;}
         public Defense()
        {
        }

        public Defense(String idDefense, String idCE,Double tirs_pm,Double tacles_pm,Double interceptions_pm,Double faute_pm,Double hors_jeu_pm,Double note,String idType)
        {
            this.idDefense = idDefense;
            this.idCE = idCE;
            this.tirs_pm = tirs_pm;
            this.tacles_pm = tacles_pm;
            this.interceptions_pm = interceptions_pm;
            this.faute_pm = faute_pm;
            this.hors_jeu_pm = hors_jeu_pm;
            this.note = note;
            this.idType = idType;

           
        }

        public List<Defense> selectDefense()
        {
            Connexion connexion = new Connexion();
            List<Defense> listeDefense = new  List<Defense>();
            try {
                connexion.connection.Open();
                    string requet = "select * from defense";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String idDefense = dataReader.GetString(0);
                        String idCE = dataReader.GetString(1);
                        Double tirs_pm = dataReader.GetDouble(2);
                        Double tacles_pm = dataReader.GetDouble(3);
                        Double interceptions_pm = dataReader.GetDouble(4);
                        Double faute_pm = dataReader.GetDouble(5);
                        Double hors_jeu_pm = dataReader.GetDouble(6);
                        Double note = dataReader.GetDouble(7);
                        String idType = dataReader.GetString(8);
                      
                        Defense Defense = new Defense(idDefense,idCE,tirs_pm,tacles_pm,interceptions_pm,faute_pm,hors_jeu_pm,note,idType);
                        listeDefense.Add(Defense);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeDefense.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeDefense;
        }
        public void insertDefense() {
            Connexion connexion = new Connexion();
            try {
                connexion.connection.Open();
                    string requet = "insert into defense (idCE,tirs_pm,tacles_pm,interceptions_pm,faute_pm,hors_jeu_pm,note,idType) VALUES ('" + idCE + "','" + tirs_pm + "','" + tacles_pm + "','" + interceptions_pm + "','" + faute_pm + "','" + hors_jeu_pm + "','" + note + "','" + idType + "')";
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

