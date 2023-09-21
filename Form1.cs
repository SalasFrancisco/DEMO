using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMO
{
    public partial class Form1 : Form
    {
        Comidas oComida;
        DataTable tCom;

        Personas oPersona;
        DataTable tPer;

        MeGustan oMeGusta;
        DataTable tGus;

        public Form1()
        {
            InitializeComponent();
        }

        private void cbPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            grilla.Rows.Clear();
            foreach (DataRow fGus in tGus.Rows)
            {
                if (fGus["dni"].ToString() == cbPersonas.SelectedValue.ToString())
                {
                    DataRow fCom = tCom.Rows.Find(fGus["comida"]);
                    grilla.Rows.Add(fCom["comida"], fCom["nombre"]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oPersona = new Personas();
            tPer = oPersona.getData();

            oComida = new Comidas();
            tCom = oComida.getData();

            oMeGusta = new MeGustan();
            tGus = oMeGusta.getData();

            cbPersonas.DisplayMember = "nombre";
            cbPersonas.ValueMember = "dni";
            cbPersonas.DataSource = tPer;
        }
    }
}
