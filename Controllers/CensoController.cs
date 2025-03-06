using apiRESTCenso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime;
using System.Web.Http;

namespace apiRESTCenso.Controllers
{
    public class CensoController : ApiController
    {
        //Definicion del arreglo de objetos
        public static clsCenso[] objCenso = null;
        
        // GET: api/Censo
        public IEnumerable<clsCenso> Get()
        {
            return objCenso;
        }

        // GET: api/Censo/5
        public clsCenso Get(int id)
        {
            //Elemento de uso para lectura
            clsCenso elemento = new clsCenso();
            for(int i=0; i<objCenso.Length; i++)
            {
                if (objCenso[i].id == id)
                {
                    elemento = objCenso[i];
                    break;
                }
            }
            return elemento;
        }

        // POST: api/Censo
        public string Post(int posicion, [FromBody]clsCenso modelo)
        {
            string ban = "";
            //Validacion del arreglo
            if(objCenso == null)
            {
                //Creacion del arreglo de objetos
                //Creacion de los [5] elementos
                objCenso = new clsCenso[5];
                objCenso[0] = new clsCenso();
                objCenso[1] = new clsCenso();
                objCenso[2] = new clsCenso();
                objCenso[3] = new clsCenso();
                objCenso[4] = new clsCenso();
            }

            //Validar la posicion e insertar datos
            if (posicion >= 0 && posicion<= 4)
            {
                objCenso[posicion].id = modelo.id;
                objCenso[posicion].curp = modelo.curp;
                objCenso[posicion].nombre = modelo.nombre;
                objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;

                ban = "1";
            }
            else
            {
                ban = "0";
            }
            return ban;

        }

        // PUT: api/Censo/5
        public string Put(int posicion, [FromBody]clsCenso modelo)
        {
            string ban="";
            if (objCenso != null)
            {
                if (posicion>=0 && posicion<=4)
                 {
                    objCenso[posicion].id = modelo.id;
                    objCenso[posicion].curp = modelo.curp;
                    objCenso[posicion].nombre = modelo.nombre;
                    objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;

                    ban = "1";
                }
                else
                {
                    ban = "0";
                }
            }
            return ban;

        }

        // DELETE: api/Censo/5
        public string Delete(int posicion)
        {
            string ban = "";
            if (objCenso != null)
            { 
                if (posicion >= 0 && posicion <= 4)
                {   
                    objCenso[posicion].id = 0;
                    objCenso[posicion].curp = null;
                    objCenso[posicion].nombre = null;
                    objCenso[posicion].apellidoPaterno = null;
                    ban = "1";
                }
                else
                {
                    ban = "0";
                }
            } 
            return ban;
        }
    }
}
