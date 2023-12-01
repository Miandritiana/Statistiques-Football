using System.Data.SqlClient;


namespace StatistiqueFoot.Models
{
    public class ViewDefense
    {
       

        public String NomEquipe { get; set; }
        public String NomConception { get; set; }
      
        public Double tirs_pm {get; set;}
        public Double tacles_pm {get; set;}
        public Double interceptions_pm {get; set;}
        public Double faute_pm {get; set;}
        public Double hors_jeu_pm {get; set;}
        public Double note {get; set;}
        public String idType {get; set;}
         public ViewDefense()
        {
        }

        public ViewDefense(String NomEquipe, String NomConception,Double tirs_pm,Double tacles_pm,Double interceptions_pm,Double faute_pm,Double hors_jeu_pm,Double note,String idType)
        {
            this.NomEquipe = NomEquipe;
            this.NomConception = NomConception;
            this.tirs_pm = tirs_pm;
            this.tacles_pm = tacles_pm;
            this.interceptions_pm = interceptions_pm;
            this.faute_pm = faute_pm;
            this.hors_jeu_pm = hors_jeu_pm;
            this.note = note;
            this.idType = idType;  
        }

        public List<ViewDefense> selectViewDefense()
        {
            Connexion connexion = new Connexion();
            List<ViewDefense> listeDefense = new  List<ViewDefense>();
            try {
                connexion.connection.Open();
                    string requet = "select * from ViewDefense";
                    SqlCommand command = new SqlCommand(requet, connexion.connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        String NomEquipe = dataReader.GetString(0);
                        String NomConception = dataReader.GetString(1);
                        Double tirs_pm = dataReader.GetDouble(2);
                        Double tacles_pm = dataReader.GetDouble(3);
                        Double interceptions_pm = dataReader.GetDouble(4);
                        Double faute_pm = dataReader.GetDouble(5);
                        Double hors_jeu_pm = dataReader.GetDouble(6);
                        Double note = dataReader.GetDouble(7);
                        String idType = dataReader.GetString(8);
                      
                        ViewDefense ViewDefense = new ViewDefense(NomEquipe,NomConception,tirs_pm,tacles_pm,interceptions_pm,faute_pm,hors_jeu_pm,note,idType);
                        listeDefense.Add(ViewDefense);
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

        public List<ViewDefense> selectViewDefenseByType(String idT)
        {
            Connexion connexion = new Connexion();
            List<ViewDefense> listeViewDefense = new List<ViewDefense>();

            try
            {
                connexion.connection.Open();
                string requet = "SELECT * FROM ViewDefense WHERE idType=@IdType order by tacles_pm desc";
                SqlCommand command = new SqlCommand(requet, connexion.connection);

                command.Parameters.AddWithValue("@IdType", idT);

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    String NomEquipe = dataReader.GetString(0);
                    String NomConception = dataReader.GetString(1);
                    Double tirs_pm = dataReader.GetDouble(2);
                    Double tacles_pm = dataReader.GetDouble(3);
                    Double interceptions_pm = dataReader.GetDouble(4);
                    Double faute_pm = dataReader.GetDouble(5);
                    Double hors_jeu_pm = dataReader.GetDouble(6);
                    Double note = dataReader.GetDouble(7);
                    String idType = dataReader.GetString(8);
                    
                    ViewDefense ViewDefense = new ViewDefense(NomEquipe,NomConception,tirs_pm,tacles_pm,interceptions_pm,faute_pm,hors_jeu_pm,note,idType);
                    listeViewDefense.Add(ViewDefense);
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

            Console.WriteLine(listeViewDefense.Count());
            return listeViewDefense;
        }
    }
}

