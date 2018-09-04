using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using HTPIFoundation.Models;

namespace HTPIFoundation.Models
{
    public class HTPIFoundationContext : DbContext
    {
        public string ConnectionString { get; set; }
        public HTPIFoundationContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public HTPIFoundationContext (DbContextOptions<HTPIFoundationContext> options)
            : base(options)
        {
        }

        public DbSet<HTPIFoundation.Models.Utilisateur> Utilisateur { get; set; }
        public DbSet<HTPIFoundation.Models.Membre> Membre { get; set; }
        public DbSet<HTPIFoundation.Models.Paiement> Paiement { get; set; }
        public DbSet<HTPIFoundation.Models.DonHtpi> DonHtpi { get; set; }
        public DbSet<HTPIFoundation.Models.AutreTypePiece> AutreTypePiece { get; set; }
        public DbSet<HTPIFoundation.Models.Operateur> Operateur { get; set; }
        public DbSet<HTPIFoundation.Models.Pays> Pays { get; set; }
        public DbSet<HTPIFoundation.Models.PieceIdentite> PieceIdentite { get; set; }
        public DbSet<HTPIFoundation.Models.TypeJustificatifDomicile> TypeJustificatifDomicile { get; set; }
        public DbSet<HTPIFoundation.Models.TypePieceIdentite> TypePieceIdentite { get; set; }
        public DbSet<HTPIFoundation.Models.Upload> Upload { get; set; }

    }
}
