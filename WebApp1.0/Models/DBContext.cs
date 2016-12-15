using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp1._0.Models
{
  public class DBContext : DbContext
  {
    public DBContext()
    {
      Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DBWB"].ConnectionString;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Model_mzone>().ToTable("mzone");
    }
    // Database Access
    public DbSet<Model_muser> Users { get; set; }
    public DbSet<Model_mzone> Zone { get; set; }
    public DbSet<Model_mcircle> Circle { get; set; }
    public DbSet<Model_mdivision> Division { get; set; }
    public DbSet<Model_msubdivision> SubDivision { get; set; }
    public DbSet<Model_msection> Section { get; set; }
    public DbSet<Model_msupplier> Supplier { get; set; }
    public DbSet<Model_mtransformer> Transformer { get; set; }
    public DbSet<Model_mlocation> Location { get; set; }
    public DbSet<Model_mrole> roles { get; set; }
    //Added By Anil
    public DbSet<Model_mdesignation> designation { get; set; }
    public DbSet<Model_musersView> userView { get; set; }
    public DbSet<Model_mcorporate> corporate { get; set; }
    public DbSet<Model_mzoneResult> ZoneResult { get; set; }
    public DbSet<Model_mcircleResult> CircleResult { get; set; }
    public DbSet<Model_mdivResult> divResult { get; set; }
    public DbSet<Model_subDivResult> subdivResult { get; set; }
    public DbSet<Model_sectionResult> sectionResult { get; set; }
    public DbSet<Model_LocationResult> locResult { get; set; }
    public DbSet<Model_mfeeder> feeder { get; set; }
    public DbSet<Model_mFeederCategory> fcategory { get; set; }
    public DbSet<Model_mstationcapacity> StationCapacity { get; set; }
    public DbSet<Model_Feeder> feeders { get; set; }
    public DbSet<Model_mDtrCapacity> dtrCapacity { get; set; }
    public DbSet<Model_mEntityType> entityType { get; set; }
    public DbSet<Model_mScheme> scheme { get; set; }
    //Added By Anil
    // Database Access

    // Model Objects
    public List<Model_mzone> obj_zone = new List<Model_mzone>();
    public List<Model_mcircle> obj_circle = new List<Model_mcircle>();
    public List<Model_mdivision> obj_division = new List<Model_mdivision>();
    public List<Model_msubdivision> obj_subdivision = new List<Model_msubdivision>();
    public List<Model_msection> obj_section = new List<Model_msection>();
    public List<Model_TransformerSuppResult> obj_transformerSuppCode = new List<Model_TransformerSuppResult>();
    public Model_mlocation obj_location = new Model_mlocation();
    public List<Model_mtransformerimage> images = new List<Model_mtransformerimage>();
    public List<Model_ExcelImport> importtoexcel = new List<Model_ExcelImport>();

    //Added By Anil
    public DataTable resultVal = new DataTable();
    public DataTable resultView = new DataTable();
    public DataTable resultData = new DataTable();
    public DataTable resultArray = new DataTable();
    //Added By Anil
    public string usermessage { get; set; }

  }
}