using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol_ABB
{
   public interface Comparador
    {
        bool igualQue(Object q);
        bool menorQue(Object q);
        bool menorIgualQue(Object q);
        bool mayorQue(Object q);
       /*Elementos agregados recientemente*/
        bool NomIgual(Object q);
        bool NomDiferente(Object q);

    }
}
