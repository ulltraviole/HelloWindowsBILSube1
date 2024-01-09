using DAL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace OkulApp.BLL
{
    public class OgretmenBL
    {
        Helper hlp = Helper.CreateAsSingleton();

        public bool OgretmenEkle(Ogretmen ogrt)
        {
            try
            {
                SqlParameter[] p = {
                             new SqlParameter("@Ad",ogrt.Ad),
                             new SqlParameter("@Soyad",ogrt.Soyad),
                             new SqlParameter("@TCKN",ogrt.TCKimlikNumarasi)
                         };

                return hlp.ExecuteNonQuery("Insert into tblOgretmenler values(@Ad,@Soyad,@TCKN)", p) > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Ogretmen OgretmenBul(string tckn)
        {
            SqlDataReader dr;
            try
            {
                SqlParameter[] p = { new SqlParameter("@TCKN", tckn) };
                dr = hlp.ExecuteReader("Select id,Ad,Soyad,TCKN from tblOgretmenler where TCKN=@TCKN", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            Ogretmen ogr = null;
            if (dr.Read())
            {
                ogr = new Ogretmen();
                ogr.OgretmenId = Convert.ToInt32(dr["id"]);
                ogr.Ad = dr["Ad"].ToString();
                ogr.Soyad = dr["Soyad"].ToString();
                ogr.TCKimlikNumarasi = dr["TCKN"].ToString();
            }
            dr.Close();
            return ogr;
        }
        public bool OgretmenGuncelle(Ogretmen ogrt)
        {
            try
            {
                SqlParameter[] p = {
                             new SqlParameter("@Ad",ogrt.Ad),
                             new SqlParameter("@Soyad",ogrt.Soyad),
                             new SqlParameter("@TCKN",ogrt.TCKimlikNumarasi),
                             new SqlParameter("@OgretmenId",ogrt.OgretmenId)
                         };
                return hlp.ExecuteNonQuery("Update tblOgretmenler set Ad=@Ad,Soyad=@Soyad,TCKN=@TCKN where id=@OgretmenId", p) > 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool OgretmenSil(int id)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@OgretmenId", id) };
                return hlp.ExecuteNonQuery("Delete from tblOgretmenler where id=@OgretmenId", p) > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}