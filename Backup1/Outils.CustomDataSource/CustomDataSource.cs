using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Outils.CustomDataSource
{
    /// <summary>
    /// Classe CustomDataSource
    /// </summary>
    /// <author>JEE</author>
    /// <date>26-01-2014</date>
    public class CustomDataSource
    {
        /// <summary>
        /// La chaine de connexion
        /// </summary>
        private String chaineConnexion;

        private SqlConnection sqlConnexion;

        private SqlTransaction currentTransaction;

        /// <summary>
        /// Détermine si la transaction est locale à l'éxécution de l'instruction SQL
        /// </summary>
        private bool isLocalTransaction = false;

        /// <summary>
        /// Détermine si la transaction est globale (ie la transaction est gérée par l'appelant)
        /// </summary>
        private bool isGlobalTransaction = false;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="pChaineConnexion">Chaine de connexion</param>
        public CustomDataSource(string pChaineConnexion)
        {
            chaineConnexion = pChaineConnexion;
            this.sqlConnexion = new SqlConnection(pChaineConnexion);
        }


        /// <summary>
        /// Démarrage d'une transaction globale
        /// </summary>
        public void StartGlobalTransaction()
        {
            // la transaction est globale
            this.isGlobalTransaction = true;
            // la transaction n'est pas locale
            this.isLocalTransaction = false;
            // ouverture de la connexion sql
            this.sqlConnexion.Open();
            // démarrage de la transaction
            this.currentTransaction = this.sqlConnexion.BeginTransaction();
        }

        /// <summary>
        /// Commit d'une transaction globale
        /// </summary>
        public void CommitGlobalTransaction()
        {
            // commit de la transaction
            this.currentTransaction.Commit();
            // fermeture de la connexion sql
            this.sqlConnexion.Close();
            // réinit des variables pour les transactions
            ClearGlobalTransactionVariables();
        }

        /// <summary>
        /// Permet de réinitialise les variables utilisées pour les transactions globales
        /// </summary>
        private void ClearGlobalTransactionVariables()
        {
            this.isGlobalTransaction = false;
            this.isLocalTransaction = false;
            this.currentTransaction = null;
        }

        /// <summary>
        /// Permet de réinitialisaer les variables utilisées pour les transaction locales
        /// </summary>
        private void ClearLocalTransactionVariables()
        {
            this.isLocalTransaction = false;
            this.currentTransaction = null;
        }

        /// <summary>
        /// Rollback sur une transaction globale
        /// </summary>
        public void RollBackGlobalTransaction()
        {
            // rollback de la transaction
            this.currentTransaction.Rollback();
            // fermeture de la connexion SQL
            this.sqlConnexion.Close();
            // réinit des variables pour les transactions
            ClearGlobalTransactionVariables();
        }


        /// <summary>
        /// Démarrage interne d'une transaction
        /// </summary>
        private void InnerStartTransaction()
        {
            // si la transaction est de niveau global, elle a déjà été démarrée
            if (this.isGlobalTransaction)
            {
                return;
            }

            // ouveture de la connexion (sinon réaliser lors de l'ouverture d'une transaction globale)
            this.sqlConnexion.Open();

            // si la transaction est locale, on la démarre ici
            if (this.isLocalTransaction)
            {
                this.currentTransaction = this.sqlConnexion.BeginTransaction();
            }
        }

        /// <summary>
        /// Commit interne de la transaction
        /// </summary>
        private void InnerCommitTransaction()
        {
            // si le niveau de transaction est globale, on ne fait rien ici
            if (this.isGlobalTransaction)
            {
                return;
            }

            // si la transaction est locale
            if (this.isLocalTransaction)
            {
                // commit
                this.currentTransaction.Commit();
                // réinit des variables pour les transactions
                ClearLocalTransactionVariables();
            }

            // fermeture de la connexion sql
            
            this.sqlConnexion.Close();
        }


        /// <summary>
        /// Rollback interne de la transaction
        /// </summary>
        private void InnerRollBackTransaction()
        {
            // si transaction globale, déjà géré
            if (this.isGlobalTransaction)
            {
                return;
            }

            // si transaction locale
            if (this.isLocalTransaction)
            {
                // application du rollback
                this.currentTransaction.Rollback();
                // réinit des variables pour les transactions
                ClearLocalTransactionVariables();
            }

            // fermeture de la connexion sql

            this.sqlConnexion.Close();
        }

        /// <summary>
        /// Création d'une commande sql (fonction de la présence d'une transaction)
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        protected SqlCommand CreateSqlCommand(string sqlQuery)
        {
            // si transaction présente
            if ((isGlobalTransaction || isLocalTransaction) && this.currentTransaction != null)
            {
                return new SqlCommand(sqlQuery, this.sqlConnexion, this.currentTransaction);
            }
            else
            {
                // sinon création normale
                return new SqlCommand(sqlQuery, this.sqlConnexion);
            }

        }



        /// <summary>
        /// Exécution d'une requête SELECT et construction d'une liste de type T à partir du résultat 
        /// </summary>
        /// <typeparam name="T">Le type des objets de la liste</typeparam>
        /// <param name="pRequete">La requête</param>
        /// <param name="rowMapper">La classe implémentant la fonction d'extraction du DataReader</param>
        /// <param name="parametres">Les paramètres de la requête</param>
        /// <returns></returns>
        public List<T> ExecuterRequeteList<T>(string pRequete, RowMapper<T> rowMapper, bool transactionnal, params Object[] parametres)
        {
            List<T> listeRetour = new List<T>();
            this.isLocalTransaction = transactionnal;

            try
            {
                // démarrage potentiel transaction
                this.InnerStartTransaction();

                using (SqlCommand command = CreateSqlCommand(pRequete))
                {
                    if (parametres != null)
                    {
                        command.Parameters.AddRange(ExtractSqlParameter(pRequete, parametres).ToArray());
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listeRetour.Add(rowMapper.ExtraireDonneesReader(reader));
                        }
                    }
                }

                // comit potentiel
                this.InnerCommitTransaction();

            }
            catch (Exception ex)
            {
                this.InnerRollBackTransaction();
                throw ex;
            }

            return listeRetour;
        }


        /// <summary>
        /// Exécution d'une requête SELECT et construction de type T à partir du résultat 
        /// </summary>
        /// <typeparam name="T">Le type des objets de la liste</typeparam>
        /// <param name="pRequete">La requête</param>
        /// <param name="rowMapper">La classe implémentant la fonction d'extraction du DataReader</param>
        /// <param name="parametres">Les paramètres de la requête</param>
        /// <returns></returns>
        public T ExecuterRequete<T>(string pRequete, RowMapper<T> rowMapper, bool transactionnal, params Object[] parametres)
        {
            T obj = default(T);
            this.isLocalTransaction = transactionnal;

            try
            {
                // démarrage potentiel transaction
                this.InnerStartTransaction();

                using (SqlCommand command = CreateSqlCommand(pRequete))
                {
                    command.Parameters.AddRange(ExtractSqlParameter(pRequete, parametres).ToArray());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            obj = rowMapper.ExtraireDonneesReader(reader);
                        }
                    }
                }

                // comit potentiel
                this.InnerCommitTransaction();

            }
            catch (Exception ex)
            {
                this.InnerRollBackTransaction();
                throw ex;
            }

            return obj;
        }


        /// <summary>
        /// Exécution d'une requête UPDATE et construction de type T à partir du résultat 
        /// </summary>
        /// <typeparam name="T">Le type des objets de la liste</typeparam>
        /// <param name="pRequete">La requête</param>
        /// <param name="rowMapper">La classe implémentant la fonction d'extraction du DataReader</param>
        /// <param name="parametres">Les paramètres de la requête</param>
        /// <returns></returns>
        public int ExecuterSQLCount(string pRequete, bool transactionnal, params Object[] parametres)
        {
            int nbLignes = 0;
            this.isLocalTransaction = transactionnal;

            try
            {
                // démarrage potentiel transaction
                this.InnerStartTransaction();

                using (SqlCommand command = CreateSqlCommand(pRequete))
                {
                    command.Parameters.AddRange(ExtractSqlParameter(pRequete, parametres).ToArray());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nbLignes = reader.GetInt32(1);
                        }
                    }

                }

                // comit potentiel
                this.InnerCommitTransaction();

            }
            catch (Exception ex)
            {
                this.InnerRollBackTransaction();
                throw ex;
            }

            return nbLignes;
        }


        /// <summary>
        /// Exécution d'une requête UPDATE et construction de type T à partir du résultat 
        /// </summary>
        /// <typeparam name="T">Le type des objets de la liste</typeparam>
        /// <param name="pRequete">La requête</param>
        /// <param name="rowMapper">La classe implémentant la fonction d'extraction du DataReader</param>
        /// <param name="parametres">Les paramètres de la requête</param>
        /// <returns></returns>
        public int ExecuterDML(string pRequete, bool transactionnal, params Object[] parametres)
        {
            int nbLignesMisesAJour = 0;
            this.isLocalTransaction = transactionnal;

            try
            {
                // démarrage potentiel transaction
                this.InnerStartTransaction();

                using (SqlCommand command = CreateSqlCommand(pRequete))
                {
                    command.Parameters.AddRange(ExtractSqlParameter(pRequete, parametres).ToArray());

                    nbLignesMisesAJour = command.ExecuteNonQuery();

                }

                // comit potentiel
                this.InnerCommitTransaction();

            }
            catch (Exception ex)
            {
                this.InnerRollBackTransaction();
                throw ex;
            }

            return nbLignesMisesAJour;
        }



        /// <summary>
        /// Permet de créer une liste de SQLParameter en fonction des parametres portés par la requete SQL (@)
        /// et de la liste des paramètres passés lors de l'éxécution de la requete SQL.
        /// </summary>
        /// <param name="sqlQuery">requete sql à analyser</param>
        /// <param name="parametres">parametres à faire matcher avec la liste des paramètres détectés dans la requete SQL</param>
        /// <returns>Liste des paramètres SQL</returns>
        protected List<SqlParameter> ExtractSqlParameter(string sqlQuery, params Object[] parametres)
        {
            List<SqlParameter> returnValue = new List<SqlParameter>();

            // récupération de tous les @qqc
            List<String> listeNomsParametres = new List<string>();
            Regex regex = new Regex("@\\w{1,}");
            MatchCollection collectionParametres = regex.Matches(sqlQuery);

            // pour chaque item répondant à la regex, on crée une liste unique
            foreach (Match matchItem in collectionParametres)
            {
                if (!listeNomsParametres.Contains(matchItem.Value))
                {
                    listeNomsParametres.Add(matchItem.Value);
                }
            }

            // remontée d'exception si mismatch
            if (listeNomsParametres.Count != parametres.Length)
            {
                throw new Exception("Le nombre d'arguments demandés et le nombre d'arguments en entrée ne correspondent pas");
            }

            // création des sql parameters en fonction
            // des noms détectés dans la requete SQL et de la liste de paramètres descendus par la requete
            for (int i = 0; i < listeNomsParametres.Count; i++)
            {
                if (parametres[i] is DateTime && ((DateTime)parametres[i]) == DateTime.MinValue)
                {
                    returnValue.Add(new SqlParameter(listeNomsParametres[i], DBNull.Value));
                }
                else if (parametres[i] == null)
                {
                    returnValue.Add(new SqlParameter(listeNomsParametres[i], DBNull.Value));
                }
                else
                {
                    returnValue.Add(new SqlParameter(listeNomsParametres[i], parametres[i]));
                }
            }

            return returnValue;
        }
    }
}
