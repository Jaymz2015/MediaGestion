using MediaGestion.Metier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaGestion.Modele.Dl.Dlo;
using System.Collections.Generic;

namespace TestProjectMediaGestion
{
    
    
    /// <summary>
    ///Classe de test pour GestionnaireFilmsTest, destinée à contenir tous
    ///les tests unitaires GestionnaireFilmsTest
    ///</summary>
    [TestClass()]
    public class GestionnaireFilmsTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        // 
        //Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        //Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        public static Guid id;

        /// <summary>
        ///Test pour CreerFilmEtExemplaire
        ///</summary>
        [TestMethod()]
        public void CreerFilmEtExemplaireTest()
        {
            try
            {
                GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
                Film pFilm = new Film(new Guid("A727E383-9999-47C1-9AC8-ECADDAD634E1")); // TODO: initialisez à une valeur appropriée
                pFilm.Titre = "TESTFILM";
                pFilm.PEGI = 0;
                pFilm.Synopsys = "Synopsys";
                pFilm.Acteurs = "Acteurs";
                pFilm.Realisateur = "Realisateur";
                pFilm.Photo = "10 000.jpg";
                pFilm.TypeMedia = MediaGestion.Modele.Constantes.EnumTypeMedia.FILM;
                pFilm.UrlFiche = "";
                pFilm.LeGenre = new Genre();
                pFilm.LeGenre.Code = "AVEN";
                pFilm.Duree = 120;
                pFilm.DateSortie = DateTime.Parse("2012-01-03");
                pFilm.Note = 0;

                string pCodeSupport = "DVD"; // TODO: initialisez à une valeur appropriée

                Guid pCodeProprietaire = new Guid("A727E383-ECAE-47C1-9AC8-ECADDAD634E1"); // TODO: initialisez à une valeur appropriée

                DateTime pDateAcquisition = DateTime.Parse("2013-01-03"); ; // TODO: initialisez à une valeur appropriée

                int pEtat = 0; // TODO: initialisez à une valeur appropriée

                Film expected = null; // TODO: initialisez à une valeur appropriée
                Film actual;

                actual = target.CreerFilmEtExemplaire(pFilm, pCodeSupport, pCodeProprietaire, pDateAcquisition, pEtat);

                Assert.AreEqual("TESTFILM", actual.Titre);
          
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///Test pour MettreAJourFilm
        ///</summary>
        [TestMethod()]
        public void MettreAJourFilmTest()
        {
            GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
            Guid idFilm = new Guid("A727E383-9999-47C1-9AC8-ECADDAD634E1"); // TODO: initialisez à une valeur appropriée

            Film expected = null; // TODO: initialisez à une valeur appropriée
            Film actual;

            Film f = target.ObtenirLeFilmComplet(idFilm);

            f.Acteurs = "GIBSON";

            target.MettreAJourFilm(f);

            f = target.ObtenirLeFilmComplet(idFilm);

            Assert.AreEqual("GIBSON", f.Acteurs);
        }
        

        /// <summary>
        ///Test pour ObtenirLeFilmComplet
        ///</summary>
        [TestMethod()]
        public void ObtenirLeFilmCompletTest()
        {
            try {
                GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
                Guid idFilm = new Guid("A727E383-9999-47C1-9AC8-ECADDAD634E1"); // TODO: initialisez à une valeur appropriée
            
                Film expected = null; // TODO: initialisez à une valeur appropriée
                Film actual;

                actual = target.ObtenirLeFilmComplet(idFilm);


                Assert.AreEqual("TESTFILM", actual.Titre);
                Assert.AreEqual(1, actual.ListeExemplaire.Count);
                Assert.AreEqual("TESTFILM", actual.ListeExemplaire[0].LeMedia.Titre);
                Assert.AreEqual(DateTime.Today, actual.DateCreation.Date);
                Assert.AreEqual(DateTime.Today, actual.DateDerniereModification.Date);
                Assert.AreEqual(DateTime.Parse("2013-01-03"), actual.ListeExemplaire[0].DateAcquisition.Date);
                Assert.AreEqual("A727E383-ECAE-47C1-9AC8-ECADDAD634E1", actual.ListeExemplaire[0].LeProprietaire.Code.ToString().ToUpper());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        ///Test pour SupprimerFilm
        ///</summary>
        [TestMethod()]
        public void SupprimerMediaTest()
        {
            try
            {
                GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
                Guid pCodeFilm = new Guid("A727E383-9999-47C1-9AC8-ECADDAD634E1"); // TODO: initialisez à une valeur appropriée
                int result = target.SupprimerMedia(pCodeFilm);
                Assert.AreEqual(1, result);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        ///// <summary>
        /////Test pour CreerFilmEtSouhait
        /////</summary>
        //[TestMethod()]
        //public void CreerFilmEtSouhaitTest()
        //{
        //    GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
        //    Film pFilm = null; // TODO: initialisez à une valeur appropriée
        //    string pCodeSupport = string.Empty; // TODO: initialisez à une valeur appropriée
        //    Guid pCodeProprietaire = new Guid(); // TODO: initialisez à une valeur appropriée
        //    Film expected = null; // TODO: initialisez à une valeur appropriée
        //    Film actual;
        //    actual = target.CreerFilmEtSouhait(pFilm, pCodeSupport, pCodeProprietaire);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        //}

        

        ///// <summary>
        /////Test pour ObtenirFilms
        /////</summary>
        //[TestMethod()]
        //public void ObtenirFilmsTest()
        //{
        //    GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
        //    List<Film> expected = null; // TODO: initialisez à une valeur appropriée
        //    List<Film> actual;
        //    actual = target.ObtenirFilms();
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        //}

        ///// <summary>
        /////Test pour ObtenirLeFilm
        /////</summary>
        //[TestMethod()]
        //public void ObtenirLeFilmTest()
        //{
        //    GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
        //    Guid idFilm = new Guid(); // TODO: initialisez à une valeur appropriée
        //    Film expected = null; // TODO: initialisez à une valeur appropriée
        //    Film actual;
        //    actual = target.ObtenirLeFilm(idFilm);
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
        //}

        

        

        ///// <summary>
        /////Test pour SupprimerSouhait
        /////</summary>
        //[TestMethod()]
        //public void SupprimerSouhaitTest()
        //{
        //    GestionnaireFilms target = new GestionnaireFilms(); // TODO: initialisez à une valeur appropriée
        //    Guid pCodeFilm = new Guid(); // TODO: initialisez à une valeur appropriée
        //    Guid pCodeProprietaire = new Guid(); // TODO: initialisez à une valeur appropriée
        //    string pCodeSupport = string.Empty; // TODO: initialisez à une valeur appropriée
        //    target.SupprimerSouhait(pCodeFilm, pCodeProprietaire, pCodeSupport);
        //    Assert.Inconclusive("Une méthode qui ne retourne pas une valeur ne peut pas être vérifiée.");
        //}
    }
}
