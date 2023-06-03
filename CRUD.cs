using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace gestion_associations

{
    public class CRUD
    {
        public CRUD()
        {
        // AJOUTER // CREATE 


            // ÉTUDIANT // 

            // FIN ÉTUDIANT // 




            // CREATE DU PROFESSEUR // 







            // LIRE // READ


            // MODIFIER // UPDATE

            // SUPPRIMER // DELETE 



    namespace CRUD_Etudiant
    {
        // Classe représentant un étudiant
        public class Etudiant
        {
            private MySqlConnection connection;
            private string connectionString = "Votre chaîne de connexion MySQL";

            public CRUD()
            {
                connection = new MySqlConnection(connectionString);
            }

            // Partie CREATE - Création d'un étudiant
            public void CreerEtudiant(Etudiant etudiant)
            {
                string query = "INSERT INTO Etudiants (Nom, Prenom) VALUES (@Nom, @Prenom)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nom", etudiant.Nom);
                    command.Parameters.AddWithValue("@Prenom", etudiant.Prenom);
                    // ...

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            // Partie READ - Lecture des étudiants
            public List<Etudiant> ChargerEtudiants()
            {
                List<Etudiant> etudiants = new List<Etudiant>();

                string query = "SELECT * FROM Etudiants";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Etudiant etudiant = new Etudiant();
                            etudiant.Id = Convert.ToInt32(reader["Id"]);
                            etudiant.Nom = reader["Nom"].ToString();
                            etudiant.Prenom = reader["Prenom"].ToString();
                            // ...

                            etudiants.Add(etudiant);
                        }
                    }
                }

                connection.Close();
                return etudiants;
            }

            // Partie UPDATE - Mise à jour d'un étudiant
            public void MettreAJourEtudiant(Etudiant etudiant)
            {
                string query = "UPDATE Etudiants SET Nom = @Nom, Prenom = @Prenom WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nom", etudiant.Nom);
                    command.Parameters.AddWithValue("@Prenom", etudiant.Prenom);
                    command.Parameters.AddWithValue("@Id", etudiant.Id);
                    // ...

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            // Partie DELETE - Suppression d'un étudiant
            public void SupprimerEtudiant(int idEtudiant)
            {
                string query = "DELETE FROM Etudiants WHERE Id = @Id";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idEtudiant);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}