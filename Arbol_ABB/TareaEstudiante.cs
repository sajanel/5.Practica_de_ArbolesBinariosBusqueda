using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_ABB
{
    //Se utiliza el comparador colocando : en la clase
    public class TareaEstudiante:Comparador
    {
        //Atributos de la clase estudiante 

       public String Duracion { get; set; }
       public String NombreTarea { get; set; }
       public String PocentajeAvance { get; set; }
       public String ProgramadorAsig { get; set; }
       public int ID { get; set; }

        //Se crea un constructor por defecto vacio para 
        //poder utilizar la informacion almacenada por defecto
       public TareaEstudiante() { 
       
       }


       public TareaEstudiante(String Duracion, String NombreTarea,String PocentajeAvance,String ProgramadorAsig,int ID)
        {

            this.Duracion = Duracion;
            this.NombreTarea = NombreTarea;
            this.PocentajeAvance = PocentajeAvance;
            this.ProgramadorAsig = ProgramadorAsig;
            this.ID = ID;
        
        }
        public bool igualQue(object q) 
        {
            TareaEstudiante Aux = (TareaEstudiante)q;
            return ID == Aux.ID;
             
        }
        public bool menorQue(object q)
        {
            TareaEstudiante Aux = (TareaEstudiante)q;
            return ID < Aux.ID;
        }

        public bool menorIgualQue(object q)
        {
            throw new NotImplementedException();
        }

        public bool mayorQue(object q)
        {
            TareaEstudiante Aux = (TareaEstudiante)q;
            return ID > Aux.ID;
        }


        /// <summary>
        /// Por medio de NomIgual y NomDiferente podemos verificar
        /// si los nombres son iguales o no esto con el fin de poder 
        /// hacer busquedas y eliminaciones de los datos del arbol
        /// </summary>
        /// <param name="q">Procedimiento para verificacion de Nombres</param>
        /// <returns></returns>
        /// 
        public bool NomIgual(object q) 
        {
            TareaEstudiante Aux = (TareaEstudiante)q;
            return NombreTarea == Aux.NombreTarea;     
        }

        public bool NomDiferente(object q)
        {
            TareaEstudiante Aux = (TareaEstudiante)q;
            return NombreTarea != Aux.NombreTarea;
        }

        //Obtiene los datos y son utilizados para imprimir en el formulario

        public override string ToString()
        {
            return ID +" | "+ NombreTarea+" | "+Duracion+" | "+PocentajeAvance+" | "+ProgramadorAsig+"  ";
        }

    }
}
