namespace BibData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentCode = c.Int(nullable: false, identity: true),
                        Etat = c.Int(nullable: false),
                        Titre = c.String(),
                        Categorie = c.String(),
                        BibliothequeFK = c.Int(nullable: false),
                        NbreDePlage = c.Int(),
                        Duree = c.Time(precision: 7),
                        nbrdepage = c.Int(),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentCode)
                .ForeignKey("dbo.Bibliotheques", t => t.BibliothequeFK, cascadeDelete: true)
                .Index(t => t.BibliothequeFK);
            
            CreateTable(
                "dbo.Adherant",
                c => new
                    {
                        AdherantCode = c.Int(nullable: false, identity: true),
                        nomComplet_Nom = c.String(),
                        nomComplet_Prenom = c.String(),
                        Image = c.String(nullable: false),
                        Email = c.String(),
                        MotDePasse = c.String(),
                        ConfirmMotDePasse = c.String(),
                        nbAvertissement = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdherantCode);
            
            CreateTable(
                "dbo.EmpruntLivre",
                c => new
                    {
                        DocumentCode = c.Int(nullable: false),
                        AdherantCode = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.DocumentCode, t.AdherantCode, t.Date })
                .ForeignKey("dbo.Adherant", t => t.AdherantCode, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentCode, cascadeDelete: true)
                .Index(t => t.DocumentCode)
                .Index(t => t.AdherantCode);
            
            CreateTable(
                "dbo.Auteurs",
                c => new
                    {
                        AuteurCode = c.Int(nullable: false, identity: true),
                        nomComplet_Nom = c.String(),
                        nomComplet_Prenom = c.String(),
                    })
                .PrimaryKey(t => t.AuteurCode);
            
            CreateTable(
                "dbo.Bibliotheques",
                c => new
                    {
                        BibliothequeCode = c.Int(nullable: false, identity: true),
                        NbrDoc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BibliothequeCode);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Document_DocumentCode = c.Int(nullable: false),
                        Adherant_AdherantCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_DocumentCode, t.Adherant_AdherantCode })
                .ForeignKey("dbo.Documents", t => t.Document_DocumentCode, cascadeDelete: true)
                .ForeignKey("dbo.Adherant", t => t.Adherant_AdherantCode, cascadeDelete: true)
                .Index(t => t.Document_DocumentCode)
                .Index(t => t.Adherant_AdherantCode);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        Document_DocumentCode = c.Int(nullable: false),
                        Adherant_AdherantCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_DocumentCode, t.Adherant_AdherantCode })
                .ForeignKey("dbo.Documents", t => t.Document_DocumentCode, cascadeDelete: true)
                .ForeignKey("dbo.Adherant", t => t.Adherant_AdherantCode, cascadeDelete: true)
                .Index(t => t.Document_DocumentCode)
                .Index(t => t.Adherant_AdherantCode);
            
            CreateTable(
                "dbo.AuthDoc",
                c => new
                    {
                        Document_DocumentCode = c.Int(nullable: false),
                        Auteur_AuteurCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_DocumentCode, t.Auteur_AuteurCode })
                .ForeignKey("dbo.Documents", t => t.Document_DocumentCode, cascadeDelete: true)
                .ForeignKey("dbo.Auteurs", t => t.Auteur_AuteurCode, cascadeDelete: true)
                .Index(t => t.Document_DocumentCode)
                .Index(t => t.Auteur_AuteurCode);
            
            CreateTable(
                "dbo.Professeur",
                c => new
                    {
                        AdherantCode = c.Int(nullable: false),
                        Departement = c.String(),
                        DateDePriseDeFonction = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Salaire = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.AdherantCode)
                .ForeignKey("dbo.Adherant", t => t.AdherantCode)
                .Index(t => t.AdherantCode);
            
            CreateTable(
                "dbo.Etudiant",
                c => new
                    {
                        AdherantCode = c.Int(nullable: false),
                        Filiere = c.String(),
                    })
                .PrimaryKey(t => t.AdherantCode)
                .ForeignKey("dbo.Adherant", t => t.AdherantCode)
                .Index(t => t.AdherantCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Etudiant", "AdherantCode", "dbo.Adherant");
            DropForeignKey("dbo.Professeur", "AdherantCode", "dbo.Adherant");
            DropForeignKey("dbo.Documents", "BibliothequeFK", "dbo.Bibliotheques");
            DropForeignKey("dbo.AuthDoc", "Auteur_AuteurCode", "dbo.Auteurs");
            DropForeignKey("dbo.AuthDoc", "Document_DocumentCode", "dbo.Documents");
            DropForeignKey("dbo.Note", "Adherant_AdherantCode", "dbo.Adherant");
            DropForeignKey("dbo.Note", "Document_DocumentCode", "dbo.Documents");
            DropForeignKey("dbo.Comment", "Adherant_AdherantCode", "dbo.Adherant");
            DropForeignKey("dbo.Comment", "Document_DocumentCode", "dbo.Documents");
            DropForeignKey("dbo.EmpruntLivre", "DocumentCode", "dbo.Documents");
            DropForeignKey("dbo.EmpruntLivre", "AdherantCode", "dbo.Adherant");
            DropIndex("dbo.Etudiant", new[] { "AdherantCode" });
            DropIndex("dbo.Professeur", new[] { "AdherantCode" });
            DropIndex("dbo.AuthDoc", new[] { "Auteur_AuteurCode" });
            DropIndex("dbo.AuthDoc", new[] { "Document_DocumentCode" });
            DropIndex("dbo.Note", new[] { "Adherant_AdherantCode" });
            DropIndex("dbo.Note", new[] { "Document_DocumentCode" });
            DropIndex("dbo.Comment", new[] { "Adherant_AdherantCode" });
            DropIndex("dbo.Comment", new[] { "Document_DocumentCode" });
            DropIndex("dbo.EmpruntLivre", new[] { "AdherantCode" });
            DropIndex("dbo.EmpruntLivre", new[] { "DocumentCode" });
            DropIndex("dbo.Documents", new[] { "BibliothequeFK" });
            DropTable("dbo.Etudiant");
            DropTable("dbo.Professeur");
            DropTable("dbo.AuthDoc");
            DropTable("dbo.Note");
            DropTable("dbo.Comment");
            DropTable("dbo.Bibliotheques");
            DropTable("dbo.Auteurs");
            DropTable("dbo.EmpruntLivre");
            DropTable("dbo.Adherant");
            DropTable("dbo.Documents");
        }
    }
}
