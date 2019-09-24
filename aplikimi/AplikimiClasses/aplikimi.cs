using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using aplikimi;
namespace aplikimi.AplikimiClasses
{
    class aplikimi
    {
        public string emri { get; set; }
        public string emri_prindit { get; set; }
        public string mbiemri { get; set; }
        public long numri_personal { get; set; }
        public DateTime datelindja { get; set; }
        public string gjinia { get; set; }
        public string shteti_lindjes { get; set; }
        public string shteti_vendbanimit { get; set; }
        public string komuna_vendbanimit { get; set; }
        public string adresa { get; set; }
        public string nr_telefonit { get; set; }
        public string  email { get; set; }
        public string  shkolla_mesme { get; set; }
        public string drejtimi { get; set; }
        public string vendi_shkollimit { get; set; }
        public int suksesi_1 { get; set; }
        public int suksesi_2 { get; set; }
        public int suksesi_3 { get; set; }
        public int piket_matures { get; set; }
        public string fakulteti { get; set; }
        public string departamenti { get; set; }
        public string statusi { get; set; }
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        
        //krijimi i metodes per insertimin e te dhenave

        public bool Insert(aplikimi a)
        {
            
            bool success = false;
            //konekto databazen
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //krijimi i queryt

                string sqltest = "insert into dbo.aplikimi(emri,emri_prindit,mbiemri) values (@emri,@emri_prindit,@mbiemri)";

                string sql = "insert into dbo.aplikimi([emri],emri_prindit ,[mbiemri],[numri_personal],[datelindja]" +
                    " ,[gjinia],[shteti_lindjes] ,[shteti_vendbanimit],[komuna_vendbanimit] ,[adresa] ,[nr_telefonit]" +
                    ",[email] ,[shkolla_mesme] ,[drejtimi],[vendi_shkollimit] ,[suksesi_1] ,[suksesi_2] ,[suksesi_3],[piket_matures]" +
                    ",[fakulteti] ,[departamenti],[statusi]) " +
                    "values(@emri,@emri_prindit ,@mbiemri,@numri_personal,@datelindja" +
                    " ,@gjinia,@shteti_lindjes ,@shteti_vendbanimit,@komuna_vendbanimit ,@adresa ,@nr_telefonit" +
                    ",@email ,@shkolla_mesme ,@drejtimi,@vendi_shkollimit ,@suksesi_1 ,@suksesi_2 ,@suksesi_3,@piket_matures" +
                    ",@fakulteti ,@departamenti,@statusi) ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                //shtimi i te dhenave
                cmd.Parameters.AddWithValue("@emri", a.emri);
                cmd.Parameters.AddWithValue("@emri_prindit", a.emri_prindit);
                cmd.Parameters.AddWithValue("@mbiemri", a.mbiemri);
                cmd.Parameters.AddWithValue("@numri_personal",a.numri_personal);
                cmd.Parameters.AddWithValue("@datelindja", a.datelindja);
                cmd.Parameters.AddWithValue("@gjinia", a.gjinia);
                cmd.Parameters.AddWithValue("@shteti_lindjes", a.shteti_lindjes);
                cmd.Parameters.AddWithValue("@shteti_vendbanimit", a.shteti_vendbanimit);
                cmd.Parameters.AddWithValue("@komuna_vendbanimit", a.komuna_vendbanimit);
                cmd.Parameters.AddWithValue("@adresa", a.adresa);
                cmd.Parameters.AddWithValue("@nr_telefonit", a.nr_telefonit);
                cmd.Parameters.AddWithValue("@email", a.email);
                cmd.Parameters.AddWithValue("@shkolla_mesme", a.shkolla_mesme);
                cmd.Parameters.AddWithValue("@drejtimi", a.drejtimi);
                cmd.Parameters.AddWithValue("@vendi_shkollimit", a.vendi_shkollimit);
                cmd.Parameters.AddWithValue("@suksesi_1", a.suksesi_1);
                cmd.Parameters.AddWithValue("@suksesi_2", a.suksesi_2);
                cmd.Parameters.AddWithValue("@suksesi_3", a.suksesi_3);
                cmd.Parameters.AddWithValue("@piket_matures", a.piket_matures);
                cmd.Parameters.AddWithValue("@fakulteti", a.fakulteti);
                cmd.Parameters.AddWithValue("@departamenti", a.departamenti);
                cmd.Parameters.AddWithValue("@statusi", a.statusi);


                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return success;
        }
    }


  




}
