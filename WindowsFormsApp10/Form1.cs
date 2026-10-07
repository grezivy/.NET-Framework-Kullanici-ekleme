using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void listele()
        {
            Tarsus2026Entities tau = new Tarsus2026Entities();
            dataGridView1.DataSource = tau.Students2026.ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Students2026 std = new Students2026
            {
                name = txtAd.Text,
                surname = txtSoyad.Text,
                email = txtEmail.Text
            };
            Tarsus2026Entities tau = new Tarsus2026Entities();
            tau.Students2026.Add(std);
            tau.SaveChanges();
            listele();
        }

        int secilenid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Tarsus2026Entities tau = new Tarsus2026Entities();
            tau.Students2026.Remove(tau.Students2026.Find(secilenid));
            tau.SaveChanges();
            listele();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tarsus2026Entities tau = new Tarsus2026Entities();
            var guncelle = tau.Students2026.Find(secilenid);
            guncelle.name = txtAd.Text;
            guncelle.surname = txtSoyad.Text;
            guncelle.email = txtEmail.Text;
            tau.SaveChanges();
            listele();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Tarsus2026Entities tau = new Tarsus2026Entities();
            dataGridView1.DataSource = tau.Students2026.Where(x=>x.name.Contains(txtAd.Text)).ToList();
            dataGridView1.DataSource = tau.Students2026.Where(x=>x.surname.Contains(txtSoyad.Text)).ToList();
            dataGridView1.DataSource = tau.Students2026.Where(x=>x.email.Contains(txtEmail.Text)).ToList();

            listele();
        }
    }
}

