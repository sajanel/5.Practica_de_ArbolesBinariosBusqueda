using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arbol_ABB.Arboles;

namespace Arbol_ABB.BusquedaArbol
{
   public class ArbolBinarioBusqueda:Arbol
    {
        public ArbolBinarioBusqueda(): base()
        {
        }

        public ArbolBinarioBusqueda(Nodo nodo): base(nodo)
        {      
        }

       
        public Nodo buscarIterativo(Object buscado)
        {
            Comparador dato;

            bool encontrado = false;

            /*Siempre apuntamos a la raiz*/
            Nodo raizSub = raiz;
            Nodo raizSub2 = raiz;


            dato = (Comparador)buscado;

            while (!encontrado && raizSub != null)
            {
                /*Si la raiz es igual al dato insertado*/

                if (dato.NomIgual(raizSub.valorNodo()))
                {
                    /*Listo encontro la busqueda*/
                    encontrado = true;
                    return raizSub;
                }

                    /*Si la raiz es diferente al dato insertado*/
                else if (dato.NomDiferente(raizSub.valorNodo()))
                {
                    /*y si la raiz izquierda no esta vacia*/
                    while (raizSub.subarbolIzdo() != null)
                    {
                        /*La busqueda se ira hacia la izquierda hasta que encuentre el dato*/
                        raizSub = raizSub.subarbolIzdo();

                        if (dato.NomIgual(raizSub.valorNodo()))
                        {
                            encontrado = true;
                            return raizSub;
                        }
                    }

                    /*Si no encontro el dato en la derecha*/

                    if (dato.NomDiferente(raizSub2.valorNodo()))
                    {
                        /*Que busque en el lado derecho eso si hay dato*/
                        while (raizSub2.subarbolDcho() != null)
                        {
                            /*La busqueda se ira hacia la derecha hasta que encuentre el dato*/
                            raizSub2 = raizSub2.subarbolDcho();

                            if (dato.NomIgual(raizSub2.valorNodo()))
                            {
                                encontrado = true;
                                return raizSub2;
                            }
                        }
                        break;
                    }
                }
            }
            return null;
        }

        public void insertar(Object valor)
        {

            Comparador dato;
            dato = (Comparador)valor;
            raiz = insertar(raiz, dato);
        }

        //método interno para realizar la operación
        protected Nodo insertar(Nodo raizSub, Comparador dato)
        {
            if (raizSub == null)
                raizSub = new Nodo(dato);
            else if (dato.NomDiferente(raizSub.valorNodo()))
            {
                Nodo iz;
                iz = insertar(raizSub.subarbolIzdo(), dato);
                raizSub.ramaIzdo(iz);
            }
            else if (dato.NomDiferente(raizSub.valorNodo()))
            {
                Nodo dr;
                dr = insertar(raizSub.subarbolDcho(), dato);
                raizSub.ramaDcho(dr);
            }
            else throw new Exception("Nodo duplicado");
            return raizSub;
        }

        public object eliminar(Object valor)
        {
        
            Comparador dato;
            dato = (Comparador)valor;

            if (eliminar(raiz, dato)!=null)
            {
                return raiz = eliminar(raiz, dato);
            }

            else 
            {
                return null;
            }

        }

        //método interno para realizar la operación
        protected Nodo eliminar(Nodo raizSub, Comparador dato)
        {
            if (raizSub == null) { return raizSub; }

            else if (dato.NomDiferente(raizSub.valorNodo()))
            {
                Nodo iz;
                iz = eliminar(raizSub.subarbolIzdo(), dato);
                raizSub.ramaIzdo(iz);

            }
            else if (dato.NomDiferente(raizSub.valorNodo()))
            {
                Nodo dr;
                dr = eliminar(raizSub.subarbolDcho(), dato);
                raizSub.ramaDcho(dr);
            }
     
            else // Nodo encontrado
            {
                Nodo q;
                q = raizSub; // nodo a quitar del árbol
                if (q.subarbolIzdo() == null)
                    raizSub = q.subarbolDcho();
                else if (q.subarbolDcho() == null)
                    raizSub = q.subarbolIzdo();
                else
                { // tiene rama izquierda y derecha
                    q = reemplazar(q);
                }
                q = null;
            }
            return raizSub;
        }

        // método interno para susutituir por el mayor de los menores
        private Nodo reemplazar(Nodo act)
        {
            Nodo a, p;
            p = act;
            a = act.subarbolIzdo(); // rama de nodos menores
            while (a.subarbolDcho() != null)
            {
                p = a;
                a = a.subarbolDcho();
            }
            act.nuevoValor(a.valorNodo());
            if (p == act)
                p.ramaIzdo(a.subarbolIzdo());
            else
                p.ramaDcho(a.subarbolIzdo());
            return a;
        }


    }
}
