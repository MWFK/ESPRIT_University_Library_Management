using BibDomain.Entities;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ajout Biblotheque
            Bibliotheque b = new Bibliotheque() { NbrDoc = 100 };
            IBibliothequeService bibliothequeser = new BibliothequeService();
            bibliothequeser.Add(b);
            bibliothequeser.Commit();
            //Ajout 3 Livres 
            Document D = new Livre() { Categorie = "informatique", Titre = "C# pour les debutants", nbrdepage = 157,Etat=Etat.Disponible,BibliothequeFK=1 };
            Document D1 = new Livre() { Categorie = "informatique", Titre = "Developper en .NET", nbrdepage = 209,Etat=Etat.Emprunte,BibliothequeFK=1 };
            Document D2 = new Livre() { Categorie = "informatique", Titre = "UML 2.0", nbrdepage = 358,Etat=Etat.Disponible,BibliothequeFK=1 };
            IDocumetService LS = new DocumentService();
            LS.Add(D);
            LS.Add(D1);
            LS.Add(D2);
            
            //Ajout 3 CD 
            Document cd1 = new CD() { Categorie = "scientifique", Titre = "science de la vie et de la terre", NbreDePlage = 5,Duree=new TimeSpan(10,10,10),Etat=Etat.Disponible, BibliothequeFK = 1 };
            Document cd2 = new CD() { Categorie = "education", Titre = "parler en francais", NbreDePlage = 12, Duree = new TimeSpan(08, 10, 50),Etat=Etat.Emprunte, BibliothequeFK = 1 };
            Document cd3 = new CD() { Categorie = "litterature", Titre = "le Rouge et le noir", NbreDePlage=8, Duree = new TimeSpan(12, 10, 10), Etat=Etat.Disponible,BibliothequeFK = 1 };
            LS.Add(cd1);
            LS.Add(cd2);
            LS.Add(cd3);

            LS.Commit();
            Console.WriteLine("----------------------------Affichages des livres--------------------------------------");
            foreach (var item in LS.GetAll().OfType<Livre>())
            {
                Console.WriteLine("les Livres:" + item.Titre + "  " + item.Categorie + "  " + item.nbrdepage+" "+item.Etat);
            }
            Console.WriteLine("-----------------------------Affichage des CDs-----------------------------------------");
            foreach (var item in LS.GetAll().OfType<CD>())
            {
                Console.WriteLine("LES CD :"+item.Categorie+" "+item.Titre+" "+item.NbreDePlage+" "+item.Etat);
            }
            //Ajout des professeurs 
            Professeur professeur = new Professeur() { nomComplet = new NomComplet() { Nom = "Ahmed", Prenom = "ben salem" }, Departement = "TIC", Salaire = 1200, Image = "ff", Email = "dd@dd.com", nbAvertissement = 3, MotDePasse = "123456", ConfirmMotDePasse = "123456", DateDePriseDeFonction = new DateTime(2018, 01, 22) };
            Professeur professeur1 = new Professeur()
            {
                nomComplet = new NomComplet() { Nom = "cyrine", Prenom = "slimen" },
                Departement = "TIC",
                Salaire = 1400f,
                Image = "ff",
                Email = "dd@dd.com",
                nbAvertissement = 3,
                MotDePasse = "123456",
                ConfirmMotDePasse = "123456",
                DateDePriseDeFonction=new DateTime(2018,08,22)
            };
            Professeur professeur2 = new Professeur()
            {
                nomComplet = new NomComplet() { Nom = "Amine", Prenom = "ben said" },
                Departement = "TIC",
                Salaire = 1000f,
                Image = "ff",
                Email = "dd@dd.com",
                nbAvertissement = 3,
                MotDePasse = "123456",
                ConfirmMotDePasse = "123456",
                DateDePriseDeFonction = new DateTime(2017, 08, 22)
            };
            IProfesseurService ps = new ProfesseurService();
            ps.Add(professeur);
            ps.Add(professeur1);
            ps.Add(professeur2);
            ps.Commit();
            Console.WriteLine("-------------------------------------------Affichage des profs-------------------------");
            foreach (var item in ps.GetAll())
            {
                Console.WriteLine("les Profs : "+item.nomComplet.Nom+ "  "+item.Salaire+" " +item.nbAvertissement);
            }
            //Ajout des etudiants 
            Etudiant Etud = new Etudiant()
            {
                nomComplet = new NomComplet() { Nom = "sami", Prenom = "ben salem" },
                Filiere = "BI",
                Image = "ff",
                Email = "dd@dd.com",
                nbAvertissement = 3,
                MotDePasse = "123456",
                ConfirmMotDePasse = "123456"
            };
            Etudiant Etud1 = new Etudiant()
            {
                nomComplet = new NomComplet() { Nom = "Ramzi", Prenom = "Louati" },
                Filiere = "GL",
                Image = "ff",
                Email = "dd@dd.com",
                nbAvertissement = 3,
                MotDePasse = "123456",
                ConfirmMotDePasse = "123456"
            };
            IEtudiantService ES = new EtudiantService();
            ES.Add(Etud);
            ES.Add(Etud1);
            ES.Commit();
            Console.WriteLine("---------------------------Affichage des Etudiants-------------------------------------");
            foreach (var item in ES.GetAll())
            {
                Console.WriteLine("les etudiants:"+item.nomComplet.Nom+" "+item.nomComplet.Prenom+" " + item.Filiere);
            }
            Console.WriteLine("---------------------------Affichage de la liste trié de prof  selon leur Code---------");
            ps.ListProfTrie();
            Console.WriteLine("---------------------------Affichage des deux premiers Profs---------------------------");
            ps.deuxPremiersProf();
            Console.WriteLine("---------------------------Nombre Total des etudiants--------------------------------- ");
            Console.WriteLine(ES.nbrtotdesetudiants());
            Console.WriteLine("---------------------------Liste des livres disponibles---------------------------------");
            LS.LISTElivreDispo();
            Console.WriteLine("--------------------------Autorisation Emprunt-----------------------------------------");
             Emprunt E = new Emprunt() {  DocumentCode = 1, AdherantCode = 1, Date = new DateTime(2018, 12, 12) };
            Emprunt E1 = new Emprunt() { AdherantCode = 1, DocumentCode = 3, Date = new DateTime(2018, 01, 01) };
            Emprunt E2 = new Emprunt() { AdherantCode = 1, DocumentCode = 4, Date = new DateTime(2018, 02, 12) };
            Emprunt E3 = new Emprunt() { AdherantCode = 1, DocumentCode = 6, Date = new DateTime(2018, 04, 14) };
            EmpruntService Em = new EmpruntService();
           
           
                //Em.AutorisationEmprunt(E);
                //Em.AutorisationEmprunt(E1);
               // Em.AutorisationEmprunt(E2);
                Em.AutorisationEmprunt(E3);
            
           
            
            
           
            Console.WriteLine("----------------------nouveaux Enseignants---------------------------------------------");
            ps.NouvEnseignants();
            Console.ReadKey();
        }
    }
}
