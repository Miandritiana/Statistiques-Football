using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Defense
    {
       

        public String idDefense { get; set; }
        public String idEquipe { get; set; }
      
        public Decimal tirs_pm {get; set;}
        public Decimal tacles_pm {get; set;}
        public Decimal interceptions_pm {get; set;}
        public Decimal faute_pm {get; set;}
        public Decimal hors_jeu_pm {get; set;}
        public Decimal note {get; set;}
        public String idType {get; set;}
         public Defense()
        {
        }

        public Defense(String idDefense, String idEquipe,decimal tirs_pm,decimal tacles_pm,decimal interceptions_pm,decimal faute_pm,decimal hors_jeu_pm,decimal note,String idType)
        {
            this.idDefense = idDefense;
            this.idEquipe = idEquipe;
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
                    string requet = "select * from Defense";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String idDefense = dataReader.GetString(0);
                        String idEquipe = dataReader.GetString(1);
                        Decimal tirs_pm = dataReader.GetDecimal(2);
                        Decimal tacles_pm = dataReader.GetDecimal(3);
                        Decimal interceptions_pm = dataReader.GetDecimal(4);
                        Decimal faute_pm = dataReader.GetDecimal(5);
                        Decimal hors_jeu_pm = dataReader.GetDecimal(6);
                        Decimal note = dataReader.GetDecimal(7);
                        String idType = dataReader.GetString(8);
                      
                        Defense Defense = new Defense(idDefense,idEquipe,tirs_pm,tacles_pm,interceptions_pm,faute_pm,hors_jeu_pm,note,idType);
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
                    string requet = "insert into Defense (idEquipe,tirs_pm,tacles_pm,interceptions_pm,faute_pm,hors_jeu_pm,note,idType) VALUES ('" + idEquipe + "','" + tirs_pm + "','" + tacles_pm + "','" + interceptions_pm + "','" + faute_pm + "','" + hors_jeu_pm + "','" + note + "','" + idType + "')";
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

