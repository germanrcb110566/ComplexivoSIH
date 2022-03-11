using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ComplexivoSIH.Models;

namespace ComplexivoSIH.Controllers
{
    public class FuncionesController : Controller
    {
        
        public static string EncryptKey(string cadena)
        {
            string key = "C0mpl3x1v0";
            return EncryptKey(cadena, key);
        }
        public static string EncryptKey(string cadena, string llave)
        {
            string key = llave;
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);
            //se utilizan las clases de encriptación provistas por el Framework Algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //se guarda la llave para que se le realice hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //arreglo de bytes donde se guarda la cadena cifrada
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            //se regresa el resultado en forma de una cadena
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }
        public static string DecryptKey(string cadena)
        {
            string key  = "C0mpl3x1v0";
            return DecryptKey(cadena, key);
        }
        public static string DecryptKey(string cadena, string llave)
        {
            string key  = llave;
            if (cadena.Length == 0) return "";
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(cadena);
            //se llama a las clases que tienen los algoritmos de encriptación se le aplica hashing algoritmo MD5
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tdes.Clear();
            //se regresa en forma de cadena
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static mPersona LeerPersona(ref string Mensaje, string Identificacion)
        {
            var registro = new mPersona();
            try
            {
                using (var conexion = new SIHEntities())
                {
                    registro = conexion.mPersona.Where(a => a.identificacion == Identificacion).Single();
                    Mensaje = "0000SENTENCIA EJECUTADA CORRECTAMENTE";
                }
            }
            catch (Exception ex)
            {
                registro = null;
                Mensaje = "0010PERSONA NO ESTA REGISTRADA EN EL SISTEMA.  Información adicional:".ToUpper() + ex.Message;

            }
            return registro;
        }

        public static string ObtenerRol(ref string Mensaje, string Persona_Id, int Registro_id, ref string Layout)
        {
            int Rol_Id = 0;
            string Rol = null;
            string SentenciaSQL = "select nombre from catalogo where  catalogo_id in (";
            SentenciaSQL += "select rol_id from rrol_Persona where persona_id in ";
            SentenciaSQL += "(select persona_id from mPersona where identificacion='" + Persona_Id + "')";
            SentenciaSQL += ") order by descripcion desc";
            string SentenciaSQL1 = "select descripcion from catalogo where  catalogo_id in (";
            SentenciaSQL1 += "select rol_id from rrol_Persona where persona_id in ";
            SentenciaSQL1 += "(select persona_id from mPersona where identificacion='" + Persona_Id + "')";
            SentenciaSQL1 += ") order by SUBSTRING(descripcion,1,1) desc";
            string SentenciaSQL2 = "select catalogo_id from catalogo where  catalogo_id in (";
            SentenciaSQL2 += "select  rol_id  from rrol_Persona where persona_id in ";
            SentenciaSQL2 += "(select persona_id from mPersona where identificacion='" + Persona_Id + "')";
            SentenciaSQL2 += ") order by descripcion desc";
            try
            {
                using (var conexion = new SIHEntities())
                {
                    Rol = conexion.Database.SqlQuery<string>(SentenciaSQL).FirstOrDefault();
                    if (Rol != null)
                    {
                        Mensaje = "0000SENTENCIA EJECUTADA CORRECTAMENTE";
                        Layout = conexion.Database.SqlQuery<string>(SentenciaSQL1).FirstOrDefault().Substring(1);
                        Rol_Id = Convert.ToInt32(conexion.Database.SqlQuery<int>(SentenciaSQL2).FirstOrDefault());
                    }
                    else
                    { 
                        Mensaje = "0099NO TIENE ASIGNADO UN ROL LA PERSONA";
                    }
                }
            }
            catch (Exception ex)
            {
                Mensaje = "0020" + ex.Message;
            }
            string Log = InsertarLog(Registro_id, Convert.ToInt32(Rol_Id), 1, SentenciaSQL);
            return Rol;
        }

        public static object Citas_Pendientes()
        {
            string SentenciaSQL = "Select * from mCita where cita_id not in (select cita_id from mAtencion)";
            
            try
            {
                using (var conexion = new SIHEntities())
                {
                    var Citas = conexion.Database.SqlQuery<string>(SentenciaSQL);
                    return Citas;
                }
            }
            catch (Exception ex)
            {
                string Mensaje = "0020" + ex.Message;
            }
            
            return "";
        }

        public static string InsertarLog(int Usuario_Id,
                                  int Rol_Id,
                                  int Modulo_Id,
                                  string sentenciasql)
        {
            if (sentenciasql == null)
            {
                sentenciasql = "NO SE RECIBIO SENTENCIA ";
            }
            string retorno = "";
            string cadena = "'" + DateTime.Now + "',";
            cadena += Usuario_Id + ",";
            cadena += Rol_Id + ",";
            cadena += Modulo_Id + ",";
            cadena += "'" + sentenciasql.Replace("'", "#") + "'";
            //cadena += "'" + sentenciasql.Replace("'", "#") + "'";
            try
            {
                using (var conexion = new SIHEntities())
                {
                    string sentenciaSQL = "INSERT INTO mAuditoria VALUES (" + cadena + ")";
                    int st = conexion.Database.ExecuteSqlCommand(sentenciaSQL);
                    if (st == 1)
                    {
                        retorno = "0000REGISTRO CREADO EXITOSAMENTE";
                    }
                }
            }
            catch (Exception ex)
            {
                retorno = "0010" + ex.Message;
            }
            return retorno;
        }
    }
}
