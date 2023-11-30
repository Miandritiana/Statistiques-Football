using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Generale
    {
       

        public String idGenerale { get; set; }
        public String idEquipe { get; set; }
      
        public Int32 buts {get; set;}
        public Decimal tirs_pm {get; set;}
        public Decimal discipline {get; set;}
        public Decimal possession {get; set;}
        public Decimal passesReussies {get; set;}
        public Decimal aeriensGagnes {get; set;}
        public Decimal note {get; set;}
        public String idType {get; set;}
         public Generale()
        {
        }

        public Generale(String idGenerale,String idEquipe, Int32 buts,Decimal tirs_pm,Decimal discipline,Decimal possession,Decimal passesReussies,Decimal aeriensGagnes,decimal note,String idType)
        {
            this.idGenerale = idGenerale;
            this.idEquipe = idEquipe;
            this.buts = buts;
            this.tirs_pm = tirs_pm;
            this.discipline = discipline;
            this.possession = possession;
            this.passesReussies = passesReussies;
            this.aeriensGagnes = aeriensGagnes;
            this.note = note;
            this.idType = idType;

           
        }

        public List<Generale> selectGenerale()
        {
            Connexion connexion = new Connexion();
            List<Generale> listeGenerale = new  List<Generale>();
            try {
                connexion.connection.Open();
                    string requet = "select * from Generale";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String idGenerale = dataReader.GetString(0);
                        String idEquipe = dataReader.GetString(1);
                        Int32 buts = dataReader.GetInt32(2);
                        Decimal tirs_pm = dataReader.GetDecimal(2);
                        Decimal discipline = dataReader.GetDecimal(3);
                        Decimal possession   = dataReader.GetDecimal(4);
                        Decimal passesReussies = dataReader.GetDecimal(5);
                        Decimal aeriensGagnes = dataReader.GetDecimal(6);
                        Decimal note = dataReader.GetDecimal(7);
                        String idType = dataReader.GetString(8);
                      
                        Generale Generale = new Generale(idGenerale,idEquipe,buts,tirs_pm,discipline,possession,passesReussies,aeriensGagnes,note,idType);
                        listeGenerale.Add(Generale);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeGenerale.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeGenerale;
        }
        public void insertGenerale() {
            Connexion connexion = new Connexion();
            try {
                connexion.connection.Open();
                    string requet = "insert into Generale (idEquipe,buts,tirs_pm,discipline,possession,passesReussies,aeriensGagnes,note,idType) VALUES ('" + idEquipe + "','" + buts + "','" + tirs_pm + "','" + discipline + "','" + possession + "','" + passesReussies + "','" + aeriensGagnes + "','" + note + "','" + idType + "')";
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