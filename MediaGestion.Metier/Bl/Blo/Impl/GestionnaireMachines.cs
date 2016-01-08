using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediaGestion.Modele.Dl.Dlo;
using MediaGestion.DAO;

namespace MediaGestion.Metier.Bl.Blo.Impl
{
    public class GestionnaireMachines
    {
        /// <summary>
        /// Construction de la liste des Machines
        /// </summary>
        /// <returns></returns>
        public List<Machine> ObtenirMachines()
        {
            MachineDAO MachineDAO = new MachineDAO();
            return MachineDAO.ObtenirListeMachines();
        }

        /// <summary>
        /// Récupération d'un Machine
        /// </summary>
        /// <returns></returns>
        public Machine ObtenirMachine(string pCode)
        {

            MachineDAO MachineDAO = new MachineDAO();
            return MachineDAO.ObtenirMachine(pCode);

        }

        /// <summary>
        /// Ajout d'un Machine
        /// </summary>
        /// <param name="s">Machine à ajouter</param>
        /// <returns></returns>
        public List<Machine> AjouterMachine(Machine s)
        {

            MachineDAO MachineDAO = new MachineDAO();
            MachineDAO.InsertMachine(s);
            return MachineDAO.ObtenirListeMachines();

        }

        /// <summary>
        /// Modification d'un Machine
        /// </summary>
        /// <param name="s">Machine à modifier</param>
        /// <returns></returns>
        public List<Machine> MettreAJourMachine(Machine s, string oldCode)
        {

            MachineDAO MachineDAO = new MachineDAO();

            MachineDAO.UpdateMachine(s, oldCode);

            return MachineDAO.ObtenirListeMachines();

        }

        /// <summary>
        /// Suppression d'un Machine
        /// </summary>
        /// <param name="s">Machine à supprimer</param>
        /// <returns></returns>
        public List<Machine> SupprimerMachine(string pCode)
        {

            MachineDAO MachineDAO = new MachineDAO();

            MachineDAO.DeleteMachine(pCode);

            return MachineDAO.ObtenirListeMachines();

        }


    }
}
