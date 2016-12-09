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
    public List<Model_mdesignation> obj_designation = new List<Model_mdesignation>();
    public List<Model_musersView> obj_userView = new List<Model_musersView>();
    public List<Model_mcorporate> obj_corporate = new List<Model_mcorporate>();
    public List<Model_mzoneResult> obj_zoneResult = new List<Model_mzoneResult>();
    public List<Model_mcircleResult> obj_circlrResult = new List<Model_mcircleResult>();
    public List<Model_mdivResult> obj_divResult = new List<Model_mdivResult>();
    public List<Model_subDivResult> obj_subdivResult = new List<Model_subDivResult>();
    public List<Model_sectionResult> obj_sectionResult = new List<Model_sectionResult>();
    //Added By Anil
    public string usermessage { get; set; }

    public DataTable resultData = new DataTable();
    // Model Objects
  }
}