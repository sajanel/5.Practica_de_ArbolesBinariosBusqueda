using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arbol_ABB.Arboles;
using Arbol_ABB.BusquedaArbol;
using Arbol_ABB;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        ArbolBinarioBusqueda miArbol = new ArbolBinarioBusqueda();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Se crea un objeto de tipo miTareaAux que servira para 
            //Insertar informacion posteormente.
          
            TareaEstudiante miTareaAux;
            miTareaAux = new TareaEstudiante();

            /// En esta accion inserta todos los datos del formulario 
            /// a la clase TareaEstudiante  por medio del objeto miTareaAux
         
            miTareaAux.ID = int.Parse(txtId.Text);
            miTareaAux.NombreTarea = txtNombre.Text;
            miTareaAux.PocentajeAvance = txtAvance.Text;
            miTareaAux.ProgramadorAsig = txtProgramador.Text;
            miTareaAux.Duracion = txtDuracion.Text;

            /// Ya almacenada la informacion en la clase se procede a insertarla
            /// en el arbol binario
         
            miArbol.insertar(miTareaAux);
            
        }

        private void btnDeplegar_Click(object sender, EventArgs e)
        {
            //En el boton btnDeplegar lo primero deja un espaccion en blanco
            //Despues imprime la informacion que tenga el arbol y lo imprimira
            //en preorden raiz,izquierda,derecha

            listBox1.Items.Add("");
            listBox1.Items.Add(ArbolBinarioBusqueda.preorden(miArbol.raizArbol()));
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            //Se crea un objeto de tipo miTareaAux que servira para 
            //la obtencion de informacion desde la clase.
          
           TareaEstudiante miTareaAux;
          
           miTareaAux = new TareaEstudiante();

           miTareaAux.NombreTarea = txtNombreBusca.Text;

            //Se crea un objeto de tipo Nodo para verificar si retorna un dato
            //si retorna un dato verifica que no sea null
            //Si es null mostrara el mensaje que no lo encontro

            Nodo miNodoArbol = miArbol.buscarIterativo(miTareaAux);

            if (miNodoArbol != null)
            {
                miTareaAux = (TareaEstudiante)miNodoArbol.dato;
                listBox2.Items.Clear();
                listBox2.Items.Add(miNodoArbol.dato.ToString());
            }
            else
            {
                MessageBox.Show("No se encontro el dato ");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Se crea un objeto de tipo miTareaAux que servira para 
            //la obtencion de informacion desde la clase.

            TareaEstudiante miTareaAux;

            miTareaAux = new TareaEstudiante();

            miTareaAux.NombreTarea = txtNombreBusca.Text;

            //Aca verifica si el metodo retorna un null
            // si retorna null se pasa a la otra condicion

            if (miArbol.eliminar(miTareaAux) != null)
            {
                miArbol.eliminar(miTareaAux);
                listBox2.Items.Clear();
                listBox2.Items.Add("Verificar si el dato se ha borrado presionando desplegar");
            }
            else 
            {
               
                listBox2.Items.Clear();
                listBox2.Items.Add("No se puedo eliminar la raiz ingrese otro dato ");
                listBox2.Items.Add("eh intente eliminar la raiz ");
            
            }
            
        }


    }
}
