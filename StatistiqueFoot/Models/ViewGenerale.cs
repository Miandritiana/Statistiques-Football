using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class ViewGenerale
    {
       

        public String NomEquipe { get; set; }
        public String NomCompetition { get; set; }
      
        public Int32 buts {get; set;}
        public Double tirs_pm {get; set;}
        public Int32 disciplineJaune {get; set;}
        public Int32 disciplineRouge {get; set;}
        public Double possession {get; set;}
        public Double passesReussies {get; set;}
        public Double aeriensGagnes {get; set;}
        public Double note {get; set;}
        public String idType {get; set;}
         public ViewGenerale()
        {
        }

        public ViewGenerale(String NomEquipe,String NomCompetition, Int32 buts,Double tirs_pm,Int32 disciplineJaune,Int32 disciplineRouge,Double possession,Double passesReussies,Double aeriensGagnes,Double note,String idType)
        {
            this.NomEquipe = NomEquipe;
            this.NomCompetition = NomCompetition;
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

        public List<ViewGenerale> selectViewGenerale()
        {
            Connexion connexion = new Connexion();
            List<ViewGenerale> listeViewGenerale = new  List<ViewGenerale>();
            try {
                connexion.connection.Open();
                    string requet = "select * from ViewGenerale";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String NomEquipe = dataReader.GetString(0);
                        String NomCompetition = dataReader.GetString(1);
                        Int32 buts = dataReader.GetInt32(2);
                        Double tirs_pm = dataReader.GetDouble(3);
                        Int32 disciplineJaune = dataReader.GetInt32(4);
                        Int32 disciplineRouge = dataReader.GetInt32(5);
                        Double possession   = dataReader.GetDouble(6);
                        Double passesReussies = dataReader.GetDouble(7);
                        Double aeriensGagnes = dataReader.GetDouble(8);
                        Double note = dataReader.GetDouble(9);
                        String idType = dataReader.GetString(10);
                      
                        ViewGenerale ViewGenerale = new ViewGenerale(NomEquipe,NomCompetition,buts,tirs_pm,disciplineJaune,disciplineRouge,possession,passesReussies,aeriensGagnes,note,idType);
                        listeViewGenerale.Add(ViewGenerale);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeViewGenerale.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeViewGenerale;
        }

        public List<ViewGenerale> selectViewGeneraleByType(String idT)
        {
            Connexion connexion = new Connexion();
            List<ViewGenerale> listeViewGenerale = new List<ViewGenerale>();

            try
            {
                connexion.connection.Open();
                string requet = "SELECT * FROM ViewGenerale WHERE idType=@IdType order by note desc";
                SqlCommand command = new SqlCommand(requet, connexion.connection);

                command.Parameters.AddWithValue("@IdType", idT);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                        String NomEquipe = dataReader.GetString(0);
                        String NomCompetition = dataReader.GetString(1);
                        Int32 buts = dataReader.GetInt32(2);
                        Double tirs_pm = dataReader.GetDouble(3);
                        Int32 disciplineJaune = dataReader.GetInt32(4);
                        Int32 disciplineRouge = dataReader.GetInt32(5);
                        Double possession   = dataReader.GetDouble(6);
                        Double passesReussies = dataReader.GetDouble(7);
                        Double aeriensGagnes = dataReader.GetDouble(8);
                        Double note = dataReader.GetDouble(9);
                        String idType = dataReader.GetString(10);
                      
                        ViewGenerale ViewGenerale = new ViewGenerale(NomEquipe,NomCompetition,buts,tirs_pm,disciplineJaune,disciplineRouge,possession,passesReussies,aeriensGagnes,note,idType);
                        listeViewGenerale.Add(ViewGenerale);
                }

                dataReader.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Erreur: {ex}");
            }
            finally
            {
                connexion.connection.Close();
            }

            Console.WriteLine(listeViewGenerale.Count());
            return listeViewGenerale;
        }
    }
}