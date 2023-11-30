using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class Generale
    {
       

        public String idGenerale { get; set; }
        public String idCE { get; set; }
      
        public Int32 buts {get; set;}
        public Double tirs_pm {get; set;}
        public Int32 disciplineJaune {get; set;}
        public Int32 disciplineRouge {get; set;}
        public Double possession {get; set;}
        public Double passesReussies {get; set;}
        public Double aeriensGagnes {get; set;}
        public Double note {get; set;}
        public String idType {get; set;}
         public Generale()
        {
        }

        public Generale(String idGenerale,String idCE, Int32 buts,Double tirs_pm,Int32 disciplineJaune,Int32 disciplineRouge,Double possession,Double passesReussies,Double aeriensGagnes,Double note,String idType)
        {
            this.idGenerale = idGenerale;
            this.idCE = idCE;
            this.buts = buts;
            this.tirs_pm = tirs_pm;
            this.disciplineJaune = disciplineJaune;
            this.disciplineRouge = disciplineRouge;
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
                    string requet = "select * from generale";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String idGenerale = dataReader.GetString(0);
                        String idCE = dataReader.GetString(1);
                        Int32 buts = dataReader.GetInt32(2);
                        Double tirs_pm = dataReader.GetDouble(3);
                        Int32 disciplineJaune = dataReader.GetInt32(4);
                        Int32 disciplineRouge = dataReader.GetInt32(5);
                        Double possession   = dataReader.GetDouble(6);
                        Double passesReussies = dataReader.GetDouble(7);
                        Double aeriensGagnes = dataReader.GetDouble(8);
                        Double note = dataReader.GetDouble(9);
                        String idType = dataReader.GetString(10);
                      
                        Generale Generale = new Generale(idGenerale,idCE,buts,tirs_pm,disciplineJaune,disciplineRouge,possession,passesReussies,aeriensGagnes,note,idType);
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
                    string requet = "insert into generale (idCE,buts,tirs_pm,disciplineJaune,disciplineRouge,possession,passesReussies,aeriensGagnes,note,idType) VALUES ('" + idCE + "','" + buts + "','" + tirs_pm + "','" + disciplineJaune + "','" + disciplineRouge + "','" + possession + "','" + passesReussies + "','" + aeriensGagnes + "','" + note + "','" + idType + "')";
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