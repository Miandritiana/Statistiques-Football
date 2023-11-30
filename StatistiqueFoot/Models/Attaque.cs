using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Attaque
    {
       

        public String idAttaque { get; set; }
        public String idEquipe { get; set; }
      
        public Decimal tirs_pm {get; set;}
        public Decimal tirs_CA_pm {get; set;}
        public Decimal dribbles_pm {get; set;}
        public Decimal faute_subies_pm {get; set;}
        public Decimal note {get; set;}
        public String idType {get; set;}
         public Attaque()
        {
        }

        public Attaque(String idAttaque, String idEquipe,decimal tirs_pm,decimal tirs_CA_pm,decimal dribbles_pm,decimal faute_subies_pm,decimal note,String idType)
        {
            this.idAttaque = idAttaque;
            this.idEquipe = idEquipe;
            this.tirs_pm = tirs_pm;
            this.tirs_CA_pm = tirs_CA_pm;
            this.dribbles_pm = dribbles_pm;
            this.faute_subies_pm = faute_subies_pm;
            this.note = note;
            this.idType = idType;

           
        }

        public List<Attaque> selectAttaque()
        {
            Connexion connexion = new Connexion();
            List<Attaque> listeAttaque = new  List<Attaque>();
            try {
                connexion.connection.Open();
                    string requet = "select * from Attaque";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String idAttaque = dataReader.GetString(0);
                        String idEquipe = dataReader.GetString(1);
                        Decimal tirs_pm = dataReader.GetDecimal(2);
                        Decimal tirs_CA_pm = dataReader.GetDecimal(3);
                        Decimal dribbles_pm = dataReader.GetDecimal(4);
                        Decimal faute_subies_pm = dataReader.GetDecimal(5);
                        Decimal note = dataReader.GetDecimal(6);
                        String idType = dataReader.GetString(7);
                      
                        Attaque Attaque = new Attaque(idAttaque,idEquipe,tirs_pm,tirs_CA_pm,dribbles_pm,faute_subies_pm,note,idType);
                        listeAttaque.Add(Attaque);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeAttaque.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeAttaque;
        }
        public void insertAttaque() {
            Connexion connexion = new Connexion();
            try {
                connexion.connection.Open();
                    string requet = "insert into Attaque (idEquipe,tirs_pm,tirs_CA_pm,dribbles_pm,faute_subies_pm,note,idType) VALUES ('" + idEquipe + "','" + tirs_pm + "','" + tirs_CA_pm + "','" + dribbles_pm + "','" + faute_subies_pm + "','" + note + "','" + idType + "')";
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

