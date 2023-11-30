using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class ViewAttaque
    {
       

        public String NomEquipe { get; set; }
        public String NomCompetition { get; set; }
      
        public Double tirs_pm {get; set;}
        public Double tirs_CA_pm {get; set;}
        public Double dribbles_pm {get; set;}
        public Double faute_subies_pm {get; set;}
        public Double note {get; set;}
        public String idType {get; set;}
         public ViewAttaque()
        {
        }

        public ViewAttaque(String NomEquipe, String NomCompetition,Double tirs_pm,Double tirs_CA_pm,Double dribbles_pm,Double faute_subies_pm,Double note,String idType)
        {
            this.NomEquipe = NomEquipe;
            this.NomCompetition = NomCompetition;
            this.tirs_pm = tirs_pm;
            this.tirs_CA_pm = tirs_CA_pm;
            this.dribbles_pm = dribbles_pm;
            this.faute_subies_pm = faute_subies_pm;
            this.note = note;
            this.idType = idType;           
        }

        public List<ViewAttaque> selectViewAttaque()
        {
            Connexion connexion = new Connexion();
            List<ViewAttaque> listeViewAttaque = new  List<ViewAttaque>();
            try {
                connexion.connection.Open();
                    string requet = "select * from ViewAttaque";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String NomEquipe = dataReader.GetString(0);
                        String NomCompetition = dataReader.GetString(1);
                        Double tirs_pm = dataReader.GetDouble(2);
                        Double tirs_CA_pm = dataReader.GetDouble(3);
                        Double dribbles_pm = dataReader.GetDouble(4);
                        Double faute_subies_pm = dataReader.GetDouble(5);
                        Double note = dataReader.GetDouble(6);
                        String idType = dataReader.GetString(7);
                      
                        ViewAttaque ViewAttaque = new ViewAttaque(NomEquipe,NomCompetition,tirs_pm,tirs_CA_pm,dribbles_pm,faute_subies_pm,note,idType);
                        listeViewAttaque.Add(ViewAttaque);
                    }
                    dataReader.Close();
                    connexion.connection.Close();                
                Console.WriteLine(listeViewAttaque.Count());
            }
            catch (System.Exception ex) {
                Console.WriteLine($"Erreur: {ex}");
        
            }    
            return listeViewAttaque;
        }

      public List<ViewAttaque> selectViewAttaqueByType(String idT)
        {
            Connexion connexion = new Connexion();
            List<ViewAttaque> listeViewAttaque = new List<ViewAttaque>();

            try
            {
                connexion.connection.Open();
                string requet = "SELECT * FROM ViewAttaque WHERE idType=@IdType";
                SqlCommand command = new SqlCommand(requet, connexion.connection);

                command.Parameters.AddWithValue("@IdType", idT);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    String NomEquipe = dataReader.GetString(0);
                    String NomCompetition = dataReader.GetString(1);
                    Double tirs_pm = dataReader.GetDouble(2);
                    Double tirs_CA_pm = dataReader.GetDouble(3);
                    Double dribbles_pm = dataReader.GetDouble(4);
                    Double faute_subies_pm = dataReader.GetDouble(5);
                    Double note = dataReader.GetDouble(6);
                    String idType = dataReader.GetString(7);

                    ViewAttaque ViewAttaque = new ViewAttaque(NomEquipe, NomCompetition, tirs_pm, tirs_CA_pm, dribbles_pm, faute_subies_pm, note, idType);
                    listeViewAttaque.Add(ViewAttaque);
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

            Console.WriteLine(listeViewAttaque.Count());
            return listeViewAttaque;
        }

    
    }
}

