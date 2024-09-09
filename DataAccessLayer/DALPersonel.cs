using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand cmd = new SqlCommand("Select * From TBLBILGI", Baglanti.bgl);
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent=new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Sehir = dr["SEHIR"].ToString() ;
                ent.Gorev = dr["GOREV"].ToString();
                ent.Maas =short.Parse(dr["MAAS"].ToString());
                //ent.Maas = short.TryParse(dr["MAAS"]?.ToString(), out short maasValue) ? maasValue : (short)0;

                degerler.Add(ent);
            }
            dr.Close();
           return degerler;
        }

        public static int PersonelEkle(EntityPersonel p) 
        {
            SqlCommand cmd2 = new SqlCommand("Insert Into TBLBILGI(AD,SOYAD,GOREV,SEHIR,MAAS) Values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (cmd2.Connection.State != ConnectionState.Open)
            {
                cmd2.Connection.Open();
            }
            cmd2.Parameters.AddWithValue("@p1", p.Ad);
            cmd2.Parameters.AddWithValue("@p2", p.Soyad);
            cmd2.Parameters.AddWithValue("@p3", p.Gorev);
            cmd2.Parameters.AddWithValue("@p4", p.Sehir);
            cmd2.Parameters.AddWithValue("@p5", p.Maas);
            return cmd2.ExecuteNonQuery();
        }
        public static bool PersonelSil(int p)
        {
            SqlCommand cmd3 = new SqlCommand("Delete From TBLBILGI where ID=@C1", Baglanti.bgl);
            if (cmd3.Connection.State != ConnectionState.Open)
            {
                cmd3.Connection.Open();
            }
            cmd3.Parameters.AddWithValue("@C1", p);
            return cmd3.ExecuteNonQuery()>0;
        }
        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand cmd4 = new SqlCommand("Update TBLBILGI Set AD=@p1,SOYAD=@p2,GOREV=@p3,SEHIR=@p4,MAAS=@p5 Where ID=@p6", Baglanti.bgl);
            if (cmd4.Connection.State != ConnectionState.Open)
            {
                cmd4.Connection.Open();
            }
            cmd4.Parameters.AddWithValue("@p1",ent.Ad);
            cmd4.Parameters.AddWithValue("@p2",ent.Soyad);
            cmd4.Parameters.AddWithValue("@p3",ent.Gorev);
            cmd4.Parameters.AddWithValue("@p4",ent.Sehir);
            cmd4.Parameters.AddWithValue("@p5",ent.Maas);
            cmd4.Parameters.AddWithValue("@p6",ent.Id);
            return cmd4.ExecuteNonQuery() > 0;
        }
        
    }
}
