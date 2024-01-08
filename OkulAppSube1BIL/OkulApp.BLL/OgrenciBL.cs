using OkulApp.MODEL;
using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using DAL;
using System.Net;

namespace OkulApp.BLL
{
    public class OgrenciBL
    {
        Helper hlp = Helper.CreateAsSingleton();
        public bool OgrenciEkle(Ogrenci ogr)
        {
            SqlParameter[] p = {
                             new SqlParameter("@Ad",ogr.Ad),
                             new SqlParameter("@Soyad",ogr.Soyad),
                             new SqlParameter("@Numara",ogr.Numara)
                         };

            try
            {
                return hlp.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad,@Soyad,@Numara)", p) > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool OgrenciGuncelle(Ogrenci ogr)
        {
            SqlParameter[] p = {
                             new SqlParameter("@Ad",ogr.Ad),
                             new SqlParameter("@Soyad",ogr.Soyad),
                             new SqlParameter("@Numara",ogr.Numara),
                             new SqlParameter("@Ogrenciid",ogr.Ogrenciid)
                         };
            try
            {
                return hlp.ExecuteNonQuery("Update tblOgrenciler set Ad=@Ad,Soyad=@Soyad,Numara=@Numara where id=@Ogrenciid", p) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool OgrenciSil(int id)
        {
            SqlParameter[] p = { new SqlParameter("@OgrenciId", id) };
            try
            {
                return hlp.ExecuteNonQuery("Delete from tblOgrenciler where id=@OgrenciId", p) > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Ogrenci OgrenciBul(string numara)
        {
            SqlParameter[] p = { new SqlParameter("@Numara", numara) };
            SqlDataReader dr;
            try
            {
                dr = hlp.ExecuteReader("Select id,Ad,Soyad,Numara from tblOgrenciler where Numara=@Numara", p);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            Ogrenci ogr = null;
            if (dr.Read())
            {
                ogr = new Ogrenci();
                ogr.Ogrenciid = Convert.ToInt32(dr["id"]);
                ogr.Ad = dr["Ad"].ToString();
                ogr.Soyad = dr["Soyad"].ToString();
                ogr.Numara = dr["Numara"].ToString();
            }
            dr.Close();
            return ogr;
        }
    }
}
//n Katmanlı Mimari