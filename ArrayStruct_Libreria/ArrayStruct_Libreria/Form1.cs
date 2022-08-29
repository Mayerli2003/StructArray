using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayStruct_Libreria
{
    struct Libros
    {
       public string titulo;
       public  string edicion;
       public string genero;
       public string autor;
       public string pais;
       public int year;
    }
    public partial class Form1 : Form
    {   //Declaracion  del arreglo tipo estructura
        Libros[] Lib = new Libros[100];
        
        //variables de uso global
        int indice = 0, iModificar;
        public Form1()
        {
            InitializeComponent();
        }

        //Metodo para limpiar  los campos de texto
        void LimpiarCampos()
        {
            textTitulo.Text = "";
            textEdicion.Text = "";
            comboGenero.Text = "";
            textAutor.Text = "";
            textPais.Text = "";
            textYear.Text = "";
        }
        void Registrar()
        {
            try
            {
                if (textTitulo.Text != "" && textEdicion.Text != "" && comboGenero.Text != "") 
                {
                    Lib[indice].titulo = textTitulo.Text;
                    Lib[indice].edicion = textEdicion.Text;
                    Lib[indice].genero =Convert.ToString( comboGenero.SelectedItem);
                    Lib[indice].autor = textAutor.Text;
                    Lib[indice].pais = textPais.Text;
                    Lib[indice].year = Convert.ToInt32(textYear.Text);
                    indice++;
                }
                else
                {

                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al cargar el registro del libro", e .Message);

            }

        }
        //Metodo para mostrar los registros
        void MostarRegistros()
        {
            try
            {
                string Lista = "";
                for (int i=0; i < indice; i++)
                {
                    Lista= Lista + i+ " - "+ Lib[i].titulo + " "+ Lib[i].edicion+ " "+ Lib[i].genero+ " "+ Lib[i].autor+" "+ Lib[i].pais+" " + Lib[i].year+ " \n";

                }
                rtbRegistros.Text = Lista;
            }
            catch(Exception e)
            {
                MessageBox.Show("Ocurrio un error al cargar los libros ", e.Message);

            }
        }
        //Metodo para buscar registro
        void BuscarRegistro()
        {
            try
            {
                if (textBuscarTitulo.Text !="")
                {
                    for(int i=0; i< indice; i ++)
                    {
                        if (Lib[i].titulo==textBuscarTitulo.Text)
                        {
                            textTitulo.Text = Lib[i].titulo;
                            textEdicion.Text = Lib[i].edicion;
                            comboGenero.SelectedText = Lib[i].genero;
                            textAutor.Text = Lib[i].autor;
                            textPais.Text = Lib[i].pais;
                            textYear.Text = Convert.ToString(Lib[i].year);
                            iModificar = i;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Campo de busqueda esta vacio ");
                }

            }
            catch(Exception e)
            {
                MessageBox.Show("Ocurrio un error en la busqueda de registros ", e.Message);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnModificar.Enabled=true;
            btnGuardar.Enabled = false;


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarRegistro();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registrar();
            MostarRegistros();
            LimpiarCampos();
        }
    }
}
