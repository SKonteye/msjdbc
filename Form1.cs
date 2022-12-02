using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionCouture.Model;
using System.Data.SqlClient;

namespace GestionCouture
{
    public partial class Form1 : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        SqlConnection con = new SqlConnection("Data Source=GOAT;Initial Catalog=bdCoutureDITI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        Personne pers = new Personne();
        Client client = new Client();

        private bdCoutureDITIEntities db = new bdCoutureDITIEntities();
        public Form1()
        {
            InitializeComponent();


        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pers.nomPers = txtNom.Text.Trim();
            pers.prenomPers = txtPrenom.Text.Trim();
            pers.telPers = txtTelephone.Text.Trim();
            pers.emailPers = txtEmail.Text.Trim();
            pers.adressePers = txtAdresse.Text.Trim();
            client.genre = cbbGenre.Text.Trim();

            db.Personne.Add(pers);
            db.Client.Add(client);


            db.SaveChanges();

            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            cbbGenre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            MessageBox.Show("Insertion réussie");
        }


        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLister_Click(object sender, EventArgs e)
        {

            sda = new SqlDataAdapter(@"SELECT prenomPers,nomPers,genre,adressePers,telPers,emailPers  FROM Personne t1 JOIN Client t2 ON t1.idPers = t2.idPers ORDER BY t1.idPers;", con);
            dt = new DataTable();
            sda.Fill(dt);
            dtgView.DataSource = dt;
            this.dtgView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}

