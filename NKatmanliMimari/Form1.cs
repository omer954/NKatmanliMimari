using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;

namespace NKatmanliMimari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> Perlist = LogicPersonel.LogicLayerPersonelListesi();
            dataGridView1.DataSource = Perlist;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent=new EntityPersonel();
            ent.Ad=TxtAd.Text;
            ent.Soyad=TxtSoyad.Text;
            ent.Sehir=TxtSehir.Text;
            ent.Maas=short.Parse( TxtMaas.Text);
            ent.Gorev=TxtGorev.Text;
            LogicPersonel.LogicLayerPersonelEkle(ent);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent=new EntityPersonel();
            ent.Id = Convert.ToInt32(textBox1.Text);
            LogicPersonel.LogicLayerPersonelSil(ent.Id);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(textBox1.Text);
            ent.Ad = TxtAd.Text;
            ent.Soyad = TxtSoyad.Text;
            ent.Sehir = TxtSehir.Text;
            ent.Maas = short.Parse(TxtMaas.Text);
            ent.Gorev = TxtGorev.Text;
            LogicPersonel.LogicLayerPersonelGuncelle(ent);
        }
    }
}
